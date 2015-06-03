using System;
using System.Collections.Generic;

namespace Compiler
{

    public enum VarType { VOID, BOOL, INT, STRING }
	public enum VarScope {GLOBAL, STACK, ARG}
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
			shift += var.size;
            table.Peek().Add(var.name, new Tuple<Variable, int>(var, shift));
            return true;
        }

		public void addUnion(String[] vars) {
			Dictionary<String, Tuple<Variable, int>> curS = table.Pop ();
			Tuple<Variable, int> v;
			foreach (String s in vars) {
				if (curS.TryGetValue (s, out v))
					shift = Math.Min (shift, v.Item2);
			}
			foreach (String s in vars) {
				if (curS.TryGetValue (s, out v)) {
					Tuple<Variable, int> t = new Tuple<Variable, int>(v.Item1, shift); //shame
					curS.Remove (s);
					curS.Add (s, t);
				}
			}
			table.Push (curS);
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
                    return -v.Item2;
            }
            return -1;
        }

		public VarScope getVarScope(String name) {
			return VarScope.STACK;
		}

		public void Assign(String name, Object o) {
			Dictionary<String, Tuple<Variable, int>> curS = table.Peek ();
			Tuple<Variable, int> v;
			if (curS.TryGetValue (name, out v)) {
				Variable tv = v.Item1;
				tv.value = o;
				Tuple<Variable, int> t = new Tuple<Variable, int> (tv, v.Item2);
				curS.Remove (name);
				curS.Add (name, t);
				return;
			} else {
				foreach (var d in table)
				{
					if (d.TryGetValue (name, out v)) {
						Variable tv = v.Item1;
						tv.value = null;
						Tuple<Variable, int> t = new Tuple<Variable, int> (tv, v.Item2);
						curS.Remove (name);
						curS.Add (name, t);
						return;
					}
				}
			}
				
		}
    }
}