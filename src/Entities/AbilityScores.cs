namespace PenAndPaper.Entities
{
    public class AbilityScores
    {
        
        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Wisdom;
        public int Intelligence;
        public int Charisma;

        public void Randomize(int level)
        {
            Strength = 8;
            Dexterity = 8;
            Constitution = 8;
            Wisdom = 8;
            Intelligence = 8;
            Charisma = 8;
            // add 15 points randomly
            // 
        }
    }
}