using BepInEx.Configuration;
using EntityStates;
using EntityStates.Captain.Weapon;
using RoR2;
using RoR2.Skills;
using SkillsPlusPlus;
using SkillsPlusPlus.Modifiers;
using UnityEngine;

namespace PenisSeeker;

public class PenisSeekerUpgrade
{
    [SkillLevelModifier("PENIS_BLAST_NAME", typeof(PENISBLAST))]
    class PenisBlastModifier : SimpleSkillModifier<PENISBLAST> {
        public override void OnSkillEnter(PENISBLAST skillState, int level)
        {
            skillState.force = MultScaling(3075f, 0.2f, level);
            skillState.projectileprefab.transform.localScale = new Vector3(
                MultScaling(skillState.projectileprefab.transform.localScale.x, 0.2f, level), 
                MultScaling(skillState.projectileprefab.transform.localScale.y, 0.2f, level),
                MultScaling(skillState.projectileprefab.transform.localScale.z, 0.2f, level));
            
            base.OnSkillEnter(skillState, level);
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
        }
    }
}