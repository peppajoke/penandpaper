using System;
using System.Linq;
using PenAndPaper.Entities;

namespace PenAndPaper.Builders
{
    public class PlayerCharacterBuilder : Builder
    {
        public PlayerCharacter Build()
        {
            var character = new PlayerCharacter();
            var mortalBuilder = new MortalBuilder();
            mortalBuilder.Append(character);

            character._level = InputInt("What level should this character be?", 0, 20);

            if (InputBool("Shall I track xp for you?"))
            {
                character._experience = 0;
            }

            if (InputBool("Shall I set ability scores randomly?"))
            {
                character.AbilityScores.Randomize(character._level);
            }
            else
            {
                // replace this with a real ability score builder
                character.AbilityScores.Randomize(character._level);
            }

            if (InputBool("Do you want to add skills that this character has? (example: Intimidation, Persuasion, Stealth)"))
            {
                var addSkills = true;
                while(addSkills)
                {
                    var skill = new Skill();
                    skill.Name = InputText("What's the skill name?");
                    skill.Description = InputText("Can you describe what the skill means?");
                    var abilities = character.AbilityScores.Abilities.Select(x => x.ToString());
                    skill.BaseAbility = (AbilityScores.AbilityScore)Enum.Parse(typeof(AbilityScores.AbilityScore), InputText("What ability score is tied to this skill?", abilities));

                    Console.WriteLine("New Skill: " + skill.Name);
                    Console.WriteLine("Description: " + skill.Description);
                    Console.WriteLine("Related Ability: " + skill.BaseAbility);

                    if (InputBool("Does that look good?"))
                    {
                        character.skills.Add(skill);
                        if (!InputBool("Add another skill?"))
                        {
                            addSkills = false;
                        }
                    }
                }
            }

            if (InputBool("Does this character use a melee weapon?"))
            {
                var meleeWeaponName = InputText("What's the melee weapon called?");
                var ability = InputAbility(character);
                

            }

            // autoattack
            // melee attack to hit +dmg
            // ranged attack to hit +dmg


            // MOVE EVERYTHING BELOW THIS TO SPELL BUILDER
            // add spell/power
            // buff/debuff. Ability mods, disposition mods, 
            // Attack 
            // summon -- punt



            return character;
        }
    }
}