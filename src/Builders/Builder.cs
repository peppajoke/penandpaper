using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaper.Entities;
using static PenAndPaper.Entities.AbilityScores;

namespace PenAndPaper.Builders
{
    public abstract class Builder
    {
        public int InputInt(string message, int min, int max)
        {
            Console.WriteLine(message);
            int response;
            Int32.TryParse(Console.ReadLine(), out response);
            if (response < min)
            {
                X();
                return InputInt(message, min, max);
            }
            if (response > max)
            {
                X();
                return InputInt(message, min, max);
            }
            return response;
        }

        public string InputText(string message, bool required = true, int maxLength = 25)
        {
            Console.Write(message);
            Console.WriteLine(( required ? " (required) " : " ") + "max length: " + maxLength);
            var response = Console.ReadLine();
            if (required && String.IsNullOrEmpty(response))
            {
                X();
                return InputText(message, required, maxLength);
            }

            if (maxLength < response.Length)
            {
                X();
                return InputText(message, required, maxLength);
            }
            return response;
        }

        public string InputText(string message, IEnumerable<string> whitelist)
        {
            Console.WriteLine(message);
            Console.Write(" (options: " + String.Join(',' ,whitelist) );
            var response = Console.ReadLine();
            if (!whitelist.Contains(response))
            {
                X();
                return InputText(message, whitelist);
            }
            return response;
        } 

        public bool InputBool(string message)
        {
            Console.WriteLine(message + " y/n");
            var response = Console.ReadLine().ToUpper();
            if (response == "Y" || response == "YES")
            {
                return true;
            }
            if (response == "N" || response == "NO")
            {
                return false;
            }
            X();
            return InputBool(message);
        }

        public AbilityScore InputAbility(Mortal mortal)
        {
            var abilities = mortal.AbilityScores.Abilities.Select(x => x.ToString());
            return (AbilityScores.AbilityScore)Enum.Parse(typeof(AbilityScores.AbilityScore), InputText("What ability score is this tied to?", abilities));
        }

        private void X()
        {
            Console.WriteLine("I didn't understand that. Try again?");
        }
    }
}