using System;
using System.Collections.Generic;

namespace Compiler
{

    enum VarType { VOID, BOOL, INT, STRING }
	enum VarScope {GLOBAL, STACK, ARG}
    public class Variable
    {
        public String name;
        public Object value;
        public VarType type;
        public int size;

		public Variable(String name, VarType type) {
			this.name = name;
			this.type = type;
			size = 4;
		}
    }
    public class SymbolTable
    {
        Stack<Dictionary<String, Tuple<Variable, int>>> table;

        public int shift = 0;
        int paramShift = 0;

        public SymbolTable()
        {
            table = new Stack<Dictionary<String, Tuple<Variable, int>>>();
            table.Push(new Dictionary<String, Tuple<Variable, int>>());
        }

        public bool AddGlobalVariable(Variable var)
        {
            if (table.Peek().ContainsKey(var.name))
                return false;
            table.Peek().Add(var.name, new Tuple<Variable, int>(var, -2));
            return true;
        }

        public bool addStackVariable(Variable var)
        {
            if (table.Peek().ContainsKey(var.name))
                return false;
            table.Peek().Add(var.name, new Tuple<Variable, int>(var, shift));
            shift += var.size;
            return true;
        }

        public bool addFunctionParameter(Variable var)
        {
            if (table.Count == 1)
            {
                paramShift -= var.size;
                table.Peek().Add(var.name, new Tuple<Variable, int>(var, paramShift));
                return true;
            }
            return false;
        }

        public void addScope()
        {
            table.Push(new Dictionary<string, Tuple<Variable, int>>());
        }

        public void removeScope()
        {
            table.Pop();
            if (table.Count <= 1)
            {
                shift = 0;
                paramShift = 0;
            }
        }

		public Variable getVariable(String name) {
			Tuple<Variable, int> v;
			foreach (var d in table)
			{
				if (d.TryGetValue(name, out v))
					return v.Item1;
			}
			return null;
		}

        public int getVarOffset(String name)
        {
            Tuple<Variable, int> v;
            foreach (var d in table)
            {
                if (d.TryGetValue(name, out v))
                    return -v.Item2 - 4;
            }
            return -1;
        }

		public VarScope getVarScope(String name) {
			return null;
		}

		public bool setVarValue(Object val) {
			return true;
		}
    }
}