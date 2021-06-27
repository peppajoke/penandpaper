using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaper.Menus.Commands;

namespace PenAndPaper.Menus.Commands
{
    public class New : ICommand
    {
        public bool Execute(IEnumerable<string> arguments)
        {
            if (!arguments.Any())
            {
                Console.WriteLine("Please specify pc (player character) or npc (non player character)");
                return true;
            }

            var type = arguments.FirstOrDefault();

            switch(type)
            {
                case "pc":

                   break;
                case "npc":

                    break;
                default:
                
                    Console.WriteLine("Please specify pc (player character) or npc (non player character)");
                    return true;
            }
            
            return true;
        }

        public string Description()
        {
            return "Create something new! Like a player character(pc) or non playable character (npc)!";
        }
    }
}