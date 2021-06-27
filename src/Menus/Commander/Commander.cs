using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PenAndPaper.Menus.Commands;

namespace PenAndPaper.Menus.Commander
{
    public class Commander
    {
        private Dictionary<string, ICommand> _commands;
        private string _helpText;
        public Commander(IEnumerable<ICommand> commands, string helpText)
        {
            _helpText = helpText;

            _commands = new Dictionary<string, ICommand>();
            foreach (var command in commands)
            {
                var name = command.GetType().Name.ToUpper();
                
                // todo, TRY CATCH THIS to catch overwrites
                _commands.Add(name, command);
            }
        }

        public async Task Listen()
        {
            var keepListening = true;
            while(keepListening)
            {
                var commandText = Console.ReadLine();
                var arguments = commandText.Split(' ').ToList();
                if (!arguments.Any()) 
                {
                    // Exit early if there is no command
                    continue;
                }
                var baseCommand = arguments[0];
                arguments.RemoveAt(0);

                keepListening = await ExecuteCommand(baseCommand, arguments);
            }
        }

        private async Task<bool> ExecuteCommand(string command, List<string> arguments)
        {
            // classify command
            if (command == "h" || command == "help")
            {
                Console.WriteLine(_helpText);
                return true;
            }

            if (command == "quit" || command == "q")
            {
                return false;
            }

            command = command.ToUpper();

            if (_commands.ContainsKey(command))
            {
                return _commands[command].Execute(arguments);
            }
            return true;
        }
    }
}