using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaper.Builders;
using PenAndPaper.Menus.Commands;

namespace PenAndPaper.Menus.Commands
{
    public class New : ICommand
    {
        public bool Execute(IEnumerable<string> arguments)
        {
            if (!arguments.Any())
            {
                Console.WriteLine("ERROR: Must specify new pc (player character) or new npc (non player character)");
                return true;
            }

            var type = arguments.FirstOrDefault();
            var pcBuilder = new PlayerCharacterBuilder();
            switch(type)
            {
                
                case "pc":
                    var character = pcBuilder.Build();
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