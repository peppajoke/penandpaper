namespace PenAndPaper.Entities
{
    interface IMortal
    {
        bool IsAlive();
        string Name();
    }
    public abstract class Mortal : IMortal
    {
        public string _name;
        public int _hp;
        public int _level;

        public AbilityScores AbilityScores = new AbilityScores();
        public string _race;

        public Gender _gender;
        public bool IsAlive()
        {
            return _hp > 0;
        }

        public string Name()
        {
            return _name;
        }
    }

    public enum Gender 
    {
        Male, Female, None
    }
}