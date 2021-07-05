using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LineCommander;
using PenAndPaper.Commands;

namespace PenAndPaper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Pen and Paper, the greatest command line tool for Dungeons and Dragons!");
            Console.WriteLine("Type a command to get started. Say help (or just h for short) if you need help at any point.");

            var commands = new List<ICommand>() { new New() };
            var commander = new Commander();
            await commander.AddCommands(commands);
            await commander.ListenForCommands();
        }
    }
}
