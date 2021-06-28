using System;
using System.Collections.Generic;
using System.Threading;

namespace PenAndPaper.Entities
{
    public class AbilityScores
    {       
        public int Strength => _values[AbilityScore.Strength];
        public int Dexterity => _values[AbilityScore.Dexterity];
        public int Constitution => _values[AbilityScore.Constitution];
        public int Wisdom => _values[AbilityScore.Wisdom];
        public int Intelligence => _values[AbilityScore.Intelligence];
        public int Charisma => _values[AbilityScore.Charisma];

        public IEnumerable<AbilityScore> Abilities => _values.Keys;

        private Dictionary<AbilityScore, int> _values = new Dictionary<AbilityScore, int>() 
        {
            { AbilityScore.Strength, 8 },
            { AbilityScore.Dexterity, 8 },
            { AbilityScore.Constitution, 8 },
            { AbilityScore.Wisdom, 8 },
            { AbilityScore.Intelligence, 8 },
            { AbilityScore.Charisma, 8 }
        };

        public void Randomize(int level)
        {
            var extraPoints = 15 + (int)Math.Max(0, level/4);
            
            for (var i=0;i<=extraPoints; i++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                if (extraPoints == i) 
                {
                    Console.WriteLine("--------FINAL STATS---------");
                }
                else
                {
                    Console.WriteLine("");
                }
                var randomAbility = GetRandomAbility();
                Console.WriteLine("Points left: " + (extraPoints - i));
                
                _values[randomAbility]++;

                foreach (AbilityScore ability in (AbilityScore[]) Enum.GetValues(typeof(AbilityScore)))
                {
                    var isChosen = randomAbility == ability;
                    Console.WriteLine(ability + ": " + _values[ability] + (isChosen ? "+1" : ""));
                }
            }
        }
        
        public AbilityScore GetRandomAbility()
        {
            Random rng = new Random();
            var random = rng.Next((int)AbilityScore.Strength, (int)AbilityScore.Charisma);
            return (AbilityScore)random;
        }

        public enum AbilityScore 
        {
            Strength = 1,
            Dexterity = 2,
            Constitution = 3,
            Wisdom = 4,
            Intelligence = 5,
            Charisma = 6
        }
    }
}