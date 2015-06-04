using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;

namespace Compiler
{
	public class MainVisitor : graBaseVisitor<Object>
	{
		SymbolTable table;
		Dictionary<String, Function> functions;
		Stack<String> whileBeginLabels, whileEndLabels;
        List<String> stringsOffset;
		int lblCounter = 0;
		int strCounter = 0;
		public MainVisitor ()
		{
			table = new SymbolTable ();
			functions = new Dictionary<string, Function> ();
			whileBeginLabels = new Stack<String>();
			whileEndLabels = new Stack<String> ();
            stringsOffset = new List<String>();
		}

		public override Object VisitProgram([NotNull] graParser.ProgramContext context) {
			List<String> code = new List<String> ();

			code.Add("extern _printf");
			code.Add("extern _scanf");
			code.Add("extern _strcmp");
			code.Add("extern _strcat");
			code.Add("extern _strcpy");
			code.Add("extern _malloc");
			code.Add("extern _memcpy");
			code.Add("extern _free");

			code.Add ("section .text");
			code.Add ("global _main");

			foreach (var g in context.global()) {
				code.AddRange ((List<String>)VisitGlobal (g));
			}

			code.Add (Environment.NewLine);

			code.Add("section .data");
			code.Add("IntF dd \"%d\", 10, 0");
			code.Add("StrF dd \"%s\", 10, 0");
            List<Tuple<String, String>> gSt = table.getGlobalStrings();
            foreach (var v in gSt)
            {
                code.Add(v.Item1 + " dd \"" + v.Item2 + "\" , 0");
            }
			return code;
		}

		public override Object VisitGlobal([NotNull] graParser.GlobalContext context) {
			if (context.functionDefinition () != null) {
				return VisitFunctionDefinition (context.functionDefinition ());
			}
			return null;
		}

		public override Object VisitFunctionDefinition([NotNull] graParser.FunctionDefinitionContext context)
		{
            table.addScope();
            stringsOffset.Clear();
			String funcName = context.Identifier ().ToString ();
            if (funcName == "main")
                funcName = "_main";
			Function f = new Function (funcName);
			f.retType = (VarType)VisitTypeSpecifier (context.typeSpecifier ());
			if (context.parameterList() != null) {
				var pList = (Tuple<VarType, String>[])VisitParameterList (context.parameterList ());
				foreach(var par in pList) {
					var var = new Variable (par.Item2, par.Item1);
					f.AddArg (var);
                    table.addFunctionParameter(var);
				}
			}
            functions.Add(f.name, f);
			List<String> code = new List<string> ();
			code.Add (funcName + ':');
			code.AddRange ((List<String>)VisitFunctionBody (context.functionBody()));
            table.removeScope();
			return code;
		}

		public override Object VisitTypeSpecifier([NotNull] graParser.TypeSpecifierContext context) {
			if (context.Void_type () != null)
				return VarType.VOID;
			if (context.Int_type () != null)
				return VarType.INT;
			if (context.Bool_type () != null)
				return VarType.BOOL;
			if (context.String_type() != null)
				return VarType.STRING;
			return null;
		}

		public override Object VisitParameterList([NotNull] graParser.ParameterListContext context) {
			var pList = new Tuple<VarType, String>[context.typeSpecifier().Length];
			for (int i = 0; i < context.typeSpecifier().Length; i++) {
				pList [i] = new Tuple<VarType, String> ((VarType)VisitTypeSpecifier (context.typeSpecifier (i)), context.Identifier (i).ToString ());
			}
			return pList;
		}

		public override Object VisitFunctionBody([NotNull] graParser.FunctionBodyContext context) {
			List<String> code = new List<string> ();
			code.Add ("push ebp");
			code.Add ("mov ebp, esp");
            List<String> bodyCode = new List<string>();
			foreach (var s in context.statement()) {
				bodyCode.AddRange((List<String>)VisitStatement (s));
			}
            code.Add("sub esp, " + table.shift.ToString());
            code.AddRange(bodyCode);
            if (context.Return() != null)
            {
                var expr = (Tuple<VarType, Object, List<String>>)VisitExpression(context.expression());
                code.AddRange(expr.Item3);
                code.Add("pop eax");
            }
            code.Add("mov ebx, eax");
            foreach (var o in stringsOffset)
            {
                code.Add("push dword [ebp " + o + "]");
                code.Add("call _free");
                code.Add("add esp, 4");
            }
            code.Add("mov eax, ebx");
			code.Add ("mov esp, ebp");
			code.Add ("pop ebp");
			code.Add ("ret");
			return code;
		}

		public override Object VisitStatement([NotNull] graParser.StatementContext context) {
			if (context.declarationIdentifier () != null)
				return VisitDeclarationIdentifier (context.declarationIdentifier ());
			if (context.assignment () != null)
				return VisitAssignment (context.assignment ());
			if (context.functionCall () != null)
				return VisitFunctionCall (context.functionCall ());
			if (context.whileStatement () != null)
				return VisitWhileStatement (context.whileStatement ());
			if (context.compoundStatement() != null)
				return VisitCompoundStatement (context.compoundStatement ());
			if (context.jumpStatement () != null)
				return VisitJumpStatement (context.jumpStatement ());
			if (context.selectionStatement () != null)
				return VisitSelectionStatement (context.selectionStatement ());
			if (context.unionStatement () != null)
				return VisitUnionStatement (context.unionStatement ());
			return null;
		}

		public override object VisitUnionStatement (graParser.UnionStatementContext context)
		{
			String[] names = new string[context.typeSpecifier ().Length];
			for (int i = 0; i < context.typeSpecifier ().Length; i++) {
				names [i] = context.Identifier ()[i].ToString ();
				Variable var = new Variable (names [i], (VarType)VisitTypeSpecifier (context.typeSpecifier ()[i]));
				table.addStackVariable (var);
			}
			table.addUnion (names);
			return new List<String> ();
		}

		public override Object VisitSelectionStatement (graParser.SelectionStatementContext context)
		{
			List<String> code = new List<String> ();
			if (context.If() != null) {
				var expr = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression ()[0]);
				if (expr.Item1 != VarType.BOOL)
					throw new Exception ("condition expression must be boolean");
				var st1 = (List<String>)VisitStatement (context.statement()[0]);
				List<String> st2 = new List<String> ();
				if (context.statement ().Length == 2) {
					st2.AddRange((List<String>)VisitStatement (context.statement()[1]));
				}
				if (expr.Item2 != null && expr.Item2.Equals (true))
					return st1;
				if (expr.Item2 != null && expr.Item2.Equals (false))
					return st2;
				code.AddRange (expr.Item3);
				code.Add ("pop eax");
				code.Add ("cmp eax, 0");
				String l1 = "lbl" + lblCounter.ToString ();
				String l2 = "lbl" + (lblCounter + 1).ToString ();
				lblCounter += 2;
				code.Add ("je " + l1);
				code.AddRange (st1);
				code.Add ("jmp " + l2);
				code.Add (l1 + ":");
				code.AddRange (st2);
				code.Add (l2 + ":");
			}

			if (context.Switch () != null) {
				var expr = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression ()[0]);
				if (expr.Item1 != VarType.INT)
					throw new Exception ("sorry, switch only for integers");
				code.AddRange (expr.Item3);
				String lNext = "";
				String lEnd = "lbl" + lblCounter.ToString ();
				lblCounter++;
				for (int i = 0; i < context.statement ().Length; i++) {
					var expri = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression ()[i+1]);
					code.AddRange (expri.Item3);
					code.Add ("pop eax");
					code.Add ("cmp eax, [esp]");
					lNext = "lbl" + lblCounter.ToString ();
					lblCounter++;
					code.Add ("jne " + lNext);
					code.AddRange ((List<String>)VisitStatement (context.statement () [i]));
					code.Add ("jmp " + lEnd);
					code.Add (lNext + ":");
				}
				code.Add (lEnd + ":");
			}

			return code;
		}

		public override Object VisitJumpStatement([NotNull] graParser.JumpStatementContext context) {
			List<String> code = new List<String>();
			if(context.Break() != null) {
				if(whileEndLabels.Count == 0)
					throw new Exception("what break doing there?");
				code.Add("jmp " + whileEndLabels.Peek());
			}
			if(context.Continue() != null) {
				if(whileEndLabels.Count == 0)
					throw new Exception("what continue doing there?");
				code.Add("jmp " + whileBeginLabels.Peek());
			}

			return code;
		}

		public override Object VisitCompoundStatement([NotNull] graParser.CompoundStatementContext context) {
			List<String> code = new List<String>();
            table.addScope();
			foreach (var s in context.statement()) {
				code.AddRange ((List<String>)VisitStatement (s));
			}
            table.removeScope();
			return code;
		}

		public override Object VisitWhileStatement([NotNull] graParser.WhileStatementContext context) {
            table.addScope();
            List<String> code = new List<String> ();
			var expr = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression ());
			whileBeginLabels.Push ("wslb" + lblCounter.ToString ());
			lblCounter++;
			whileEndLabels.Push ("wsle" + lblCounter.ToString ());
			lblCounter++;

			code.Add (whileBeginLabels.Peek() + ":");
			code.AddRange (expr.Item3);
			code.Add ("pop eax");
			code.Add ("cmp eax, 0");
			code.Add ("je " + whileEndLabels.Peek());
			
			code.AddRange ((List<String>)VisitStatement (context.statement ()));
			
			code.Add ("jmp " + whileBeginLabels.Peek());
			code.Add (whileEndLabels.Peek() + ":");
			whileBeginLabels.Pop ();
			whileEndLabels.Pop ();
            table.removeScope();
			return code;
		}

		public override Object VisitDeclarationIdentifier([NotNull] graParser.DeclarationIdentifierContext context) {
			List<String> code = new List<string> ();
			Variable var = new Variable (context.Identifier ().ToString (), (VarType)VisitTypeSpecifier (context.typeSpecifier ()));
            if (context.expression () != null) {
				var expr = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression ());
				if ((VarType)VisitTypeSpecifier (context.typeSpecifier ()) != expr.Item1)
					throw new Exception ("bad type");
				var.value = expr.Item2;
                if (var.type == VarType.STRING && expr.Item2 != null)
                {
                    var.value = ((String)expr.Item2).Replace("\"", "");
                }
				table.addStackVariable (var);
                if (var.type == VarType.STRING)
                {
                    //code.Add("mov eax, " + var.name);
                    if (expr.Item2 != null)
                        code.AddRange(addStringToHeap((String)expr.Item2));
                    else
                        code.AddRange(expr.Item3);
                    code.Add("pop eax");
                    code.Add("mov dword [ebp " + (table.getVarOffset(var.name)).ToString() + "], eax");
                }
                else
                {
                    if (expr.Item2 != null)
                    {
                        String val;
                        if (expr.Item1 == VarType.BOOL)
                            val = ((bool)expr.Item2) ? "1" : "0";
                        else
                            val = expr.Item2.ToString();
                        code.Add("mov dword [ebp " + (table.getVarOffset(var.name)).ToString() + "], " + val);
                    }
                    else
                    {
                        code.AddRange(expr.Item3);
                        code.Add("pop eax");
                        code.Add("mov dword [ebp " + (table.getVarOffset(var.name)).ToString() + "], eax");
                    }
                }
			} else {
				table.addStackVariable (var);
                if (var.type == VarType.STRING)
                {
                    code.AddRange(addStringToHeap(""));
                    code.Add("pop eax");
                    code.Add("mov [ebp " + table.getVarOffset(var.name).ToString() + "], eax");
                }
			}
            if (var.type == VarType.STRING)
                stringsOffset.Add(table.getVarOffset(var.name));
			return code;
		}

		public override Object VisitAssignment([NotNull] graParser.AssignmentContext context) {
			List<String> code = new List<string> ();
			Variable var = table.getVariable (context.Identifier ().ToString ());
			if (var == null)
				throw new Exception ("variable does not exist in this scope");
			if(context.expression() != null) {
				var expr = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression ());
				if (var.type != expr.Item1)
					throw new Exception ("bad type");
				table.Assign(var.name, expr.Item2);
				if (expr.Item2 != null && expr.Item1 != VarType.STRING) {
					code.Add ("mov dword [ebp " + (table.getVarOffset (var.name)).ToString() + "], " + expr.Item2.ToString());
				} else {
					code.AddRange (expr.Item3);
					code.Add ("pop ebx");
                    code.Add("push dword [ebp " + (table.getVarOffset (var.name)).ToString() + "]");
                    code.Add("call _free");
                    code.Add("add esp, 4");
					code.Add ("mov dword [ebp " + (table.getVarOffset (var.name)).ToString() + "], ebx");
				}
			}
			return code;
		}

		public override Object VisitExpression([NotNull] graParser.ExpressionContext context) {
            var expr = (Tuple<VarType, Object, List<String>>)VisitLogicalOrExpression(context.logicalOrExpression());
            if (expr.Item2 == null)
                return expr;
            List<String> code = new List<String>();
            if (expr.Item1 == VarType.INT)
            {
                code.Add("push " + expr.Item2.ToString());
            }
            if(expr.Item1 == VarType.BOOL)
            {
                code.Add("push " + ((bool)expr.Item2 ? "1" : "0"));
            }
            if (expr.Item1 == VarType.STRING)
            {
                code.AddRange(addStringToHeap(expr.Item2.ToString()));
            }
            return new Tuple<VarType, Object, List<String>>(expr.Item1, expr.Item2, code);
		}

		public override Object VisitLogicalOrExpression([NotNull] graParser.LogicalOrExpressionContext context) {
			if (context.logicalOrExpression () == null) {
				return VisitLogicalAndExpression (context.logicalAndExpression ());
			}
			List<String> code = new List<string> ();
			var left = (Tuple<VarType, Object, List<String>>)VisitLogicalOrExpression (context.logicalOrExpression());//eax
			var right = (Tuple<VarType, Object, List<String>>)VisitLogicalAndExpression (context.logicalAndExpression());//ebx
			if (left.Item1 != VarType.BOOL || right.Item1 != VarType.BOOL)
				throw new Exception ("bad type");
			if(left.Item2 != null && right.Item2 != null)
				return new Tuple<VarType, Object, List<String>>(VarType.BOOL, (Boolean)left.Item2 & (Boolean)right.Item2, new List<String>());

			if (left.Item2 != null && left.Item2.Equals (true) || right.Item2 != null && right.Item2.Equals (true)) {
				return new Tuple<VarType, Object, List<String>>(VarType.BOOL, true, new List<String>());
			}

			if (left.Item2 != null) {
				code.Add ("mov eax, " + left.Item2.ToString ());
				code.AddRange (right.Item3);
				code.Add ("pop ebx");
			}
			if (right.Item2 != null) {
				code.Add ("mov ebx, " + right.Item2.ToString ());
				code.AddRange (left.Item3);
				code.Add ("pop eax");
			}
			if(left.Item2 == null && right.Item2 == null) {
				code.AddRange (left.Item3);
				code.Add ("pop eax");
				code.AddRange (right.Item3);
				code.Add ("pop ebx");
			}
			code.Add ("or ebx");
			code.Add ("push eax");
			return new Tuple<VarType, Object, List<String>> (VarType.BOOL, null, code);
		}

	public override Object VisitLogicalAndExpression([NotNull] graParser.LogicalAndExpressionContext context) {
			if (context.logicalAndExpression () == null) {
				return VisitEqualityExpression (context.equalityExpression ());
			}
			var left = (Tuple<VarType, Object, List<String>>)VisitLogicalAndExpression (context.logicalAndExpression());
			var right = (Tuple<VarType, Object, List<String>>)VisitEqualityExpression (context.equalityExpression());
			List<String> code = new List<String> ();
			if (left.Item1 != VarType.BOOL || right.Item1 != VarType.BOOL)
				throw new Exception ("bad type");
			if(left.Item2 != null && right.Item2 != null)
				return new Tuple<VarType, Object, List<String>>(VarType.BOOL, (Boolean)left.Item2 & (Boolean)right.Item2, new List<String>());
			if (left.Item2 != null && left.Item2.Equals (false) || right.Item2 != null && right.Item2.Equals (false)) {
				return new Tuple<VarType, Object, List<String>>(VarType.BOOL, false, new List<String>());
			}

			if (left.Item2 != null) {
				code.Add ("mov eax, " + left.Item2.ToString ());
				code.AddRange (right.Item3);
				code.Add ("pop ebx");
			}
			if (right.Item2 != null) {
				code.Add ("mov ebx, " + right.Item2.ToString ());
				code.AddRange (left.Item3);
				code.Add ("pop eax");
			}
			if(left.Item2 == null && right.Item2 == null) {
				code.AddRange (left.Item3);
				code.Add ("pop eax");
				code.AddRange (right.Item3);
				code.Add ("pop ebx");
			}
			code.Add ("and ebx");
			code.Add ("push eax");
			return new Tuple<VarType, Object, List<String>> (VarType.BOOL, null, code);
			
		}

		public override Object VisitEqualityExpression([NotNull] graParser.EqualityExpressionContext context) {
			if (context.equalityExpression () == null) {
				return VisitRelationalExpression (context.relationalExpression ());
			}
			var left = (Tuple<VarType, Object, List<String>>)VisitEqualityExpression (context.equalityExpression());
			var right = (Tuple<VarType, Object, List<String>>)VisitRelationalExpression (context.relationalExpression());
			List<String> code = new List<String> ();
            String cmpOp = "";
            if (context.GetChild(1).ToString().Equals("=="))
            {
                cmpOp = "je";
            }

            if (context.GetChild(1).ToString().Equals("!="))
            {
                cmpOp = "jne";
            }
			if(left.Item2 != null && right.Item2 != null)
				return new Tuple<VarType, Object, List<String>>(VarType.BOOL, left.Item2.Equals(right.Item2), new List<String>());
			if (left.Item1 == VarType.INT && right.Item1 == VarType.INT ||
				left.Item1 == VarType.BOOL && right.Item1 == VarType.BOOL) {
				
				if (left.Item2 != null) {
					code.Add ("mov eax, " + left.Item2.ToString ());
					code.AddRange (right.Item3);
					code.Add ("pop ebx");
				}
				if (right.Item2 != null) {
					code.Add ("mov ebx, " + right.Item2.ToString ());
					code.AddRange (left.Item3);
					code.Add ("pop eax");
				}
				if(left.Item2 == null && right.Item2 == null) {
					code.AddRange (left.Item3);
					code.Add ("pop eax");
					code.AddRange (right.Item3);
					code.Add ("pop ebx");
				}
				code.Add ("cmp eax, ebx");
				code.Add (cmpOp + " lbl" + lblCounter.ToString ());
				code.Add ("mov eax, 0");
				code.Add ("jmp lbl" + (lblCounter + 1).ToString ());
				code.Add ("lbl" + lblCounter.ToString () + ":");
				code.Add ("mov eax, 1");
				code.Add ("lbl" + (lblCounter + 1).ToString () + ":");
				code.Add ("push eax");
				lblCounter += 2;
				return new Tuple<VarType, Object, List<String>> (VarType.BOOL, null, code);
			}
			if (left.Item1 == VarType.STRING && right.Item1 == VarType.STRING) {
                bool eq = context.GetChild(1).ToString().Equals("==");
                if (left.Item2 != null && right.Item2 != null)
                    return new Tuple<VarType, Object, List<String>>(VarType.BOOL, ((String)left.Item2).Equals((String)right.Item2) ^ !eq, new List<String>());
                if (left.Item2 != null)
                {
                    code.AddRange(right.Item3);
                    code.AddRange(addStringToHeap((String)left.Item2));
                    code.Add("call _strcmp");
                }
                if (right.Item2 != null)
                {
                    code.AddRange(addStringToHeap((String)right.Item2));
                    code.AddRange(left.Item3);
                    code.Add("call _strcmp");
                }

                if (left.Item2 == null && right.Item2 == null)
                {
                    code.AddRange(right.Item3);
                    code.AddRange(left.Item3);
                    code.Add("call _strcmp");
                }
                code.Add("mov ebx, eax");
                code.Add("call _free");
                code.Add("add esp, 4");
                code.Add("call _free");
                code.Add("add esp, 4");
                code.Add("cmp ebx, 0");
                code.Add(cmpOp + " lbl" + lblCounter.ToString());
                code.Add("mov ebx, 0");
                code.Add("jmp lbl" + (lblCounter + 1).ToString());
                code.Add("lbl" + lblCounter.ToString() + ":");
                code.Add("mov ebx, 1");
                code.Add("lbl" + (lblCounter + 1).ToString() + ":");
                lblCounter += 2;

                code.Add("call _free");
                code.Add("add esp, 4");
                code.Add("call _free");
                code.Add("add esp, 4");
                code.Add("push ebx");
                return new Tuple<VarType, Object, List<String>>(VarType.BOOL, null, code);
			}
			throw new Exception ("Bad type");
		}

		public override Object VisitRelationalExpression([NotNull] graParser.RelationalExpressionContext context) {
			if (context.relationalExpression () == null) {
				return VisitAdditiveExpression (context.additiveExpression ());
			}

			List<String> code = new List<String>();
			var left = (Tuple<VarType, Object, List<String>>)VisitRelationalExpression (context.relationalExpression());
			var right = (Tuple<VarType, Object, List<String>>)VisitAdditiveExpression (context.additiveExpression());
			if (left.Item1 != VarType.INT || right.Item1 != VarType.INT) {
				throw new Exception ("bad type");
			}
			String cmpOp = "";
			switch (context.GetChild (1).ToString ()) {
			case "<":
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object, List<String>> (VarType.BOOL, (int)left.Item2 < (int)right.Item2, new List<String>());
				cmpOp = "jl";
				break;
			case ">":
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object, List<String>> (VarType.BOOL, (int)left.Item2 > (int)right.Item2, new List<String>());
				cmpOp = "jg";
				break;
			case "<=":
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object, List<String>> (VarType.BOOL, (int)left.Item2 <= (int)right.Item2, new List<String>());
				cmpOp = "jle";
				break;
			case ">=":
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object, List<String>> (VarType.BOOL, (int)left.Item2 >= (int)right.Item2, new List<String>());
				cmpOp = "jge";
				break;
			default:
				throw new Exception ("Bad operator");
			}
			if (left.Item2 != null) {
				code.Add ("mov eax, " + left.Item2.ToString ());
				code.AddRange (right.Item3);
				code.Add ("pop ebx");
			}
			if (right.Item2 != null) {
				code.Add ("mov ebx, " + right.Item2.ToString ());
				code.AddRange (left.Item3);
				code.Add ("pop eax");
			}
			if(left.Item2 == null && right.Item2 == null) {
				code.AddRange (left.Item3);
				code.Add ("pop eax");
				code.AddRange (right.Item3);
				code.Add ("pop ebx");
			}
			code.Add ("cmp eax, ebx");
			code.Add (cmpOp + " lbl" + lblCounter.ToString ());
			code.Add ("mov eax, 0");
			code.Add ("jmp lbl" + (lblCounter + 1).ToString ());
			code.Add ("lbl" + lblCounter.ToString () + ":");
			code.Add ("mov eax, 1");
			code.Add ("lbl" + (lblCounter + 1).ToString () + ":");
			code.Add ("push eax");
			lblCounter += 2;
			return new Tuple<VarType, Object, List<String>> (VarType.BOOL, null, code);
		}

		public override Object VisitAdditiveExpression([NotNull] graParser.AdditiveExpressionContext context) {
			if (context.additiveExpression () == null) {
				return VisitMultiplicativeExpression (context.multiplicativeExpression ());
			}
			var left = (Tuple<VarType, Object, List<String>>)VisitAdditiveExpression (context.additiveExpression());
			var right = (Tuple<VarType, Object, List<String>>)VisitMultiplicativeExpression (context.multiplicativeExpression());
			List<String> code = new List<String>();
			switch (context.GetChild (1).ToString ()) {
			case "+":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object, List<String>> (VarType.INT, (int)left.Item2 + (int)right.Item2, new List<String>());
					if (left.Item2 != null && left.Item2.Equals (0))
						return new Tuple<VarType, Object, List<String>> (VarType.INT, right.Item2, new List<String>());

					if (right.Item2 != null && right.Item2.Equals (0))
						return new Tuple<VarType, Object, List<String>> (VarType.INT, left.Item2, new List<String>());
					if (left.Item2 != null && left.Item2 != null) {
						code.Add ("push " + left.Item2.ToString ());
						code.AddRange (right.Item3);
						code.Add ("pop ebx");
                        code.Add("pop eax");
						code.Add ("add eax, ebx");
						code.Add ("push eax");
						return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
					}
					if (right.Item2 != null) {
						code.Add ("push " + right.Item2.ToString ());
						code.AddRange (left.Item3);
						code.Add ("pop ebx");
                        code.Add("pop eax");
						code.Add ("add ebx, eax");
						code.Add ("push ebx");
						return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
					}
					code.AddRange (left.Item3);
					code.AddRange (right.Item3);
                    code.Add("pop eax");
					code.Add ("pop ebx");
					code.Add ("add ebx, eax");
					code.Add ("push ebx");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				if (left.Item1 == VarType.STRING && right.Item1 == VarType.STRING) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object, List<String>> (VarType.STRING, (String)left.Item2 + (String)right.Item2, new List<String>());
					if (left.Item2 != null) {
                        code.AddRange(right.Item3);
                        code.AddRange(addStringToHeap((String)left.Item2));
						code.Add("call _strcat");
                        code.Add("mov ebx, eax");
						code.Add ("add esp, 4");
						code.Add ("call _free");
						code.Add ("add esp, 4");
                        code.Add("push ebx");
						return new Tuple<VarType, Object, List<String>> (VarType.STRING, null, code);
					}
					if (right.Item2 != null) {
                        code.AddRange(addStringToHeap((String)right.Item2));
                        code.AddRange(left.Item3);
                        code.Add("call _strcat");
                        code.Add("mov ebx, eax");
                        code.Add("add esp, 4");
                        code.Add("call _free");
                        code.Add("add esp, 4");
                        code.Add("push ebx");
                        return new Tuple<VarType, Object, List<String>>(VarType.STRING, null, code);
					}
                    code.AddRange(right.Item3);
                    code.AddRange(left.Item3);
                    code.Add("call _strcat");
                    code.Add("mov ebx, eax");
                    code.Add("add esp, 4");
                    code.Add("call _free");
                    code.Add("add esp, 4");
                    code.Add("push ebx");
                    return new Tuple<VarType, Object, List<String>>(VarType.STRING, null, code);
				}
				throw new Exception ("Bad type");
				break;
			case "-":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object, List<String>> (VarType.INT, (int)left.Item2 - (int)right.Item2, new List<String>());
					if (left.Item2 != null && left.Item2.Equals (0))
						return new Tuple<VarType, Object, List<String>> (VarType.INT, -(int)right.Item2, new List<String>());
					if (right.Item2 != null && right.Item2.Equals (0))
						return new Tuple<VarType, Object, List<String>> (VarType.INT, left.Item2, new List<String>());
					if (left.Item2 != null) {
						code.Add ("push " + left.Item2.ToString ());
						code.AddRange (right.Item3);
						code.Add ("pop eax");
                        code.Add("pop ebx");
						code.Add ("sub ebx, eax");
						code.Add ("push ebx");
						return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
					}
					if (right.Item2 != null) {
						code.Add ("push " + right.Item2.ToString ());
						code.AddRange (left.Item3);
						code.Add ("pop eax");
                        code.Add("pop ebx");
						code.Add ("sub ebx, eax");
						code.Add ("push ebx");
						return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
					}
					code.AddRange (left.Item3);
					code.AddRange (right.Item3);
                    code.Add("pop eax");
					code.Add ("pop ebx");
					code.Add ("sub ebx, eax");
					code.Add ("push ebx");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				throw new Exception ("Bad type");
			}
			return null;
		}

        public List<String> addStringToHeap(String val)
        {
            List<String> code = new List<string>();
            code.Add("push 256");
            code.Add("call _malloc");
            code.Add("add esp, 4");
            String name = "tstr" + strCounter.ToString();
            Variable vl = new Variable(name, VarType.STRING);
            vl.value = val;
            strCounter++;
            table.AddGlobalVariable(vl);
            if (val != "")
            {
                code.Add("push " + name);
                code.Add("push eax");
                code.Add("call _strcpy");
                code.Add("add esp, 8");
            }

            code.Add("push eax");
            return code;
        }

		public override Object VisitMultiplicativeExpression([NotNull] graParser.MultiplicativeExpressionContext context) {
			if (context.multiplicativeExpression () == null) {
				return VisitAtom (context.atom ());
			}


			var left = (Tuple<VarType, Object, List<String>>)VisitMultiplicativeExpression (context.multiplicativeExpression());
			var right = (Tuple<VarType, Object, List<String>>)VisitAtom (context.atom());
			List<String> code = new List<String>();
			switch (context.GetChild (1).ToString ()) {
			case "*":
				if (left
					.Item1 != VarType.INT || right.Item1 != VarType.INT)
					throw new Exception ("no idea now to multiply");
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object, List<String>> (VarType.INT, (int)left.Item2 * (int)right.Item2, new List<String>());
				if ((left.Item2 != null && left.Item2.Equals (0)) || (right.Item2 != null && right.Item2.Equals (0)))
					return new Tuple<VarType, Object, List<String>> (VarType.INT, 0, new List<String>());
				if (left.Item2 != null) {
					code.Add ("push " + left.Item2.ToString ());
					code.AddRange (right.Item3);
					code.Add ("pop ebx");
                    code.Add("pop eax");
					code.Add ("imul ebx");
					code.Add ("push eax");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				if (right.Item2 != null) {
					code.Add ("push " + right.Item2.ToString ());
					code.AddRange (left.Item3);
					code.Add ("pop ebx");
                    code.Add("pop eax");
					code.Add ("imul ebx");
					code.Add ("push eax");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				code.AddRange (left.Item3);
				code.AddRange (right.Item3);
                code.Add("pop eax");
				code.Add ("pop ebx");
				code.Add ("imul eax");
				code.Add ("push eax");
				return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				break;
			case "/":
				if (left.Item1 != VarType.INT || right.Item1 != VarType.INT)
					throw new Exception ("no idea now to divide");
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object, List<String>> (VarType.INT, (int)left.Item2 / (int)right.Item2, new List<String>());
				if (right.Item2 != null && right.Item2.Equals (0))
					throw new Exception ("division by zero");
				if (left.Item2 != null && left.Item2.Equals (0))
					return new Tuple<VarType, Object, List<String>> (VarType.INT, 0, new List<String>());
				if (left.Item2 != null) {
					code.Add ("push " + left.Item2.ToString ());
					code.AddRange (right.Item3);
					code.Add ("pop ebx");
                    code.Add("pop eax");
					code.Add ("idiv ebx");
					code.Add ("push eax");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				if (right.Item2 != null) {
					code.Add ("push " + right.Item2.ToString ());
					code.AddRange (left.Item3);
                    code.Add("pop eax");
					code.Add ("pop ebx");
					code.Add ("idiv ebx");
					code.Add ("push eax");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				code.AddRange (left.Item3);
				code.AddRange (right.Item3);
                code.Add("pop eax");
				code.Add ("pop ebx");
				code.Add ("idiv ebx");
				code.Add ("push eax");
				return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				break;
			case "%":
				if (left.Item1 != VarType.INT || right.Item1 != VarType.INT)
					throw new Exception ("no idea now to divide");
				if(left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object, List<String>> (VarType.INT, (int)left.Item2 % (int)right.Item2, new List<String>());
				if (right.Item2 != null && right.Item2.Equals (0))
					throw new Exception ("division by zero");
				if (left.Item2 != null && left.Item2.Equals (0))
					return new Tuple<VarType, Object, List<String>> (VarType.INT, 0, new List<String>());
				if (left.Item2 != null) {
					code.Add ("mov eax, " + left.Item2.ToString ());
					code.AddRange (right.Item3);
					code.Add ("pop ebx");
					code.Add ("idiv ebx");
					code.Add ("push edx");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				if (right.Item2 != null) {
					code.Add ("mov ebx, " + right.Item2.ToString ());
					code.AddRange (left.Item3);
					code.Add ("pop eax");
					code.Add ("idiv ebx");
					code.Add ("push edx");
					return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
				}
				code.AddRange (left.Item3);
				code.Add ("pop eax");
				code.AddRange (right.Item3);
				code.Add ("pop ebx");
				code.Add ("idiv ebx");
				code.Add ("push edx");
				return new Tuple<VarType, Object, List<String>> (VarType.INT, null, code);
			}
			throw new Exception ("Bad operator");
		}

		public override Object VisitAtom([NotNull] graParser.AtomContext context) {
			if (context.Int() != null) {
				return new Tuple<VarType, Object, List<String>>(VarType.INT, Convert.ToInt32 (context.Int().ToString ()), new List<String>());
			}
			if (context.Bool() != null) {
				return new Tuple<VarType, Object, List<String>>(VarType.BOOL, context.Bool().ToString().Equals("true") ? true : false, new List<String>());
			}
			if (context.String() != null) {
				return new Tuple<VarType, Object, List<String>>(VarType.STRING, context.String().ToString ().Replace("\"", ""), new List<String>());
			}
			return VisitLookup(context.lookup());
		}

		public override Object VisitLookup([NotNull] graParser.LookupContext context) {
			List<String> code = new List<string> ();
			if (context.functionCall() != null)
				return VisitFunctionCall (context.functionCall());
			if (context.Identifier() != null) {
                String vName = context.Identifier().ToString();
				var v = table.getVariable (context.Identifier ().ToString ());
				if (v == null) {
					throw new Exception ("Variable " + context.Identifier ().ToString () + " does not exist in this scope");
				}
				if (v.type == VarType.STRING) {
					code.Add ("push 256");
					code.Add ("call _malloc");
					code.Add ("add esp, 4");
					code.Add ("push eax");
					if (table.getVarScope (v.name) == VarScope.GLOBAL) {
						code.Add ("push dword [" + v.name + "]");
					} else {
						code.Add ("push dword [ebp " + table.getVarOffset (v.name).ToString () + "]");
					}
                    code.Add("push eax");
					code.Add ("call _strcpy");
					code.Add ("add esp, 8");
				} else {
					if (table.getVarScope (v.name) == VarScope.GLOBAL) {
						code.Add ("push dword [" + v.name + "]");
					} else {
						code.Add ("push dword [ebp " + table.getVarOffset (v.name).ToString () + "]");
					}
				}
				return new Tuple<VarType, Object, List<String>> (v.type, v.value, code);
			}
			if (context.logicalOrExpression () != null) {
				return VisitLogicalOrExpression (context.logicalOrExpression ());
			}
			return null;
		}

		public override Object VisitFunctionCall([NotNull] graParser.FunctionCallContext context) {
			List<String> code = new List<string> ();
			if (context.Write() != null) {
				var expr = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression ());
				code.AddRange (expr.Item3);
				if (expr.Item1 == VarType.INT) {
					code.Add ("push IntF");
					code.Add ("call _printf");
					code.Add ("add esp, 8");
				}
				if (expr.Item1 == VarType.STRING) {
					code.Add ("push StrF");
					code.Add ("call _printf");
					code.Add ("add esp, 4");
                    code.Add("call _free");
                    code.Add("add esp, 4");
				}
				return code;
			}

			if (context.Read() != null) {
                String name = context.Identifier().ToString();
                Variable v = table.getVariable(name);
                if (v.type == VarType.INT)
                {
                    code.Add("lea ebx, [ebp " + table.getVarOffset(v.name).ToString() + "]");
                    code.Add("push ebx");
                    code.Add("push IntF");
                    code.Add("call _scanf");
                    code.Add("add esp, 8");
                }

                if (v.type == VarType.STRING)
                {
                    code.Add("push dword [ebp " + table.getVarOffset(v.name).ToString() + "]");
                    code.Add("push StrF");
                    code.Add("call _scanf");
                    code.Add("add esp, 8");
                }

                if (v.type != VarType.STRING && v.type != VarType.INT)
                    throw new Exception("i can read only integers and strings");

                return code;
			}
			Function f;
			functions.TryGetValue (context.Identifier ().ToString (), out f);
			var args = (Tuple<VarType[], List<String>>)VisitExpressionList (context.expressionList ());
			code.AddRange (args.Item2);
			code.Add ("call " + f.name);
            code.Add("mov ebx, eax");
			for (int i = 0; i < args.Item1.Length; i++) {
				if (args.Item1 [i] == VarType.STRING) {
					code.Add ("push dword [esp + " + ((args.Item1.Length - i - 1) * 4).ToString () + "]");
					code.Add ("call _free");
					code.Add ("add esp, 4");
				}
			}
            code.Add("add esp, " + (args.Item1.Length * 4).ToString());
			if (f.retType != VarType.VOID)
				code.Add ("push ebx");
			
			return new Tuple<VarType, Object, List<String>>(f.retType, null, code);
		}

		public override Object VisitExpressionList([NotNull] graParser.ExpressionListContext context) {
			VarType[] types = new VarType[context.expression().Length];
			List<String> code = new List<string> ();
            for (int i = context.expression().Length-1; i >= 0; i--)
            {
				var exprRes = (Tuple<VarType, Object, List<String>>)VisitExpression (context.expression () [i]);
				code.AddRange ((List<String>)exprRes.Item3);
				types[i] = exprRes.Item1;
			}
			return new Tuple<VarType[], List<String>>(types, code);
		}
	}
}