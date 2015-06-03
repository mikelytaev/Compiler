grammar gra;

program
    : global* EOF
    ;

global
    : functionDefinition
    | declarationIdentifier ';'
    | Identifier '=' atom ';'
    ;

functionDefinition
	: typeSpecifier Identifier '(' parameterList? ')' functionBody
	;
    
parameterList
	: typeSpecifier Identifier (',' typeSpecifier Identifier)*
	;

typeSpecifier
	: Void_type
	| Int_type
	| Bool_type
	| String_type
	;
    
functionBody
    : '{' statement* (Return expression ';')? '}'
    ;
    
compoundStatement
	: '{' statement* '}'
	;
	
statement
	: assignment ';'
    | functionCall ';'
    | declarationIdentifier ';'
    | unionStatement ';'
	| whileStatement
	| jumpStatement
	| compoundStatement
	| selectionStatement
	;
    
unionStatement
    : Union '{' (typeSpecifier Identifier)+ '}'
    ;
	
selectionStatement
	: If '(' expression ')' statement
	| If '(' expression ')' statement Else statement
	| Switch '(' expression ')' '{' (Case expression ':' statement)* '}'
	;
	
jumpStatement
	: Break ';'
	| Continue ';'
	;
	
whileStatement
	: While '(' expression ')' statement
	;
    
functionCall
    : Identifier '(' expressionList? ')'
    | Write '(' expression ')'
    | Read '(' Identifier ')'
    ;

expressionList
    : expression (',' expression)*  
    ;

multiplicativeExpression
    :   atom
    |   multiplicativeExpression '*' atom
    |   multiplicativeExpression '/' atom
    |   multiplicativeExpression '%' atom
    ;

additiveExpression
    :   multiplicativeExpression
    |   additiveExpression '+' multiplicativeExpression
    |   additiveExpression '-' multiplicativeExpression
    ;

relationalExpression
    :   additiveExpression
    |   relationalExpression '<' additiveExpression
    |   relationalExpression '>' additiveExpression
    |   relationalExpression '<=' additiveExpression
    |   relationalExpression '>=' additiveExpression
    ;

equalityExpression
    :   relationalExpression
    |   equalityExpression '==' relationalExpression
    |   equalityExpression '!=' relationalExpression
    ;

logicalAndExpression
    :   equalityExpression
    |   logicalAndExpression '&&' equalityExpression
    ;

logicalOrExpression
    :   logicalAndExpression
    |   logicalOrExpression '||' logicalAndExpression
    ;
	
expression
	: logicalOrExpression
	;
  
atom
  :  Int  
  |  String  
  |  Bool  
  |  lookup  
  ;  
  
lookup  
  :  functionCall
  |  Identifier
  | '(' expression ')'
  ; 
  
index
  :  '[' expression ']' 
  ;
	
assignment
	: Identifier '=' expression
	;
	
declarationIdentifier
	: typeSpecifier Identifier ('=' expression)?
	;
    

While	: 'while' ;
Break	: 'break' ;
Continue	: 'continue' ;
Switch	: 'switch' ;
Case    : 'case' ;
Return  : 'return' ;
If	: 'if' ;
Else	: 'else' ;
Union : 'union' ;
Write : 'write' ;
Read  : 'read' ;

Void_type : 'void';
Int_type : 'int';
Bool_type : 'bool';
String_type : 'string';

Int : [0-9]+;
Bool : 'false' | 'true' ;
String : ["] (~["\r\n] | '\\\\' | '\\"')* ["];
Identifier 	:	[a-zA-Z_] [a-zA-Z_0-9]*;

Comment
 : ('//' ~[\r\n]* | '/*' .*? '*/') -> skip
 ;
Space
 : [ \t\r\n\u000C] -> skip
 ;