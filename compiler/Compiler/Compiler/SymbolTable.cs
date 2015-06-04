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
        Dictionary<String, Variable> global;

        public int shift = 0;
        int paramShift = -8;

        public SymbolTable()
        {
            table = new Stack<Dictionary<String, Tuple<Variable, int>>>();
            global = new Dictionary<string,Variable>();
            table.Push(new Dictionary<String, Tuple<Variable, int>>());
        }

        public bool AddGlobalVariable(Variable var)
        {
            if (global.ContainsKey(var.name))
                return false;
            global.Add(var.name, var);
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
            if (table.Count == 2)
            {
                table.Peek().Add(var.name, new Tuple<Variable, int>(var, paramShift));
                paramShift -= var.size;
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
                paramShift = -8;
            }
        }

		public Variable getVariable(String name) {
			Tuple<Variable, int> v;
			foreach (var d in table)
			{
				if (d.TryGetValue(name, out v))
					return v.Item1;
			}
            Variable v2;
            if (global.TryGetValue(name, out v2))
                return v2;
			return null;
		}

        public String getVarOffset(String name)
        {
            Tuple<Variable, int> v;
            foreach (var d in table)
            {
                if (d.TryGetValue(name, out v))
                {
                    if (-v.Item2 >= 0)
                        return "+" + (-v.Item2).ToString();
                    return (-v.Item2).ToString();
                }
                    
            }
            return "";
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

        public List<Tuple<String, String>> getGlobalStrings()
        {
            var list = new List<Tuple<String, String>>();
            Dictionary<String, Tuple<Variable, int>> curS = table.Peek();
            Tuple<Variable, int> v;
            foreach (var d in curS)
            {
                if (d.Value.Item1.type == VarType.STRING) {
                    list.Add(new Tuple<String, String>(d.Key, (String)d.Value.Item1.value));
                }
            }

            foreach (var d in global)
            {
                if (d.Value.type == VarType.STRING)
                {
                    list.Add(new Tuple<String, String>(d.Key, (String)d.Value.value));
                }
            }

            return list;
        }

        public List<int> getStringsOffset()
        {
            List<int> l = new List<int>();
            Dictionary<String, Tuple<Variable, int>> curS = table.Peek();
            foreach (var d in curS)
            {
                if (d.Value.Item1.type == VarType.STRING)
                {
                    l.Add(d.Value.Item2);
                }
            }
            return l;
        }
    }
}