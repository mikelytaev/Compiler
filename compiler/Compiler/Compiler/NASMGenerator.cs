using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{


    class NASMGenerator
    {
        //Enum State {FUNCTION, } 
        String code;
        Dictionary<String, Function> functions;
        Function curFunction;
        public NASMGenerator()
        {
            functions = new Dictionary<String, Function>();

            code = "extern printf\n";
            code += "extern scanf\n";
            code += "extern strcmp\n";
            code += "extern strcat\n";
            code += "extern strcpy\n";
            code += "section .text\n";
            code += "global main\n";
        }

        public void beginFunctionDef(Function f, int espOffset)
        {
            code += f.name + ":\n";
            code += "push ebp\n";
            code += "mov ebp, esp\n";
            code += "sub esp, " + espOffset.ToString();
            functions.Add(f.name, f);
            curFunction = f;
        }

        public void endFunction() {
            code += "mov esp, ebp\n";
            code += "pop ebp\n";
            code += "ret " + curFunction.getArgsSize().ToString() + '\n';
        }

        public void DefineVar(Variable var)
        {
            
        }

        public void Assignment(int offset, Expression expr)
        {

        }
    }
}
