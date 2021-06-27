using System;
using PenAndPaper.Entities;

namespace PenAndPaper.Builders
{
    public class MortalBuilder : Builder
    {
        public void Append(Mortal mortal)
        {
            mortal._name = InputText("What is the character's name?");
            
            Console.WriteLine("Does the character have a gender? m/f or blank");
            mortal._gender = ParseGender(Console.ReadLine());
        }

        private Gender ParseGender(string input)
        {
            if (input.ToUpper() == "M")
            {
                return Gender.Male;
            }
            if (input.ToUpper() == "F")
            {
                return Gender.Female;
            }
            return Gender.None;
        }
    }


}