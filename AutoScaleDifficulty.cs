using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SharedModConfig;

namespace AutoScaleDifficulty
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(DEPENDENT, BepInDependency.DependencyFlags.HardDependency)]
    public class AutoScaleDifficulty : BaseUnityPlugin
    {
        //Credits to theinterstice for providing foundation from AutoScaleDifficulty mod
        public const string GUID = "com.daimyo.AutoScaleDifficulty";
        public const string NAME = "AutoScaleDifficulty";
        public const string VERSION = "1.0.0";
        public const string DEPENDENT = SharedModConfig.SharedModConfig.GUID;

        public static AutoScaleDifficulty Instance { get; private set; }
        public static ModConfig AutoScaleDiff_Config { get; private set; }
        public static ModConfig AIConfig { get; private set; }

        internal void Awake()
        {
            Instance = this;

            var _obj = gameObject;
            _obj.AddComponent<StatManager>();
            _obj.AddComponent<RPCManager>();

            var _harmony = new Harmony(GUID);
            _harmony.PatchAll();
        }

        internal void Start()
        {
            AutoScaleDiff_Config = SetupConfig();
            AutoScaleDiff_Config.Register();

            Logger.Log(LogLevel.Message, $"{ NAME } v{ VERSION } initialized!");
        }

        private ModConfig SetupConfig()
        {
            List<BBSetting> _bbs = new List<BBSetting>();
            /*
            if (flag == Settings.AIStatsTitle)
            {
                var _settings = new Settings();
                _bbs.AddRange(_settings.RulesSettings);
                _bbs.AddRange(_settings.CharacterSettings);
            }

            if (flag == Settings.PlayerStatsTitle)
            {
                var _settings = new Settings();
                _bbs.AddRange(_settings.RulesSettings);
                _bbs.AddRange(_settings.PlayerSettings);
                _bbs.AddRange(_settings.CharacterSettings);
            }
            */
            ModConfig _config = new ModConfig
            {
                ModName = Settings.ModName + flag,
                SettingsVersion = 1.0,
                Settings = _bbs
            };

            return _config;
        }
    }
}
