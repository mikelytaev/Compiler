using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
			var fstream = new FileStream (args [0], FileMode.Open); 
			var input = new AntlrInputStream (fstream);
			var lexer = new graLexer (input);
			var tokens = new CommonTokenStream (lexer);
			var parser = new graParser (tokens);
			var tree = parser.program ();
			System.Console.Out.Write (tree.GetChild(0).GetChild(0).GetText());
        }
    }
}
