using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Compiler
{
	public class MainVisitor : graBaseVisitor<Object>
	{
		SymbolTable table;
		NASMGenerator gen;
		Dictionary<String, Function> functions;
		public MainVisitor ()
		{
			
		}

		public Object VisitFunctionDefinition([NotNull] graParser.FunctionDefinitionContext context)
		{
			String funcName = context.Identifier ().ToString ();
			Function f = new Function (funcName);
			f.retType = VisitTypeSpecifier (context.typeSpecifier ());
			if (context.parameterList() != null) {
				Tuple<VarType, String>[] pList = VisitParameterList (context.parameterList ());
				foreach(var par in pList) {
					Variable var = new Variable (par.Item2, par.Item1);
					f.AddArg (var);
				}
			}
			List<String> code = new List<string> ();
			code.Add (funcName + ':');
			code.AddRange (VisitFunctionBody (context.functionBody));
			return code;
		}

		public Object VisitTypeSpecifier([NotNull] graParser.TypeSpecifierContext context) {
			if (context.Void_type () != null)
				return VarType.VOID;
			if (context.Int_type () != null)
				return VarType.INT;
			if (context.Bool_type () != null)
				return VarType.BOOL;
			if (context.String_type != null)
				return VarType.STRING;
		}

		public Object VisitParameterList([NotNull] graParser.ParameterListContext context) {
			var pList = Array.CreateInstance(typeof(Tuple<VarType, String>), context.typeSpecifier().Length);
			for (int i = 0; i < context.typeSpecifier().Length; i++) {
				pList [i] = new Tuple<VarType, String> (VisitTypeSpecifier (context.typeSpecifier (i)), context.Identifier (i).ToString ());
			}
		}

		public Object VisitFunctionBody([NotNull] graParser.FunctionBodyContext context) {
			List<String> code = new List<string> ();
			foreach (var s in context.statement()) {
				code.AddRange(VisitStatement (s));
			}
			return code;
		}

		public Object VisitStatement([NotNull] graParser.StatementContext context) {
			return VisitChildren(context);
		}

		public Object VisitDeclarationIdentifier([NotNull] graParser.DeclarationIdentifierContext context) {
			List<String> code = new List<string> ();
			Variable var = new Variable (context.Identifier ().ToString (), VisitTypeSpecifier (context.typeSpecifier ()));
			if(context.expression() != null) {
				Tuple<VarType, Object, List<String>> expr = VisitExpression (context.expression ());
				if (VisitTypeSpecifier (context.typeSpecifier ()) != expr.Item1)
					throw new Exception ("bad type");
				var.value = expr.Item2;
				table.addStackVariable (var);
				if (expr.Item2 != null) {
					code.Add ("mov dword [ebp - " + (-table.getVarOffset (var.name)).ToString() + "], " + expr.Item1.ToString());
				} else {
					code.AddRange (expr.Item3);
				}
			}
			return code;
		}

		public Object VisitAssignment([NotNull] graParser.AssignmentContext context) {
			List<String> code = new List<string> ();
			if (table.getVariable (context.Identifier ().ToString ()) == null)
				throw new Exeption ("variable does not exist in this scope");
			if(context.expression() != null) {
				Tuple<VarType, Object, List<String>> expr = VisitExpression (context.expression ());
				if (VisitTypeSpecifier (context.typeSpecifier ()) != expr.Item1)
					throw new Exception ("bad type");
				table.setVarValue(expr.Item2);
				if (expr.Item2 != null) {
					code.Add ("mov dword [ebp - " + (-table.getVarOffset (var.name)).ToString() + "], " + expr.Item1.ToString());
				} else {
					code.AddRange (expr.Item3);
					code.Add ("pop eax");
					code.Add ("mov dword [ebp - " + (-table.getVarOffset (var.name)).ToString() + "], eax");
				}
			}
			return code;
		}

		public Object VisitExpression([NotNull] graParser.ExpressionContext context) {
			VisitChildren(context);
		}

		public Object VisitLogicalOrExpression([NotNull] graParser.LogicalOrExpressionContext context) {
			if (context.logicalOrExpression () == null) {
				return VisitChildren (context);
			}
			List<String> code = new List<string> ();
			Tuple<VarType, Object, List<String>> left = VisitLogicalOrExpression (context.logicalOrExpression);//eax
			Tuple<VarType, Object, List<String>> right = VisitLogicalAndExpression (context.logicalAndExpression);//ebx
			code.AddRange(left.Item3);
			code.AddRange (right.Item3);
			if (left.Item1 != VarType.BOOL || right.Item1 != VarType.BOOL)
				throw new Exception ("bad type");
			if(left.Item2 != null && right.Item2 != null)
				return new Tuple<VarType, Object>(VarType.BOOL, left.Item1 & left.Item2);
			if (left.Item2 != null) {
				code.Add ("pop ebx");
				code.Add ("or ebx, " + Boolean (left.Item2) ? "1" : "0");
				code.Add ("push ebx");
			}
			//TODO: generate code;
		}

		public Object VisitLogicalAndExpression([NotNull] graParser.LogicalAndExpressionContext context) {
			if (context.logicalAndExpression () == null) {
				return VisitChildren (context);
			}
			Tuple<VarType, Object> left = VisitLogicalAndExpression (context.logicalAndExpression);
			Tuple<VarType, Object> right = VisitEqualityExpression (context.equalityExpression);
			if (left.Item1 != VarType.BOOL || right.Item1 != VarType.BOOL)
				throw new Exception ("bad type");
			if(left.Item2 != null && right.Item2 != null)
				return new Tuple<VarType, Object>(VarType.BOOL, left.Item1 & left.Item2);
			//TODO: generate code;
		}

		public Object VisitEqualityExpression([NotNull] graParser.EqualityExpressionContext context) {
			if (context.equalityExpression () == null) {
				return VisitChildren (context);
			}
			Tuple<VarType, Object> left = VisitEqualityExpression (context.equalityExpression);
			Tuple<VarType, Object> right = VisitRelationalExpression (context.relationalExpression);
			if(left.Item2 != null && right.Item2 != null)
				return new Tuple<VarType, Object>(VarType.BOOL, left.Item2.Equals(right.Item2));
			if (context.GetChild (1).ToString ().Equals ("==")) {
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					//TODO:generate code
				}
				if (left.Item1 == VarType.BOOL && right.Item1 == VarType.BOOL) {
					//TODO:generate code
				}
				if (left.Item1 == VarType.STRING && right.Item1 == VarType.STRING) {
					//TODO:generate code
				}
			}
			if (context.GetChild (1).ToString ().Equals ("!=")) {
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					//TODO:generate code
				}
				if (left.Item1 == VarType.BOOL && right.Item1 == VarType.BOOL) {
					//TODO:generate code
				}
				if (left.Item1 == VarType.STRING && right.Item1 == VarType.STRING) {
					//TODO:generate code
				}
			}
		}

		public Object VisitRelationalExpression([NotNull] graParser.RelationalExpressionContext context) {
			if (context.relationalExpression () == null) {
				return VisitChildren (context);
			}

			Tuple<VarType, Object> left = VisitRelationalExpression (context.relationalExpression);
			Tuple<VarType, Object> right = VisitAdditiveExpression (context.additiveExpression);

			switch (context.GetChild (1).ToString ()) {
			case "<":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object> (VarType.BOOL, left.Item2 < right.Item2);
					//TODO:generate code
				}
				throw new Exception ("bad type");
				break;
			case ">":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object> (VarType.BOOL, left.Item2 > right.Item2);
					//TODO:generate code
				}
				throw new Exception ("bad type");
				break;
			case "<=":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object> (VarType.BOOL, left.Item2 <= right.Item2);
					//TODO:generate code
				}
				throw new Exception ("bad type");
				break;
			case ">=":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object> (VarType.BOOL, left.Item2 >= right.Item2);
					//TODO:generate code
				}
				throw new Exception ("bad type");
			}
		}

		public Object VisitAdditiveExpression([NotNull] graParser.AdditiveExpressionContext context) {
			if (context.additiveExpression () == null) {
				return VisitChildren (context);
			}
			Tuple<VarType, Object> left = VisitAdditiveExpression (context.additiveExpression);
			Tuple<VarType, Object> right = VisitMultiplicativeExpression (context.multiplicativeExpression);
			switch (context.GetChild (1).ToString ()) {
			case "+":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object> (VarType.INT, left.Item2 + right.Item2);
					if (left.Item2.Equals (0))
						return new Tuple<VarType, Object> (VarType.INT, right.Item2);
					if (right.Item2.Equals (0))
						return new Tuple<VarType, Object> (VarType.INT, left.Item2);
					//TODO: generate code
				}
				if (left.Item1 == VarType.STRING && right.Item1 == VarType.STRING) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object> (VarType.INT, left.Item2 + right.Item2);
					//TODO: generate code
				}
				throw new Exeption ("Bad type");
				break;
			case "-":
				if (left.Item1 == VarType.INT && right.Item1 == VarType.INT) {
					if (left.Item2 != null && right.Item2 != null)
						return new Tuple<VarType, Object> (VarType.INT, left.Item2 - right.Item2);
					if (left.Item2.Equals (0))
						return new Tuple<VarType, Object> (VarType.INT, -right.Item2);
					if (right.Item2.Equals (0))
						return new Tuple<VarType, Object> (VarType.INT, left.Item2);
					//TODO: generate code
				}
				throw new Exeption ("Bad type");
			}
		}

		public Object VisitMultiplicativeExpression([NotNull] graParser.MultiplicativeExpressionContext context) {
			if (context.multiplicativeExpression () == null) {
				return VisitChildren (context);
			}
			Tuple<VarType, Object> left = VisitMultiplicativeExpression (context.multiplicativeExpression);
			Tuple<VarType, Object> right = VisitAtom (context.atom);
			switch (context.GetChild (1).ToString ()) {
			case "*":
				if (left.Item1 != VarType.INT || right.Item1 != VarType.INT)
					throw new Exeption ("no idea now to multiply");
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object> (VarType.INT, left.Item2 * right.Item2);
				if (left.Item2.Equals (0) || right.Item2.Equals (0))
					return new Tuple<VarType, Object> (VarType.INT, 0);
				//TODO: generate code
				return new Tuple<VarType, Object> (VarType.INT, null);
				break;
			case "/":
				if (left.Item1 != VarType.INT || right.Item1 != VarType.INT)
					throw new Exeption ("no idea now to divide");
				if (left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object> (VarType.INT, left.Item2 / right.Item2);
				if (right.Item2.Equals (0))
					throw new Exeption ("division by zero");
				if (left.Item2.Equals (0))
					return new Tuple<VarType, Object> (VarType.INT, 0);
				//TODO: generate code
				return new Tuple<VarType, Object> (VarType.INT, null);
				break;
			case "%":
				if (left.Item1 != VarType.INT || right.Item1 != VarType.INT)
					throw new Exeption ("no idea now to divide");
				if(left.Item2 != null && right.Item2 != null)
					return new Tuple<VarType, Object> (VarType.INT, left.Item2 % right.Item2);
				if (right.Item2.Equals (0))
					throw new Exeption ("division by zero");
				if (left.Item2.Equals (0))
					return new Tuple<VarType, Object> (VarType.INT, 0);
				//TODO: generate code
				return new Tuple<VarType, Object>(VarType.INT, null);

			}
		}

		public Object VisitAtom([NotNull] graParser.AtomContext context) {
			if (context.Int != null) {
				return new Tuple<VarType, Object, List<String>>(VarType.INT, Convert.ToInt32 (context.Int().ToString ()), null);
			}
			if (context.Bool != null) {
				return new Tuple<VarType, Object, List<String>>(VarType.BOOL, context.Bool().ToString().equals("true") ? true : false, null);
			}
			if (context.String != null) {
				return new Tuple<VarType, Object, List<String>>(VarType.STRING, context.String().ToString (), null);
			}
			VisitChildren (context);
		}

		public Object VisitLookup([NotNull] graParser.LookupContext context) {
			List<String> code = new List<string> ();
			if (context.functionCall != null)
				VisitChildren (context);
			if (context.Identifier != null) {
				var v = table.getVariable (context.Identifier ().ToString ());
				if (v == null)
					throw new Exception ("Variable " + context.Identifier ().ToString () + " does not exist in this scope");
				if (table.getVarScope (v.name) == VarScope.GLOBAL) {
					code.Add ("push dword [" + v.name + "]");
				} else {
					code.Add ("push dword [ebp - " + table.getVarOffset (v.name).ToString () + "]");
				}
				return Tuple<VarType, Object, List<Stirng>> (v.type, v.value, code);
			}
		}

		public Object VisitFunctionCall([NotNull] graParser.FunctionCallContext context) {
			List<String> code = new List<string> ();
			if (context.Write != null) {

			}

			if (context.Read != null) {

			}
			Function f;
			functions.TryGetValue (context.Identifier ().ToString (), out f);

			foreach (var arg in f.getArgs()) {
				code.Add("push " + arg)
			}
			return new Tuple<VarType, Object>(f.ret.GetType (), null);
		}

		public Object VisitExpressionList([NotNull] graParser.ExpressionListContext context) {
			List<String> code = new List<String>();
			foreach (var expr in context.exception()) {
				Tuple<VarType, Object, List<Code>> exprRes = VisitExpression (expr);
				code.AddRange (VisitExpression (exprRes.Item3));
			}
			return code;
		}
}

