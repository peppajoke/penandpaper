using System;
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

            return character;
        }
    }
}