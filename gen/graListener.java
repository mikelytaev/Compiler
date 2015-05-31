// Generated from /Users/mikhail/OneDrive/compilashki/gra.g4 by ANTLR 4.5
import org.antlr.v4.runtime.misc.NotNull;
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link graParser}.
 */
public interface graListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link graParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(@NotNull graParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(@NotNull graParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#global}.
	 * @param ctx the parse tree
	 */
	void enterGlobal(@NotNull graParser.GlobalContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#global}.
	 * @param ctx the parse tree
	 */
	void exitGlobal(@NotNull graParser.GlobalContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#functionDefinition}.
	 * @param ctx the parse tree
	 */
	void enterFunctionDefinition(@NotNull graParser.FunctionDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#functionDefinition}.
	 * @param ctx the parse tree
	 */
	void exitFunctionDefinition(@NotNull graParser.FunctionDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void enterParameterList(@NotNull graParser.ParameterListContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void exitParameterList(@NotNull graParser.ParameterListContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#typeSpecifier}.
	 * @param ctx the parse tree
	 */
	void enterTypeSpecifier(@NotNull graParser.TypeSpecifierContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#typeSpecifier}.
	 * @param ctx the parse tree
	 */
	void exitTypeSpecifier(@NotNull graParser.TypeSpecifierContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#functionBody}.
	 * @param ctx the parse tree
	 */
	void enterFunctionBody(@NotNull graParser.FunctionBodyContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#functionBody}.
	 * @param ctx the parse tree
	 */
	void exitFunctionBody(@NotNull graParser.FunctionBodyContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#compoundStatement}.
	 * @param ctx the parse tree
	 */
	void enterCompoundStatement(@NotNull graParser.CompoundStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#compoundStatement}.
	 * @param ctx the parse tree
	 */
	void exitCompoundStatement(@NotNull graParser.CompoundStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(@NotNull graParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(@NotNull graParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#unionStatement}.
	 * @param ctx the parse tree
	 */
	void enterUnionStatement(@NotNull graParser.UnionStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#unionStatement}.
	 * @param ctx the parse tree
	 */
	void exitUnionStatement(@NotNull graParser.UnionStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#selectionStatement}.
	 * @param ctx the parse tree
	 */
	void enterSelectionStatement(@NotNull graParser.SelectionStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#selectionStatement}.
	 * @param ctx the parse tree
	 */
	void exitSelectionStatement(@NotNull graParser.SelectionStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#caseStatement}.
	 * @param ctx the parse tree
	 */
	void enterCaseStatement(@NotNull graParser.CaseStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#caseStatement}.
	 * @param ctx the parse tree
	 */
	void exitCaseStatement(@NotNull graParser.CaseStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#jumpStatement}.
	 * @param ctx the parse tree
	 */
	void enterJumpStatement(@NotNull graParser.JumpStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#jumpStatement}.
	 * @param ctx the parse tree
	 */
	void exitJumpStatement(@NotNull graParser.JumpStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void enterWhileStatement(@NotNull graParser.WhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void exitWhileStatement(@NotNull graParser.WhileStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCall(@NotNull graParser.FunctionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCall(@NotNull graParser.FunctionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#expressionList}.
	 * @param ctx the parse tree
	 */
	void enterExpressionList(@NotNull graParser.ExpressionListContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#expressionList}.
	 * @param ctx the parse tree
	 */
	void exitExpressionList(@NotNull graParser.ExpressionListContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#multiplicativeExpression}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicativeExpression(@NotNull graParser.MultiplicativeExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#multiplicativeExpression}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicativeExpression(@NotNull graParser.MultiplicativeExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#additiveExpression}.
	 * @param ctx the parse tree
	 */
	void enterAdditiveExpression(@NotNull graParser.AdditiveExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#additiveExpression}.
	 * @param ctx the parse tree
	 */
	void exitAdditiveExpression(@NotNull graParser.AdditiveExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#relationalExpression}.
	 * @param ctx the parse tree
	 */
	void enterRelationalExpression(@NotNull graParser.RelationalExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#relationalExpression}.
	 * @param ctx the parse tree
	 */
	void exitRelationalExpression(@NotNull graParser.RelationalExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#equalityExpression}.
	 * @param ctx the parse tree
	 */
	void enterEqualityExpression(@NotNull graParser.EqualityExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#equalityExpression}.
	 * @param ctx the parse tree
	 */
	void exitEqualityExpression(@NotNull graParser.EqualityExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#logicalAndExpression}.
	 * @param ctx the parse tree
	 */
	void enterLogicalAndExpression(@NotNull graParser.LogicalAndExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#logicalAndExpression}.
	 * @param ctx the parse tree
	 */
	void exitLogicalAndExpression(@NotNull graParser.LogicalAndExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#logicalOrExpression}.
	 * @param ctx the parse tree
	 */
	void enterLogicalOrExpression(@NotNull graParser.LogicalOrExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#logicalOrExpression}.
	 * @param ctx the parse tree
	 */
	void exitLogicalOrExpression(@NotNull graParser.LogicalOrExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(@NotNull graParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(@NotNull graParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#atom}.
	 * @param ctx the parse tree
	 */
	void enterAtom(@NotNull graParser.AtomContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#atom}.
	 * @param ctx the parse tree
	 */
	void exitAtom(@NotNull graParser.AtomContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#lookup}.
	 * @param ctx the parse tree
	 */
	void enterLookup(@NotNull graParser.LookupContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#lookup}.
	 * @param ctx the parse tree
	 */
	void exitLookup(@NotNull graParser.LookupContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#index}.
	 * @param ctx the parse tree
	 */
	void enterIndex(@NotNull graParser.IndexContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#index}.
	 * @param ctx the parse tree
	 */
	void exitIndex(@NotNull graParser.IndexContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(@NotNull graParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(@NotNull graParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link graParser#declarationIdentifier}.
	 * @param ctx the parse tree
	 */
	void enterDeclarationIdentifier(@NotNull graParser.DeclarationIdentifierContext ctx);
	/**
	 * Exit a parse tree produced by {@link graParser#declarationIdentifier}.
	 * @param ctx the parse tree
	 */
	void exitDeclarationIdentifier(@NotNull graParser.DeclarationIdentifierContext ctx);
}