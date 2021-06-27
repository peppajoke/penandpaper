namespace PenAndPaper.Entities
{
    public class NonPlayerCharacter : Mortal
    {
        // less than zero, they attack the players
        // 0-100, they are neutral
        // 100+ they fight FOR the players
        protected int _dispositionToParty = -1;

        public NonPlayerCharacter(
            string name,
            int hp = 1,
            int level = 0
        )
        {
            _name = name;
            _hp = hp;
            _level = level;
       }
    }
}