using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Compiler
{
	class Function
	{
		int offset = 0;
		Dictionary<String, int> offsets;
		public String name;
		Dictionary<String, Variable> args;
		public List<Variable> argsList;
		public VarType retType;

		public Function(String name) {
			this.name = name;
			offsets = new Dictionary<String, int>();
			args = new Dictionary<String, Variable>();
		}

		public int GetArgsSize() {
			int s = 0;
			foreach (var a in args) {
				s += a.Value.size;
			}
			return s;
		}

		public int AddArg(Variable var) {
			args.Add(var.name, var);
			offsets.Add(var.name, offset);
			offset += var.size;
			return offset;
		}

		public int GetArgOffset(String name) {
			int r;
			offsets.TryGetValue(name, out r);
			return r;
		}

		public Variable[] getArgs() {
			return null;
		}
	}
}


