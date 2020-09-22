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
        public static string ModMult { get; private set; } = "Mult";
        public static string FoodDepleteMod { get; private set; } = "FoodDepleteRate";
        public static string DrinkDepleteMod { get; private set; } = "DrinkDepleteRate";
        public static string SleepDepleteMod { get; private set; } = "SleepDepleteRate";
        public static string DetectabilityMod { get; private set; } = "Detectability";
        public static string VisualDetectabilityMod { get; private set; } = "VisualDetectability";
        public static string PouchCapacityMod { get; private set; }  = "PouchCapacity";
        public static string FoodEffectEfficiencyMod { get; private set; } = "FoodEffectEfficiency";
        public static string BuyMod { get; private set; }  = "BuyModifier";
        public static string SellMod { get; private set; } = "SellModifier";
        public static string HealthMod { get; private set; } = "MaxHealth";
        public static string HealthRegenMod { get; private set; } = "HealthRegen";
        public static string HealthBurnMod { get; private set; } = "HealthBurn";
        public static string StaminaMod { get; private set; } = "MaxStamina";
        public static string StaminaRegenMod { get; private set; } = "StaminaRegen";
        public static string StaminaUseMod { get; private set; } = "StaminaUse";
        public static string StaminaCostReducMod { get; private set; } = "StaminaCostReduction";
        public static string StaminaBurnMod { get; private set; } = "StaminaBurn";
        public static string ManaMod { get; private set; } = "MaxMana";
        public static string ManaRegenMod { get; private set; }  = "ManaRegen";
        public static string ManaUseMod { get; private set; }  = "ManaUse";
        public static string ManaBurnMod { get; private set; } = "ManaBurn";
        public static string ImpactMod { get; private set; } = "Impact";
        public static string AllDamagesMod { get; private set; }  = "AllDamages";
        public static string PhysicalDamageMod { get; private set; } = "PhysicalDamage";
        public static string EtherealDamageMod { get; private set; }  = "EtherealDamage";
        public static string DecayDamageMod { get; private set; }  = "DecayDamage";
        public static string ElectricDamageMod { get; private set; } = "ElectricDamage";
        public static string FrostDamageMod { get; private set; }  = "FrostDamage";
        public static string FireDamageMod { get; private set; } = "FireDamage";
        public static string DarkDamageMod { get; private set; }  = "DarkDamage";
        public static string LightDamageMod { get; private set; } = "LightDamage";
        public static string DamageProtectionMod { get; private set; }  = "DamageProtection";
        public static string PhysicalProtectionMod { get; private set; }  = "PhysicalProtection";
        public static string EtherealProtectionMod { get; private set; } = "EtherealProtection";
        public static string DecayProtectionMod { get; private set; } = "DecayProtection";
        public static string ElectricProtectionMod { get; private set; } = "ElectricProtection";
        public static string FrostProtectionMod { get; private set; } = "FrostProtection";
        public static string FireProtectionMod { get; private set; } = "FireProtection";
        public static string DarkProtectionMod { get; private set; } = "DarkProtection";
        public static string LightProtectionMod { get; private set; } = "LightProtection";
        public static string AllResistancesMod { get; private set; } = "AllResistances";
        public static string DamageResistanceMod { get; private set; } = "DamageResistance";
        public static string PhysicalResistanceMod { get; private set; } = "PhysicalResistance";
        public static string EtherealResistanceMod { get; private set; } = "EtherealResistance";
        public static string DecayResistanceMod { get; private set; } = "DecayResistance";
        public static string ElectricResistanceMod { get; private set; } = "ElectricResistance";
        public static string FrostResistanceMod { get; private set; } = "FrostResistance";
        public static string FireResistanceMod { get; private set; } = "FireResistance";
        public static string DarkResistanceMod { get; private set; } = "DarkResistance";
        public static string LightResistanceMod { get; private set; } = "LightResistance";
        public static string ImpactResistanceMod { get; private set; } = "ImpactResistance";
        public static string StabilityRegenMod { get; private set; } = "StabilityRegen";
        public static string EnvColdProtectionMod { get; private set; } = "EnvColdProtection";
        public static string EnvHeatProtectionMod { get; private set; } = "EnvHeatProtection";
        public static string ColdRegenMod { get; private set; } = "ColdRegen";
        public static string HeatRegenMod { get; private set; } = "HeatRegen";
        public static string WaterproofMod { get; private set; } = "Waterproof";
        public static string CorruptionResistanceMod { get; private set; } = "CorruptionResistance";
        public static string TemperatureMod { get; private set; } = "TemperatureModifier";
        public static string MoveSpeedMod { get; private set; } = "MovementSpeed";
        public static string SpeedMod { get; private set; } = "Speed";
        public static string AttackSpeedMod { get; private set; } = "AttackSpeed";
        public static string DodgeInvulnerabilityMod { get; private set; } = "DodgeInvulnerabilityModifier";
        public static string SkillCooldownMod { get; private set; } = "SkillCooldownModifier";

        //stat sections
        public static string FoodDepleteSection { get; private set; } = "Food Depletion Rate";
        public static string DrinkDepleteSection { get; private set; } = "Drink Depletion Rate";
        public static string SleepDepleteSection { get; private set; } = "Sleep Depletion Rate";
        public static string DetectabilitySection { get; private set; } = "Detectability";
        public static string VisualDetectabilitySection { get; private set; } = "Visual Detectability";
        public static string PouchCapacitySection { get; private set; } = "Pouch Capacity";
        public static string FoodEffectEfficiencySection { get; private set; } = "Food Efficiency";
        public static string BuySection { get; private set; } = "Buying Rate";
        public static string SellSection { get; private set; } = "Selling Rate";
        public static string HealthSection { get; private set; } = "Maximum Health";
        public static string HealthRegenSection { get; private set; } = "Health Regeneration";
        public static string HealthBurnSection { get; private set; } = "Health Burn Rate";
        public static string StaminaSection { get; private set; } = "Maximum Stamina";
        public static string StaminaRegenSection { get; private set; } = "Stamina Regeneration";
        public static string StaminaUseSection { get; private set; } = "Stamina Usage Rate";
        public static string StaminaCostSection { get; private set; } = "Stamina Cost Reduction";
        public static string StaminaBurnSection { get; private set; } = "Stamina Burn Rate";
        public static string ManaSection { get; private set; } = "Maximum Mana";
        public static string ManaRegenSection { get; private set; } = "Mana Regeneration";
        public static string ManaUseSection { get; private set; } = "Mana Usage Rate";
        public static string ManaBurnSection { get; private set; } = "Mana Burn Rate";
        public static string ImpactSection { get; private set; } = "Impact Damage";
        public static string AllDamagesSection { get; private set; } = "All Damages";
        public static string PhysicalDamageSection { get; private set; } = "Physical Damage";
        public static string EtherealDamageSection { get; private set; } = "Ethereal Damage";
        public static string DecayDamageSection { get; private set; } = "Decay Damage";
        public static string ElectricDamageSection { get; private set; } = "Electric Damage";
        public static string FrostDamageSection { get; private set; } = "Frost Damage";
        public static string FireDamageSection { get; private set; } = "Fire Damage";
        public static string DarkDamageSection { get; private set; } = "Dark Damage";
        public static string LightDamageSection { get; private set; } = "Light Damage";
        public static string DamageProtectionSection { get; private set; } = "Damage Protection";
        public static string PhysicalProtectionSection { get; private set; } = "Physical Protection";
        public static string EtherealProtectionSection { get; private set; } = "Ethereal Protection";
        public static string DecayProtectionSection { get; private set; } = "Decay Protection";
        public static string ElectricProtectionSection { get; private set; } = "Electric Protection";
        public static string FrostProtectionSection { get; private set; } = "Frost Protection";
        public static string FireProtectionSection { get; private set; } = "Fire Protection";
        public static string DarkProtectionSection { get; private set; } = "Dark Protection";
        public static string LightProtectionSection { get; private set; } = "Light Protection";
        public static string AllResistancesSection { get; private set; } = "All Resistances";
        public static string DamageResistanceSection { get; private set; } = "Damage Resistance";
        public static string PhysicalResistanceSection { get; private set; } = "Physical Resistance";
        public static string EtherealResistanceSection { get; private set; } = "Ethereal Resistance";
        public static string DecayResistanceSection { get; private set; } = "Decay Resistance";
        public static string ElectricResistanceSection { get; private set; } = "Electric Resistance";
        public static string FrostResistanceSection { get; private set; } = "Frost Resistance";
        public static string FireResistanceSection { get; private set; } = "Fire Resistance";
        public static string DarkResistanceSection { get; private set; } = "Dark Resistance";
        public static string LightResistanceSection { get; private set; } = "Light Resistance";
        public static string ImpactResistanceSection { get; private set; } = "Impact Resistance";
        public static string StabilityRegenSection { get; private set; } = "Stability Regeneration";
        public static string EnvColdProtectionSection { get; private set; } = "Cold Weather Protection";
        public static string EnvHeatProtectionSection { get; private set; } = "Hot Weather Protection";
        public static string ColdRegenSection { get; private set; } = "Cold Temp. Regeneration";
        public static string HeatRegenSection { get; private set; } = "Hot Temp. Regeneration";
        public static string WaterproofSection { get; private set; } = "Wet Weather Protection";
        public static string CorruptionResistanceSection { get; private set; } = "Corruption Resistance";
        public static string TemperatureSection { get; private set; } = "Temperature Rate";
        public static string MoveSpeedSection { get; private set; } = "Movement Speed";
        public static string SpeedSection { get; private set; } = "Speed";
        public static string AttackSpeedSection { get; private set; } = "Attack Speed";
        public static string DodgeInvulnerabilitySection { get; private set; } = "Dodge Rate";
        public static string SkillCooldownSection { get; private set; } = "Skill Cooldown Rate";

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
                Name = FoodDepleteMod + ModMult,
                SectionTitle = FoodDepleteSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = FoodDepleteMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DrinkDepleteMod + ModMult,
                SectionTitle = DrinkDepleteSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = DrinkDepleteMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = SleepDepleteMod + ModMult,
                SectionTitle = SleepDepleteSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = SleepDepleteMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = FoodEffectEfficiencyMod + ModMult,
                SectionTitle = FoodEffectEfficiencySection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = FoodEffectEfficiencyMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = PouchCapacityMod + ModMult,
                SectionTitle = PouchCapacitySection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = PouchCapacityMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = BuyMod + ModMult,
                SectionTitle = BuySection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = BuyMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = SellMod + ModMult,
                SectionTitle = SellSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = SellMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
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
                Name = TemperatureMod + ModMult,
                SectionTitle = TemperatureSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = TemperatureMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = WaterproofMod + ModMult,
                SectionTitle = WaterproofSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = WaterproofMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = EnvColdProtectionMod + ModMult,
                SectionTitle = EnvColdProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = EnvColdProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = ColdRegenMod + ModMult,
                SectionTitle = ColdRegenSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = ColdRegenMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = EnvHeatProtectionMod + ModMult,
                SectionTitle = EnvHeatProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = EnvHeatProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = HeatRegenMod + ModMult,
                SectionTitle = HeatRegenSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = HeatRegenMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = SpeedMod + ModMult,
                SectionTitle = SpeedSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = SpeedMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
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
            new BoolSetting
            {
                Name = AttackSpeedMod + ModMult,
                SectionTitle = AttackSpeedSection,
                Description = MultDesc,
                DefaultValue = true
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
            new BoolSetting
            {
                Name = StabilityRegenMod + ModMult,
                SectionTitle = StabilityRegenSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = DodgeInvulnerabilityMod + ModMult,
                SectionTitle = DodgeInvulnerabilitySection,
                Description = MultDesc,
                DefaultValue = true
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
            new BoolSetting
            {
                Name = SkillCooldownMod + ModMult,
                SectionTitle = SkillCooldownSection,
                Description = MultDesc,
                DefaultValue = true
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
            new BoolSetting
            {
                Name = HealthMod + ModMult,
                SectionTitle = HealthSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = HealthRegenMod + ModMult,
                SectionTitle = HealthRegenSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = HealthBurnMod + ModMult,
                SectionTitle = HealthBurnSection,
                Description =  MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = HealthBurnMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = StaminaMod + ModMult,
                SectionTitle = StaminaSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = StaminaRegenMod + ModMult,
                SectionTitle = StaminaRegenSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = StaminaUseMod + ModMult,
                SectionTitle = StaminaUseSection,
                Description = MultDesc,
                DefaultValue = true
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
            new BoolSetting
            {
                Name = StaminaCostReducMod + ModMult,
                SectionTitle = StaminaCostSection,
                Description = MultDesc,
                DefaultValue = true
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
            new BoolSetting
            {
                Name = StaminaBurnMod + ModMult,
                SectionTitle = StaminaBurnSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = StaminaBurnMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = ManaMod + ModMult,
                Description = MultDesc,
                SectionTitle = ManaSection,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = ManaRegenMod + ModMult,
                SectionTitle = ManaRegenSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = ManaUseMod + ModMult,
                SectionTitle = ManaUseSection,
                Description = MultDesc,
                DefaultValue = true
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
            new BoolSetting
            {
                Name = ManaBurnMod + ModMult,
                SectionTitle = ManaBurnSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = ManaBurnMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = AllDamagesMod + ModMult,
                SectionTitle = AllDamagesSection,
                Description = MultDesc,
                DefaultValue = true
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
            new BoolSetting
            {
                Name = PhysicalDamageMod + ModMult,
                SectionTitle = PhysicalDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = PhysicalDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = ImpactMod + ModMult,
                SectionTitle = ImpactSection,
                Description = MultDesc,
                DefaultValue = true,
            },
            new FloatSetting
            {
                Name = ImpactMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = EtherealDamageMod + ModMult,
                SectionTitle = EtherealDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = EtherealDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DecayDamageMod + ModMult,
                SectionTitle = DecayDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = DecayDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = ElectricDamageMod + ModMult,
                SectionTitle = ElectricDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = ElectricDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = FrostDamageMod + ModMult,
                SectionTitle = FrostDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = FrostDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = FireDamageMod + ModMult,
                SectionTitle = FireDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = FireDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DarkDamageMod + ModMult,
                SectionTitle = DarkDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = DarkDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = LightDamageMod + ModMult,
                SectionTitle = LightDamageSection,
                Description = MultDesc,
                DefaultValue = true
            },
            new FloatSetting
            {
                Name = LightDamageMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DamageProtectionMod + ModMult,
                SectionTitle = DamageProtectionSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = PhysicalProtectionMod + ModMult,
                SectionTitle = PhysicalProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = PhysicalProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = EtherealProtectionMod + ModMult,
                SectionTitle = EtherealProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = EtherealProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DecayProtectionMod + ModMult,
                SectionTitle = DecayProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = DecayProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = ElectricProtectionMod + ModMult,
                SectionTitle = ElectricProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = ElectricProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = FrostProtectionMod + ModMult,
                SectionTitle = FrostProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = FrostProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = FireProtectionMod + ModMult,
                SectionTitle = FireProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = FireProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DarkProtectionMod + ModMult,
                SectionTitle = DarkProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = DarkProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = LightProtectionMod + ModMult,
                SectionTitle = LightProtectionSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = LightProtectionMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = AllResistancesMod + ModMult,
                SectionTitle = AllResistancesSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = AllResistancesMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DamageResistanceMod + ModMult,
                SectionTitle = DamageResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = DamageResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = CorruptionResistanceMod + ModMult,
                SectionTitle = CorruptionResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = CorruptionResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = PhysicalResistanceMod + ModMult,
                SectionTitle = PhysicalResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = PhysicalResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = ImpactResistanceMod + ModMult,
                SectionTitle = ImpactResistanceSection,
                Description = MultDesc,
                DefaultValue = false
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
            new BoolSetting
            {
                Name = EtherealResistanceMod + ModMult,
                SectionTitle = EtherealResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = EtherealResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DecayResistanceMod + ModMult,
                SectionTitle = DecayResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = DecayResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = ElectricResistanceMod + ModMult,
                SectionTitle = ElectricResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = ElectricResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = FrostResistanceMod + ModMult,
                SectionTitle = FrostResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = FrostResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = FireResistanceMod + ModMult,
                SectionTitle = FireResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = FireResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = DarkResistanceMod + ModMult,
                SectionTitle = DarkResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = DarkResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            },
            new BoolSetting
            {
                Name = LightResistanceMod + ModMult,
                SectionTitle = LightResistanceSection,
                Description = MultDesc,
                DefaultValue = false
            },
            new FloatSetting
            {
                Name = LightResistanceMod,
                Description = ModDesc,
                DefaultValue = 0f,
                MinValue = -500f,
                MaxValue = 500f,
                RoundTo = 0
            }
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
