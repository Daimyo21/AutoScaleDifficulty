using System.Collections;
using System.Collections.Generic;
using SharedModConfig;
using UnityEngine;

namespace AutoScaleDifficulty
{
    class RPCManager : Photon.MonoBehaviour
    {
        public static RPCManager Instance { get; private set; }

        internal void Awake()
        {
            Instance = this;
        }

        internal void Start()
        {
            var _photon = gameObject.AddComponent<PhotonView>();
            _photon.viewID = 777;
        }

        public void RequestPlayerSync()  //client
        {
            PlayerSyncInfoInit();
            if (!PhotonNetwork.offlineMode)
            {
                photonView.RPC("RequestPlayerSyncRPC", PhotonNetwork.masterClient, new object[0]);
            }
        }

        public void RequestAISync()  //client
        {
            AISyncInfoInit();
            if (!PhotonNetwork.offlineMode)
            {
                photonView.RPC("RequestAISyncRPC", PhotonNetwork.masterClient, new object[0]);
            }
        }

        public void PlayerSync() //host
        {
            if (!PhotonNetwork.offlineMode)
            {
                photonView.RPC("PlayerSyncRPC", PhotonTargets.All, new object[0]);
            }
        }

        public void AISync() //host
        {
            if (!PhotonNetwork.offlineMode)
            {
                photonView.RPC("AISyncRPC", PhotonTargets.All, new object[0]);
            }
        }

        [PunRPC]
        private void RequestPlayerSyncRPC()  //host
        {
            StartCoroutine(SetPlayerSyncInfoCO());
        }

        [PunRPC]
        private void RequestAISyncRPC()  //host
        {
            StartCoroutine(SetAISyncInfoCO());
        }

        private List<BBSetting> SyncSettingsInit(bool flag)  //client
        {
            List<BBSetting> _bbs = new List<BBSetting>();
            var _settings = new Settings();
            _bbs.AddRange(_settings.RulesSettings);
            if (flag) { _bbs.AddRange(_settings.PlayerSettings); }
            _bbs.AddRange(_settings.CharacterSettings);

            return _bbs;
        }

        private void PlayerSyncInfoInit()  //client
        {
            StatManager.Instance.CurrentPlayerSyncInfo = new ModConfig
            {
                ModName = Settings.ModName + "_Player",
                SettingsVersion = 1.0,
                Settings = SyncSettingsInit(true)
            };

            Settings.PseudoRegister(StatManager.Instance.CurrentPlayerSyncInfo);
        }

        private void AISyncInfoInit()  //client
        {
            StatManager.Instance.CurrentAISyncInfo = new ModConfig
            {
                ModName = Settings.ModName + "_AI",
                SettingsVersion = 1.0,
                Settings = SyncSettingsInit(false)
            };

            Settings.PseudoRegister(StatManager.Instance.CurrentAISyncInfo);
        }

        private void SendBoolSetting(ModConfig config, bool flag)  //host
        {
            foreach (BBSetting _bbs in config.Settings)
            {
                if (_bbs is BoolSetting _b && !PhotonNetwork.offlineMode)
                {
                    photonView.RPC("SendBoolSettingRPC", PhotonTargets.All, new object[]
                    {
                            _b.Name,
                            _b.m_value,
                            flag
                    });
                }
            }
        }

        private void SendFloatSetting(ModConfig config, bool flag)  //host
        {
            foreach (BBSetting _bbs in config.Settings)
            {
                if (_bbs is FloatSetting _f && !PhotonNetwork.offlineMode)
                {
                    photonView.RPC("SendFloatSettingRPC", PhotonTargets.All, new object[]
                    {
                        _f.Name,
                        _f.m_value,
                        flag
                    });
                }
            }
        }

        private void SendSyncSettings(ModConfig config, bool flag)  //host
        {
            SendBoolSetting(config, flag);
            SendFloatSetting(config, flag);
        }

        private IEnumerator SetPlayerSyncInfoCO()  //host
        {
            while (!NetworkLevelLoader.Instance.AllPlayerDoneLoading)
            {
                yield return new WaitForSeconds(0.2f);
            }

            SendSyncSettings(AutoScaleDifficulty.AutoScaleDiff_Config, true);

            if (!PhotonNetwork.offlineMode)
            {
                photonView.RPC("SetPlayerSyncInfoRPC", PhotonTargets.All, new object[0]);
            }
        }

        private IEnumerator SetAISyncInfoCO()  //host
        {
            while (!NetworkLevelLoader.Instance.AllPlayerDoneLoading)
            {
                yield return new WaitForSeconds(0.2f);
            }

            SendSyncSettings(AutoScaleDifficulty.AIConfig, false);

            if (!PhotonNetwork.offlineMode)
            {
                photonView.RPC("SetAISyncInfoRPC", PhotonTargets.All, new object[0]);
            }
        }

        [PunRPC]
        private void SendBoolSettingRPC(string name, bool value, bool flag)  //client
        {
            if (PhotonNetwork.isNonMasterClientInRoom)
            {
                StatManager.Instance.SetSyncBoolInfo(name, value, flag);
            }
        }

        [PunRPC]
        private void SendFloatSettingRPC(string name, float value, bool flag)  //client
        {
            if (PhotonNetwork.isNonMasterClientInRoom)
            {
                StatManager.Instance.SetSyncFloatInfo(name, value, flag);
            }
        }

        [PunRPC]
        private void PlayerSyncRPC()  //client
        {
            StatManager.Instance.CurrentPlayerSyncInfo = null;
        }

        [PunRPC]
        private void SetPlayerSyncInfoRPC()  //client
        {
            if (PhotonNetwork.isNonMasterClientInRoom)
            {
                StatManager.Instance.SetPlayerSyncInfo();
            }
        }

        [PunRPC]
        private void AISyncRPC()  //client
        {
            StatManager.Instance.CurrentAISyncInfo = null;
        }

        [PunRPC]
        private void SetAISyncInfoRPC()  //client
        {
            if (PhotonNetwork.isNonMasterClientInRoom)
            {
                StatManager.Instance.SetAISyncInfo();
            }
        }
    }
}
