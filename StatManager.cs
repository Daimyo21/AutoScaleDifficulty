using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using Photon;
using SharedModConfig;
using UnityEngine;

namespace AutoScaleDifficulty
{
    public class StatManager : PunBehaviour
    {
        public static StatManager Instance { get; private set; }

        public ModConfig CurrentPlayerSyncInfo { get; set; }
        public ModConfig CurrentAISyncInfo { get; set; }


        private static readonly string _dir = @"Mods\ModConfigs\";
        private static readonly string _file = $"{_dir }{ Settings.ModName }";
        private static readonly string _ext = ".json";

        private readonly Dictionary<string, VitalsInfo> _lastVitals = new Dictionary<string, VitalsInfo>();

        private string _currentHostUid = "";
        private bool _playerSyncInit = false;
        private bool _aiSyncInit = false;
        private bool _checkSplit = false;
        private bool _isOnline = false;
        private float _lastVitalsUpdate = -12f;

        internal void Awake()
        {
            Instance = this;
        }

        internal void Start()
        {
            AutoScaleDifficulty.AutoScaleDiff_Config.OnSettingsSaved += PlayerSyncHandler;
            AutoScaleDifficulty.AIConfig.OnSettingsSaved += AISyncHandler;
        }

        internal void Update()
        {
            if (Global.Lobby.PlayersInLobbyCount < 1 
                || NetworkLevelLoader.Instance.IsGameplayPaused 
                || NetworkLevelLoader.Instance.IsGameplayLoading)
            {
                return;
            }

            if (Global.Lobby.PlayersInLobbyCount > 1)
            {
                if (_checkSplit)
                {
                    _checkSplit = false;
                    UpdateCustomStats(AutoScaleDifficulty.AutoScaleDiff_Config);
                }

                if (!PhotonNetwork.offlineMode && PhotonNetwork.isNonMasterClientInRoom)
                {
                    if (!_isOnline)
                    {
                        _isOnline = true;
                    }

                    if (UpdateSyncInfo())
                    {
                        RequestSync();
                    }
                }
            }
            else
            {
                if (_isOnline && PhotonNetwork.connected)
                {
                    _isOnline = false;
                    _currentHostUid = "";
                    UpdatePlayerSyncInfo(false);
                    UpdateAISyncInfo(false);
                    UpdateCustomStats(AutoScaleDifficulty.AutoScaleDiff_Config);
                    UpdateCustomStats(AutoScaleDifficulty.AIConfig);
                }

                _checkSplit = true;
            }

            if (UpdateVitalsInfo())
            {
                SaveVitalsInfo();
            }
        }

        public void SetPlayerSyncInfo()  //client
        {
            if (!_playerSyncInit)
            {
                UpdatePlayerSyncInfo();
            }
            UpdateCustomStats(Instance.CurrentPlayerSyncInfo);
        }

        public void SetAISyncInfo()  //client
        {
            if (!_aiSyncInit)
            {
                UpdateAISyncInfo();
            }
            UpdateCustomStats(Instance.CurrentAISyncInfo);
        }

        public void SetSyncBoolInfo(string name, bool value, bool flag)  //client
        {
            if (flag)
            {
                Instance.CurrentPlayerSyncInfo.SetValue(name, value);
            }
            else
            {
                Instance.CurrentAISyncInfo.SetValue(name, value);
            }
        }

        public void SetSyncFloatInfo(string name, float value, bool flag)  //client
        {
            if (flag)
            {
                Instance.CurrentPlayerSyncInfo.SetValue(name, value);
            }
            else
            {
                Instance.CurrentAISyncInfo.SetValue(name, value);
            }
        }

        private static void PlayerSyncHandler()  //host
        {
            if (Global.Lobby.PlayersInLobbyCount < 1) { return; }

            if (!PhotonNetwork.offlineMode && !PhotonNetwork.isNonMasterClientInRoom)
            {
                RPCManager.Instance.PlayerSync();
            }

            if (PhotonNetwork.isMasterClient)
            {
                Instance.UpdateCustomStats(AutoScaleDifficulty.AutoScaleDiff_Config);
            }
        }

        private static void AISyncHandler()  //host
        {
            if (Global.Lobby.PlayersInLobbyCount < 1) { return; }

            if (!PhotonNetwork.offlineMode && !PhotonNetwork.isNonMasterClientInRoom)
            {
                RPCManager.Instance.AISync();
            }

            if (PhotonNetwork.isMasterClient)
            {
                Instance.UpdateCustomStats(AutoScaleDifficulty.AIConfig);
            }
        }

        private static float ModifyLogic(bool mult, float orig, float value, float limit)
        {
            if (mult)
            {
                if (value < 0)
                {
                    if ((limit - orig) / orig > value)
                    {
                        return (limit - orig) / orig;
                    }
                    else
                    {
                        return value;
                    }
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return Math.Max(limit - orig, value);
            }
        }

        private static float Modify(bool mult, float orig, float value, float limit, ModConfig config)
        {
            if ((bool)config.GetValue(Settings.GameBehaviour))
            {
                return ModifyLogic(mult, orig, value, limit);
            }
            else
            {
                if ((bool)config.GetValue(Settings.StrictMinimum))
                {
                    switch (limit)
                    {
                        case 50f:
                            limit = 1f;
                            break;
                        case 0.01f:
                            limit = 0f;
                            break;
                        default:
                            limit = 0f;
                            break;
                    }

                    return ModifyLogic(mult, orig, value, limit);
                }
                else
                {
                    return value;
                }
            }
        }

        private void RequestSync()  //client
        {
            _currentHostUid = CharacterManager.Instance.GetWorldHostCharacter()?.UID;

            if (CurrentPlayerSyncInfo == null)
            {
                RPCManager.Instance.RequestPlayerSync();
            }

            if (CurrentAISyncInfo == null)
            {
                RPCManager.Instance.RequestAISync();
            }
        }

        private void UpdatePlayerSyncInfo(bool init = true)
        {
            _playerSyncInit = init;

            if (!init)
            {
                CurrentPlayerSyncInfo = null;
            }
        }

        private void UpdateAISyncInfo(bool init = true)
        {
            _aiSyncInit = init;

            if (!init)
            {
                CurrentAISyncInfo = null;
            }
        }

        private bool UpdateSyncInfo()
        {
            if (_playerSyncInit && _aiSyncInit)
            {
                if (CharacterManager.Instance.GetWorldHostCharacter() is Character host)
                {
                    if (host.UID != _currentHostUid)
                    {
                        return true;
                    }
                    else
                    {
                        if (CurrentPlayerSyncInfo == null || CurrentAISyncInfo == null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void UpdateCustomStats(ModConfig config)
        {
            if (config.ModName.Contains("Player"))
            {
                foreach (Character _c in CharacterManager.Instance.Characters.Values)
                {
                    if (!_c.IsAI)
                    {
                        if ((bool)config.GetValue(Settings.EnableAutoScaleDifficulty))
                        {
                            ApplyCustomStats(_c, config, Settings.PlayerStats, true);
                        }
                        else
                        {
                            ApplyCustomStats(_c, config, Settings.PlayerStats, false);
                        }   
                    }
                }
            }
            else
            {
                foreach (Character _c in CharacterManager.Instance.Characters.Values)
                {
                    if (_c.IsAI)
                    {
                        if ((bool)config.GetValue(Settings.EnableAutoScaleDifficulty))
                        {
                            ApplyCustomStats(_c, config, Settings.AIStats, true);
                        }
                        else
                        {
                            ApplyCustomStats(_c, config, Settings.AIStats, false);
                        }
                    }
                }
            }
        }

        private void ApplyCustomStats(Character character, ModConfig config, string stackSource, bool flag)
        {
            character.Stats.RefreshVitalMaxStat();
            character.Stats.RestoreAllVitals();

            VitalsInfo _ratios = LoadVitalsInfo(character.UID) ?? new VitalsInfo
            {
                HealthRatio = character.HealthRatio,
                BurntHealthRatio = character.Stats.BurntHealthRatio,
                StaminaRatio = character.StaminaRatio,
                BurntStaminaRatio = character.Stats.BurntStaminaRatio,
                ManaRatio = character.ManaRatio,
                BurntManaRatio = character.Stats.BurntManaRatio
            };

            foreach (BBSetting _bbs in config.Settings)
            {
                if (_bbs is FloatSetting _f)
                {
                    Tag _tag = TagSourceManager.Instance.GetTag(AT.GetTagUid(_f.Name));
                    bool _mult = (bool)config.GetValue(_f.Name + Settings.ModMult);

                    if (flag)
                    {
                        SetCustomStat(character.Stats, stackSource, _tag, 
                            _mult ? _f.m_value / 100f : _f.m_value,
                            _mult, config);
                    }
                    else
                    {
                        ClearCustomStat(character.Stats, _tag, stackSource, _mult);
                    }
                    
                }
            }

            UpdateVitals(character.Stats, _ratios, config);

            if (!character.IsAI)
            {
                SaveVitalsInfo(character.UID);
            }
        }

        // monster switch statement ahead...
        private void SetCustomStat(CharacterStats stats, string stackSource, Tag statTag, float value, bool mult, ModConfig config)
        {
            ClearCustomStat(stats, statTag, stackSource, mult);
            stats.RefreshVitalMaxStat();
            Stat[] _dmg = (Stat[])AT.GetValue(typeof(CharacterStats), stats, "m_damageTypesModifier");
            Stat[] _pro = (Stat[])AT.GetValue(typeof(CharacterStats), stats, "m_damageProtection");
            Stat[] _res = (Stat[])AT.GetValue(typeof(CharacterStats), stats, "m_damageResistance");

            switch (statTag.TagName)
            {
                case "MaxHealth":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_maxHealthStat"), value, CharacterStats.MIN_MAXHEALTH_LIMIT, config)), mult);
                    break;
                case "HealthRegen":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_healthRegen"), value, Settings.Minimum, config)), mult);
                    break;
                case "HealthBurn":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_burntHealthModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "MaxStamina":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_maxStamina"), value, CharacterStats.MIN_MAXSTAMINA_LIMIT, config)), mult);
                    break;
                case "StaminaRegen":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_staminaRegen"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "StaminaUse":
                case "StaminaCostReduction":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_staminaUseModifiers"), value, Settings.Minimum, config)), mult);
                    break;
                case "StaminaBurn":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_burntStaminaModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "MaxMana":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_maxManaStat"), value, Settings.Minimum, config)), mult);
                    break;
                case "ManaRegen":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_manaRegen"), value, Settings.Minimum, config)), mult);
                    break;
                case "ManaUse":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_manaUseModifiers"), value, Settings.Minimum, config)), mult);
                    break;
                case "ManaBurn":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_burntManaModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "Impact":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_impactModifier"), value, Settings.Minimum, config)), mult);
                    break;
                case "AllDamages":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_damageModifiers"), value, Settings.Minimum, config)), mult);
                    break;
                case "PhysicalDamage":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _dmg[0].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "EtherealDamage":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _dmg[1].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "DecayDamage":
                case "DarkDamage":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _dmg[2].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "ElectricDamage":
                case "LightDamage":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _dmg[3].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "FrostDamage":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _dmg[4].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "FireDamage":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _dmg[5].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "DamageProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_allDamageProtection"), value, Settings.Minimum, config)), mult);
                    break;
                case "PhysicalProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[0].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "EtherealProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[1].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "DecayProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[2].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "ElectricProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[3].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "FrostProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[4].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "FireProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[5].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "DarkProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[6].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "LightProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _pro[7].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "AllResistances":
                case "DamageResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_resistanceModifiers"), value, Settings.Minimum, config)), mult);
                    break;
                case "PhysicalResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[0].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "EtherealResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[1].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "DecayResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[2].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "ElectricResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[3].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "FrostResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[4].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "FireResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[5].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "DarkResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[6].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "LightResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, _res[7].CurrentValue, value, Settings.Minimum, config)), mult);
                    break;
                case "ImpactResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_impactResistance"), value, Settings.Minimum, config)), mult);
                    break;
                case "StabilityRegen":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_stabilityRegen"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "EnvColdProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_coldProtection"), value, Settings.Minimum, config)), mult);
                    break;
                case "EnvHeatProtection":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_heatProtection"), value, Settings.Minimum, config)), mult);
                    break;
                case "ColdRegen":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_coldRegenRate"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "HeatRegen":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_heatRegenRate"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "Waterproof":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_waterproof"), value, Settings.Minimum, config)), mult);
                    break;
                case "CorruptionResistance":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_corruptionResistance"), value, Settings.Minimum, config)), mult);
                    break;
                case "TemperatureModifier":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_temperatureModifier"), value, Settings.Minimum, config)), mult);
                    break;
                case "MovementSpeed":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_movementSpeed"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "Speed":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_speedModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "AttackSpeed":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_attackSpeedModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "DodgeInvulnerabilityModifier":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_dodgeInvulneratiblityModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "Detectability":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_detectability"), value, Settings.Minimum, config)), mult);
                    break;
                case "VisualDetectability":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_visualDetectability"), value, Settings.Minimum, config)), mult);
                    break;
                case "PouchCapacity":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_pouchCapacity"), value, Settings.Minimum, config)), mult);
                    break;
                case "FoodEffectEfficiency":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_foodEffectEfficiency"), value, Settings.Minimum, config)), mult);
                    break;
                case "SkillCooldownModifier":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_skillCooldownModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "BuyModifier":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_buyModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "SellModifier":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetCharacterStat(stats, "m_sellModifier"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "FoodDepleteRate":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetPlayerStat(stats.GetComponent<PlayerCharacterStats>(), "m_foodDepletionRate"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "DrinkDepleteRate":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetPlayerStat(stats.GetComponent<PlayerCharacterStats>(), "m_drinkDepletionRate"), value, Settings.MinimumMod, config)), mult);
                    break;
                case "SleepDepleteRate":
                    stats.AddStatStack(statTag, new StatStack(stackSource, Modify(mult, AT.GetPlayerStat(stats.GetComponent<PlayerCharacterStats>(), "m_sleepDepletionRate"), value, Settings.MinimumMod, config)), mult);
                    break;
            }
        }

        private void ClearCustomStat(CharacterStats stats, Tag statTag, string stackSource, bool mult)
        {
            stats.RemoveStatStack(statTag, stackSource, !mult);
            stats.RemoveStatStack(statTag, stackSource, mult);
        }

        private void UpdateVitals(CharacterStats stats, VitalsInfo ratios, ModConfig config)
        {
            float _hp, _hpb, _sp, _spb, _mp, _mpb;

            stats.RefreshVitalMaxStat();

            if (!(bool)config.GetValue(Settings.GameBehaviour) && stats.GetComponent<Character>().IsLocalPlayer)
            {
                _hp = SaveManager.Instance.GetCharacterSave(stats.GetComponent<Character>().UID).PSave.Health;
                _hpb = SaveManager.Instance.GetCharacterSave(stats.GetComponent<Character>().UID).PSave.BurntHealth;
                _sp = SaveManager.Instance.GetCharacterSave(stats.GetComponent<Character>().UID).PSave.Stamina;
                _spb = SaveManager.Instance.GetCharacterSave(stats.GetComponent<Character>().UID).PSave.BurntStamina;
                _mp = SaveManager.Instance.GetCharacterSave(stats.GetComponent<Character>().UID).PSave.Mana;
                _mpb = SaveManager.Instance.GetCharacterSave(stats.GetComponent<Character>().UID).PSave.BurntMana;
            }
            else
            {
                _hp = stats.MaxHealth * ratios.HealthRatio;
                _hpb = stats.MaxHealth * ratios.BurntHealthRatio;
                _sp = stats.MaxStamina * ratios.StaminaRatio;
                _spb = stats.MaxStamina * ratios.BurntStaminaRatio;
                _mp = stats.MaxMana * ratios.ManaRatio;
                _mpb = stats.MaxMana * ratios.BurntManaRatio;
            }

            stats.SetHealth(_hp);
            AT.SetValue(_hpb, typeof(CharacterStats), stats, "m_burntHealth");
            AT.SetValue(_sp, typeof(CharacterStats), stats, "m_stamina");
            AT.SetValue(_spb, typeof(CharacterStats), stats, "m_burntStamina");
            stats.SetMana(_mp);
            AT.SetValue(_mpb, typeof(CharacterStats), stats, "m_burntMana");
        }

        private bool UpdateVitalsInfo()
        {
            if (Time.time - _lastVitalsUpdate > 12f)
            {
                foreach (Character _c in CharacterManager.Instance.Characters.Values)
                {
                    if (_lastVitals.ContainsKey(_c.UID)
                        && _c.HealthRatio != _lastVitals.GetValueSafe(_c.UID).HealthRatio
                        && _c.HealthRatio <= 1)
                    {
                        return true;
                    }
                }
                _lastVitalsUpdate = Time.time;
                return false;
            }
            else
            {
                return false;
            }
        }

        private VitalsInfo LoadVitalsInfo(string uid)
        {
            string _path = $"{ _file}_{ uid }{ _ext }";

            if (File.Exists(_path))
            {
                if (JsonUtility.FromJson<VitalsInfo>(File.ReadAllText(_path)) is VitalsInfo _json)
                {
                    return _json;
                }
            }

            return null;
        }

        private void SaveVitalsInfo(string targetUid = null)
        {
            if (!Directory.Exists(_dir))
            {
                Directory.CreateDirectory(_dir);
            }

            foreach (SplitPlayer _player in SplitScreenManager.Instance.LocalPlayers)
            {
                if (targetUid != null)
                {
                    if (_player.AssignedCharacter.UID != targetUid)
                    {
                        continue;
                    }
                }

                string _path = $"{_file}_{ _player.AssignedCharacter.UID }{ _ext }";
                VitalsInfo _vitals = new VitalsInfo
                {
                    HealthRatio = _player.AssignedCharacter.HealthRatio,
                    BurntHealthRatio = _player.AssignedCharacter.Stats.BurntHealthRatio,
                    StaminaRatio = _player.AssignedCharacter.StaminaRatio,
                    BurntStaminaRatio = _player.AssignedCharacter.Stats.BurntStaminaRatio,
                    ManaRatio = _player.AssignedCharacter.ManaRatio,
                    BurntManaRatio = _player.AssignedCharacter.Stats.BurntManaRatio
                };

                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }

                if (_lastVitals.ContainsKey(_player.AssignedCharacter.UID))
                {
                    _lastVitals.Remove(_player.AssignedCharacter.UID);
                }

                _lastVitals.Add(_player.AssignedCharacter.UID, _vitals);
                File.WriteAllText(_path, JsonUtility.ToJson(_vitals));
            }
        }

        [HarmonyPatch(typeof(CharacterStats), "ApplyCoopStats")]
        public class CharacterStats_ApplyCoopStats
        {
            [HarmonyPrefix]
            public static bool Prefix(CharacterStats __instance)
            {
                Character _c = __instance.GetComponent<Character>();

                if ((!(bool)AutoScaleDifficulty.AutoScaleDiff_Config.GetValue(Settings.EnableAutoScaleDifficulty) 
                    && !(bool)AutoScaleDifficulty.AIConfig.GetValue(Settings.EnableAutoScaleDifficulty)) 
                    || NetworkLevelLoader.Instance.IsGameplayLoading
                    || !_c.IsLateInitDone)
                {
                    return true;
                }

                if (!PhotonNetwork.isNonMasterClientInRoom)
                {
                    if (!_c.IsAI)
                    {
                        if ((bool)AutoScaleDifficulty.AutoScaleDiff_Config.GetValue(Settings.EnableAutoScaleDifficulty))
                        {
                            Instance.ApplyCustomStats(_c, AutoScaleDifficulty.AutoScaleDiff_Config, Settings.PlayerStats, true);
                        }
                        else
                        {
                            Instance.ApplyCustomStats(_c, AutoScaleDifficulty.AutoScaleDiff_Config, Settings.PlayerStats, false);
                        }
                    }
                    else
                    {
                        if ((bool)AutoScaleDifficulty.AIConfig.GetValue(Settings.EnableAutoScaleDifficulty))
                        {
                            Instance.ApplyCustomStats(_c, AutoScaleDifficulty.AIConfig, Settings.AIStats, true);
                        }
                        else
                        {
                            Instance.ApplyCustomStats(_c, AutoScaleDifficulty.AIConfig, Settings.AIStats, false);
                        }
                    }
                }
                else
                {
                    if (!Instance._playerSyncInit || !Instance._aiSyncInit)
                    {
                        Instance.RequestSync();
                    }

                    if (!_c.IsAI)
                    {
                        if (Instance.CurrentPlayerSyncInfo != null && Instance._playerSyncInit)
                        {
                            if ((bool)Instance.CurrentPlayerSyncInfo.GetValue(Settings.EnableAutoScaleDifficulty))
                            {
                                Instance.ApplyCustomStats(_c, Instance.CurrentPlayerSyncInfo, Settings.PlayerStats, true);
                            }
                            else
                            {
                                Instance.ApplyCustomStats(_c, Instance.CurrentPlayerSyncInfo, Settings.PlayerStats, false);
                            }
                        }
                    }
                    else
                    {
                        if (Instance.CurrentAISyncInfo != null && Instance._aiSyncInit)
                        {
                            if ((bool)Instance.CurrentAISyncInfo.GetValue(Settings.EnableAutoScaleDifficulty))
                            {
                                Instance.ApplyCustomStats(_c, Instance.CurrentAISyncInfo, Settings.AIStats, true);
                            }
                            else
                            {
                                Instance.ApplyCustomStats(_c, Instance.CurrentAISyncInfo, Settings.AIStats, false);
                            }
                        }
                    }
                }

                return false;
            }
        }
    }
}
