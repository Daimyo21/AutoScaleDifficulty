using System.Collections.Generic;
using SharedModConfig;

namespace AutoScaleDifficulty
{
    public class Settings
    {
        //mod naming
        public static string ModName { get; private set; } = "AutoScaleDifficulty";
        public static string PlayerStatsTitle { get; private set; } = " - Player Stats";
        public static string AIStatsTitle { get; private set; }  = " - AI Stats";

        //rules names
        public static string EnableAutoScaleDifficulty { get; private set; } = "EnableAutoScaleDifficulty";
        public static string GameBehaviour { get; private set; } = "GameBehaviour";
        public static string StrictMinimum { get; private set; } = "StrictMinimum";

        //rules section
        public static string AutoScaleDiff_Title { get; private set; } = "Enable Auto Scale Difficulty";
        public static string BehaviourSection { get; private set; } = "Enforce Game Behaviour";
        public static string StrictSection { get; private set; }  = "Enforce Strict Minimums";

        //descriptors
        public static string MultDesc { get; private set; } = "Is a percent modifier?";
        public static string ModDesc { get; private set; } = "Modifier value: ";
        public static string AutoScaleDiff_Desc { get; private set; }  = "Enable Auto Scale Difficulty (Overrides vanilla difficulty)";
        public static string BehaviourDesc { get; private set; } = "Prevents unexpected behaviour to occur. Use with caution!";
        public static string StrictDesc { get; private set; } = "Prevents values from being reduced below zero. Do not touch unless you know what you are doing! (Ignored if Enforce Game Behaviour enabled)";

        //stat stacks
        public static string PlayerStats { get; private set; }  = "PlayerStatStack";
        public static string AIStats { get; private set; } = "AiStatStack";

        //stat minimums
        public static float Minimum { get; private set; } = 0f;
        public static float MinimumMod { get; private set; } = 0.01f;

        //stat names
        //public static string ModMult { get; private set; } = "Mult"; //Toggle Multiplier or Percent Value, important
        public static string DetectabilityMod { get; private set; } = "Detectability";
        public static string VisualDetectabilityMod { get; private set; } = "VisualDetectability";
        public static string HealthMod { get; private set; } = "MaxHealth";
        public static string HealthRegenMod { get; private set; } = "HealthRegen";
        public static string StaminaMod { get; private set; } = "MaxStamina";
        public static string StaminaRegenMod { get; private set; } = "StaminaRegen";
        public static string StaminaUseMod { get; private set; } = "StaminaUse";
        public static string StaminaCostReducMod { get; private set; } = "StaminaCostReduction";
        public static string ManaMod { get; private set; } = "MaxMana";
        public static string ManaRegenMod { get; private set; }  = "ManaRegen";
        public static string ManaUseMod { get; private set; }  = "ManaUse";
        public static string ImpactMod { get; private set; } = "Impact";
        public static string AllDamagesMod { get; private set; }  = "AllDamages";
        public static string DamageProtectionMod { get; private set; }  = "DamageProtection";
        public static string ImpactResistanceMod { get; private set; } = "ImpactResistance";
        public static string StabilityRegenMod { get; private set; } = "StabilityRegen";
        public static string MoveSpeedMod { get; private set; } = "MovementSpeed";
        public static string AttackSpeedMod { get; private set; } = "AttackSpeed";
        public static string DodgeInvulnerabilityMod { get; private set; } = "DodgeInvulnerabilityModifier";
        public static string SkillCooldownMod { get; private set; } = "SkillCooldownModifier";

        //stat sections
        //public static string DetectabilitySection { get; private set; } = "Detectability";



        //rules settings
        public List<BBSetting> RulesSettings { get; private set; } = new List<BBSetting>
        {
            new BoolSetting
            {
                Name = EnableAutoScaleDifficulty,
                SectionTitle = AutoScaleDiff_Title,
                Description = AutoScaleDiff_Desc,
                DefaultValue = true
            },
            new BoolSetting
            {
                Name = GameBehaviour,
                SectionTitle = BehaviourSection,
                Description = BehaviourDesc,
                DefaultValue = true
            },
            new BoolSetting
            {
                Name = StrictMinimum,
                SectionTitle = StrictSection,
                Description = StrictDesc,
                DefaultValue = true
            }
        };

        //stat settings
        public List<BBSetting> PlayerSettings { get; private set; } = new List<BBSetting>
        {
            
            new BoolSetting
            {
                Name = DetectabilityMod + ModMult,
                SectionTitle = DetectabilitySection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = DetectabilityMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = VisualDetectabilityMod + ModMult,
                SectionTitle = VisualDetectabilitySection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = VisualDetectabilityMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            }
        };

        public List<BBSetting> CharacterSettings { get; private set; } = new List<BBSetting>
        {
            
            new BoolSetting
            {
                Name = MoveSpeedMod + ModMult,
                SectionTitle = MoveSpeedSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = MoveSpeedMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = AttackSpeedMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = StabilityRegenMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = DodgeInvulnerabilityMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = SkillCooldownMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = HealthMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = HealthRegenMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = StaminaMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = StaminaRegenMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = StaminaUseMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = StaminaCostReducMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = ManaMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = ManaRegenMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = ManaUseMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = AllDamagesMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            //Look at adding impact resistance
            new FloatSetting
            {
                Name = ImpactMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = DamageProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new FloatSetting
            {
                Name = ImpactResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
        };

        //util
        public static void PseudoRegister(ModConfig config)
        {
            Dictionary<string, BBSetting> _dict = new Dictionary<string, BBSetting>();

            foreach (BBSetting _bbs in config.Settings)
            {
                _dict.Add(_bbs.Name, _bbs);
            }

            AT.SetValue(_dict, typeof(ModConfig), config, "m_Settings");
        }
    }
}
