namespace PenAndPaper.Entities
{
    public class PlayerCharacter : Mortal
    {
        PlayerClass _playerClass;
        int level = 1;

        int maxHp = 10; // todo: make this derived

        public int _experience = -1;
    }
}