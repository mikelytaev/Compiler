// Generated from /Users/mikhail/OneDrive/compilashki/gra.g4 by ANTLR 4.5
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link graParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface graVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link graParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(@NotNull graParser.ProgramContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#global}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGlobal(@NotNull graParser.GlobalContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#functionDefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionDefinition(@NotNull graParser.FunctionDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#parameterList}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameterList(@NotNull graParser.ParameterListContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#typeSpecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTypeSpecifier(@NotNull graParser.TypeSpecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#functionBody}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionBody(@NotNull graParser.FunctionBodyContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#compoundStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompoundStatement(@NotNull graParser.CompoundStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatement(@NotNull graParser.StatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#unionStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnionStatement(@NotNull graParser.UnionStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#selectionStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelectionStatement(@NotNull graParser.SelectionStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#caseStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCaseStatement(@NotNull graParser.CaseStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#jumpStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitJumpStatement(@NotNull graParser.JumpStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#whileStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitWhileStatement(@NotNull graParser.WhileStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#functionCall}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionCall(@NotNull graParser.FunctionCallContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#expressionList}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpressionList(@NotNull graParser.ExpressionListContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#multiplicativeExpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicativeExpression(@NotNull graParser.MultiplicativeExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#additiveExpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAdditiveExpression(@NotNull graParser.AdditiveExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#relationalExpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRelationalExpression(@NotNull graParser.RelationalExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#equalityExpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEqualityExpression(@NotNull graParser.EqualityExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#logicalAndExpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogicalAndExpression(@NotNull graParser.LogicalAndExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#logicalOrExpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogicalOrExpression(@NotNull graParser.LogicalOrExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpression(@NotNull graParser.ExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#atom}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAtom(@NotNull graParser.AtomContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#lookup}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLookup(@NotNull graParser.LookupContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#index}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIndex(@NotNull graParser.IndexContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#assignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignment(@NotNull graParser.AssignmentContext ctx);
	/**
	 * Visit a parse tree produced by {@link graParser#declarationIdentifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclarationIdentifier(@NotNull graParser.DeclarationIdentifierContext ctx);
}