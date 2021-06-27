using System.Collections.Generic;

namespace PenAndPaper.Menus.Commands
{
    public interface ICommand
    {
        bool Execute(IEnumerable<string> arguments);
        string Description();
    }
}