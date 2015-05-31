using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Node
    {
        protected
        Node left, right;

        public Node(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }
        public Object TryEval();
        public String GenerateCode(int ebpOffset);
    }

    class VarNode : Node
    {
        public Variable var;
        public VarNode(Variable v)
            : base(null, null)
        {
            var = v;
        }

        public Object TryEval()
        {
            return var.value;
        }
    }

    class ValNode : Node
    {
        public Object val;
        public ValNode(Object v)
            : base(null, null)
        {
            val = v;
        }

        public Object TryEval()
        {
            return val;
        }

        public String GenerateCode(int ebpOffset)
        {
            String code;
            if (val is Boolean)
            {
                code += "mov eax"
                return "push " + ((Boolean)val ? '1' : '0') + '\n';
            }
            if (val is int)
                return "push " + val.ToString() + '\n';                
            return null;
        }
    }

    class StringNode : Node
    {
        public String val;
        public String dataLbl;

        public Object TryEval()
        {
            return val;
        }

        public String GenerateCode()
        {
            return "push" +  dataLbl + "\n";
        }
    }

    class OrNode : Node
    {
        public OrNode(Node left, Node right) : base(left, right) { }
        public Object TryEval()
        {
            var le = left.TryEval();
            var re = left.TryEval();

            if (le is Boolean && re is Boolean)
            {
                return (Boolean)le | (Boolean)re;
            }
            return null;
        }
    }
    class Expression
    {
        public String GenerateCode()
        {
            return null;
        }
    }
}
