using BepInEx.Bootstrap;
using BepInEx.Configuration;
using EntityStates;
using EntityStates.Captain.Weapon;
using RiskOfOptions.Components.Options;
using RoR2;
using RoR2.Projectile;
using RoR2.Skills;
using SkillsPlusPlus;
using SkillsPlusPlus.Modifiers;
using UnityEngine;

namespace PenisSeeker;

public class PenisSeekerUpgrade
{
    [SkillLevelModifier("PENISBLAST", typeof(PENISBLAST))]
    class PenisBlastModifier : SimpleSkillModifier<PENISBLAST> {
        public override void OnSkillEnter(PENISBLAST skillState, int level)
        {
            skillState.force = AdditiveScaling(3075f, 3075f * forceScaling.Value, level);
            if (skillState.projectileprefab.TryGetComponent(out ProjectileExplosion explode))
            {
                Log.Debug(explode.blastRadius);
                explode.blastRadius = AdditiveScaling(7, radiusScaling.Value, level);
            }
            base.OnSkillEnter(skillState, level);
            
            // skillState.projectileprefab.transform.localScale = new Vector3(
            //     AdditiveScaling(1, 0.25f, level), 
            //     AdditiveScaling(1, 0.25f, level),
            //     AdditiveScaling(1, 0.25f, level));
        }

        public override void OnSkillLeveledUp(int level, CharacterBody characterBody, SkillDef skillDef)
        {
            base.OnSkillLeveledUp(level, characterBody, skillDef);
        }

        public override void OnSkillExit(PENISBLAST skillState, int level)
        {
            base.OnSkillExit(skillState, level);
        }

        public override void SetupConfig(ConfigFile config)
        {
            base.SetupConfig(config);
            
            forceScaling = config.Bind("Skills++ Config",
                "force scaling", 
                .30f, 
                "how much force in percent to add per level !!");
            
            radiusScaling = config.Bind("Skills++ Config",
                "blast radius scaling", 
                2f, 
                "how much to increase blast radius by each level (skill is 7m and adds 2m by default !!");

            if (!PenisSeekerPlugin.ROOInstalled) return;
            
            RiskOfOptions.OptionConfigs.StepSliderConfig forceScalingSliderConfig = new RiskOfOptions.OptionConfigs.StepSliderConfig()
            {
                min = 0f,
                max = 2f,
                FormatString = "{0}%"
            };
            RiskOfOptions.ModSettingsManager.AddOption(new RiskOfOptions.Options.StepSliderOption(forceScaling, forceScalingSliderConfig));
                
            RiskOfOptions.OptionConfigs.StepSliderConfig radiusScalingSliderConfig = new RiskOfOptions.OptionConfigs.StepSliderConfig()
            {
                min = 0f,
                max = 15f,
                FormatString = "{0:0}"
            };
            RiskOfOptions.ModSettingsManager.AddOption(new RiskOfOptions.Options.StepSliderOption(radiusScaling, radiusScalingSliderConfig));
        }

        private ConfigEntry<float> forceScaling;
        private ConfigEntry<float> radiusScaling;
    }
}