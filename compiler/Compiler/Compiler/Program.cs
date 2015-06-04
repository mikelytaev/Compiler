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
			var foutstream = new StreamWriter (args [1]); 
			var input = new AntlrInputStream (fstream);
			var lexer = new graLexer (input);
			var tokens = new CommonTokenStream (lexer);
			var parser = new graParser (tokens);
			MainVisitor vis = new MainVisitor ();
			List<String> code = (List<String>)vis.VisitProgram (parser.program ());

			foreach (String s in code) {
				foutstream.Write (s);
				foutstream.Write (Environment.NewLine);
			}
			foutstream.Close ();
            //Console.Read();
        }
    }
}
