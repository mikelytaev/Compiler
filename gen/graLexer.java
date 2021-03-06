// Generated from /Users/mikhail/OneDrive/compilashki/gra.g4 by ANTLR 4.5
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class graLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.5", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, While=24, 
		Break=25, Continue=26, Switch=27, Case=28, Return=29, If=30, Else=31, 
		Union=32, Write=33, Read=34, Void_type=35, Int_type=36, Bool_type=37, 
		String_type=38, Int=39, Bool=40, String=41, Identifier=42, Comment=43, 
		Space=44;
	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "While", "Break", 
		"Continue", "Switch", "Case", "Return", "If", "Else", "Union", "Write", 
		"Read", "Void_type", "Int_type", "Bool_type", "String_type", "Int", "Bool", 
		"String", "Identifier", "Comment", "Space"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "';'", "'='", "'('", "')'", "','", "'{'", "'}'", "':'", "'*'", "'/'", 
		"'%'", "'+'", "'-'", "'<'", "'>'", "'<='", "'>='", "'=='", "'!='", "'&&'", 
		"'||'", "'['", "']'", "'while'", "'break'", "'continue'", "'switch'", 
		"'case'", "'return'", "'if'", "'else'", "'union'", "'write'", "'read'", 
		"'void'", "'int'", "'bool'", "'string'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		"While", "Break", "Continue", "Switch", "Case", "Return", "If", "Else", 
		"Union", "Write", "Read", "Void_type", "Int_type", "Bool_type", "String_type", 
		"Int", "Bool", "String", "Identifier", "Comment", "Space"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override
	@NotNull
	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public graLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "gra.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u0430\ud6d1\u8206\uad2d\u4417\uaef1\u8d80\uaadd\2.\u0125\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t"+
		"\3\t\3\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3"+
		"\21\3\21\3\21\3\22\3\22\3\22\3\23\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3"+
		"\25\3\26\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\31\3\31\3\31\3\31\3"+
		"\32\3\32\3\32\3\32\3\32\3\32\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3\33\3"+
		"\33\3\34\3\34\3\34\3\34\3\34\3\34\3\34\3\35\3\35\3\35\3\35\3\35\3\36\3"+
		"\36\3\36\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3 \3 \3 \3 \3 \3!\3!\3!\3"+
		"!\3!\3!\3\"\3\"\3\"\3\"\3\"\3\"\3#\3#\3#\3#\3#\3$\3$\3$\3$\3$\3%\3%\3"+
		"%\3%\3&\3&\3&\3&\3&\3\'\3\'\3\'\3\'\3\'\3\'\3\'\3(\6(\u00e7\n(\r(\16("+
		"\u00e8\3)\3)\3)\3)\3)\3)\3)\3)\3)\5)\u00f4\n)\3*\3*\3*\3*\3*\3*\7*\u00fc"+
		"\n*\f*\16*\u00ff\13*\3*\3*\3+\3+\7+\u0105\n+\f+\16+\u0108\13+\3,\3,\3"+
		",\3,\7,\u010e\n,\f,\16,\u0111\13,\3,\3,\3,\3,\7,\u0117\n,\f,\16,\u011a"+
		"\13,\3,\3,\5,\u011e\n,\3,\3,\3-\3-\3-\3-\3\u0118\2.\3\3\5\4\7\5\t\6\13"+
		"\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21!\22#\23%\24\'"+
		"\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36;\37= ?!A\"C#E$G%I&K\'"+
		"M(O)Q*S+U,W-Y.\3\2\t\3\2\62;\3\2$$\5\2\f\f\17\17$$\5\2C\\aac|\6\2\62;"+
		"C\\aac|\4\2\f\f\17\17\5\2\13\f\16\17\"\"\u012d\2\3\3\2\2\2\2\5\3\2\2\2"+
		"\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3"+
		"\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2"+
		"\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2"+
		"\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2"+
		"\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2"+
		"\2\2\2A\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2"+
		"\2M\3\2\2\2\2O\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2U\3\2\2\2\2W\3\2\2\2\2Y"+
		"\3\2\2\2\3[\3\2\2\2\5]\3\2\2\2\7_\3\2\2\2\ta\3\2\2\2\13c\3\2\2\2\re\3"+
		"\2\2\2\17g\3\2\2\2\21i\3\2\2\2\23k\3\2\2\2\25m\3\2\2\2\27o\3\2\2\2\31"+
		"q\3\2\2\2\33s\3\2\2\2\35u\3\2\2\2\37w\3\2\2\2!y\3\2\2\2#|\3\2\2\2%\177"+
		"\3\2\2\2\'\u0082\3\2\2\2)\u0085\3\2\2\2+\u0088\3\2\2\2-\u008b\3\2\2\2"+
		"/\u008d\3\2\2\2\61\u008f\3\2\2\2\63\u0095\3\2\2\2\65\u009b\3\2\2\2\67"+
		"\u00a4\3\2\2\29\u00ab\3\2\2\2;\u00b0\3\2\2\2=\u00b7\3\2\2\2?\u00ba\3\2"+
		"\2\2A\u00bf\3\2\2\2C\u00c5\3\2\2\2E\u00cb\3\2\2\2G\u00d0\3\2\2\2I\u00d5"+
		"\3\2\2\2K\u00d9\3\2\2\2M\u00de\3\2\2\2O\u00e6\3\2\2\2Q\u00f3\3\2\2\2S"+
		"\u00f5\3\2\2\2U\u0102\3\2\2\2W\u011d\3\2\2\2Y\u0121\3\2\2\2[\\\7=\2\2"+
		"\\\4\3\2\2\2]^\7?\2\2^\6\3\2\2\2_`\7*\2\2`\b\3\2\2\2ab\7+\2\2b\n\3\2\2"+
		"\2cd\7.\2\2d\f\3\2\2\2ef\7}\2\2f\16\3\2\2\2gh\7\177\2\2h\20\3\2\2\2ij"+
		"\7<\2\2j\22\3\2\2\2kl\7,\2\2l\24\3\2\2\2mn\7\61\2\2n\26\3\2\2\2op\7\'"+
		"\2\2p\30\3\2\2\2qr\7-\2\2r\32\3\2\2\2st\7/\2\2t\34\3\2\2\2uv\7>\2\2v\36"+
		"\3\2\2\2wx\7@\2\2x \3\2\2\2yz\7>\2\2z{\7?\2\2{\"\3\2\2\2|}\7@\2\2}~\7"+
		"?\2\2~$\3\2\2\2\177\u0080\7?\2\2\u0080\u0081\7?\2\2\u0081&\3\2\2\2\u0082"+
		"\u0083\7#\2\2\u0083\u0084\7?\2\2\u0084(\3\2\2\2\u0085\u0086\7(\2\2\u0086"+
		"\u0087\7(\2\2\u0087*\3\2\2\2\u0088\u0089\7~\2\2\u0089\u008a\7~\2\2\u008a"+
		",\3\2\2\2\u008b\u008c\7]\2\2\u008c.\3\2\2\2\u008d\u008e\7_\2\2\u008e\60"+
		"\3\2\2\2\u008f\u0090\7y\2\2\u0090\u0091\7j\2\2\u0091\u0092\7k\2\2\u0092"+
		"\u0093\7n\2\2\u0093\u0094\7g\2\2\u0094\62\3\2\2\2\u0095\u0096\7d\2\2\u0096"+
		"\u0097\7t\2\2\u0097\u0098\7g\2\2\u0098\u0099\7c\2\2\u0099\u009a\7m\2\2"+
		"\u009a\64\3\2\2\2\u009b\u009c\7e\2\2\u009c\u009d\7q\2\2\u009d\u009e\7"+
		"p\2\2\u009e\u009f\7v\2\2\u009f\u00a0\7k\2\2\u00a0\u00a1\7p\2\2\u00a1\u00a2"+
		"\7w\2\2\u00a2\u00a3\7g\2\2\u00a3\66\3\2\2\2\u00a4\u00a5\7u\2\2\u00a5\u00a6"+
		"\7y\2\2\u00a6\u00a7\7k\2\2\u00a7\u00a8\7v\2\2\u00a8\u00a9\7e\2\2\u00a9"+
		"\u00aa\7j\2\2\u00aa8\3\2\2\2\u00ab\u00ac\7e\2\2\u00ac\u00ad\7c\2\2\u00ad"+
		"\u00ae\7u\2\2\u00ae\u00af\7g\2\2\u00af:\3\2\2\2\u00b0\u00b1\7t\2\2\u00b1"+
		"\u00b2\7g\2\2\u00b2\u00b3\7v\2\2\u00b3\u00b4\7w\2\2\u00b4\u00b5\7t\2\2"+
		"\u00b5\u00b6\7p\2\2\u00b6<\3\2\2\2\u00b7\u00b8\7k\2\2\u00b8\u00b9\7h\2"+
		"\2\u00b9>\3\2\2\2\u00ba\u00bb\7g\2\2\u00bb\u00bc\7n\2\2\u00bc\u00bd\7"+
		"u\2\2\u00bd\u00be\7g\2\2\u00be@\3\2\2\2\u00bf\u00c0\7w\2\2\u00c0\u00c1"+
		"\7p\2\2\u00c1\u00c2\7k\2\2\u00c2\u00c3\7q\2\2\u00c3\u00c4\7p\2\2\u00c4"+
		"B\3\2\2\2\u00c5\u00c6\7y\2\2\u00c6\u00c7\7t\2\2\u00c7\u00c8\7k\2\2\u00c8"+
		"\u00c9\7v\2\2\u00c9\u00ca\7g\2\2\u00caD\3\2\2\2\u00cb\u00cc\7t\2\2\u00cc"+
		"\u00cd\7g\2\2\u00cd\u00ce\7c\2\2\u00ce\u00cf\7f\2\2\u00cfF\3\2\2\2\u00d0"+
		"\u00d1\7x\2\2\u00d1\u00d2\7q\2\2\u00d2\u00d3\7k\2\2\u00d3\u00d4\7f\2\2"+
		"\u00d4H\3\2\2\2\u00d5\u00d6\7k\2\2\u00d6\u00d7\7p\2\2\u00d7\u00d8\7v\2"+
		"\2\u00d8J\3\2\2\2\u00d9\u00da\7d\2\2\u00da\u00db\7q\2\2\u00db\u00dc\7"+
		"q\2\2\u00dc\u00dd\7n\2\2\u00ddL\3\2\2\2\u00de\u00df\7u\2\2\u00df\u00e0"+
		"\7v\2\2\u00e0\u00e1\7t\2\2\u00e1\u00e2\7k\2\2\u00e2\u00e3\7p\2\2\u00e3"+
		"\u00e4\7i\2\2\u00e4N\3\2\2\2\u00e5\u00e7\t\2\2\2\u00e6\u00e5\3\2\2\2\u00e7"+
		"\u00e8\3\2\2\2\u00e8\u00e6\3\2\2\2\u00e8\u00e9\3\2\2\2\u00e9P\3\2\2\2"+
		"\u00ea\u00eb\7h\2\2\u00eb\u00ec\7c\2\2\u00ec\u00ed\7n\2\2\u00ed\u00ee"+
		"\7u\2\2\u00ee\u00f4\7g\2\2\u00ef\u00f0\7v\2\2\u00f0\u00f1\7t\2\2\u00f1"+
		"\u00f2\7w\2\2\u00f2\u00f4\7g\2\2\u00f3\u00ea\3\2\2\2\u00f3\u00ef\3\2\2"+
		"\2\u00f4R\3\2\2\2\u00f5\u00fd\t\3\2\2\u00f6\u00fc\n\4\2\2\u00f7\u00f8"+
		"\7^\2\2\u00f8\u00fc\7^\2\2\u00f9\u00fa\7^\2\2\u00fa\u00fc\7$\2\2\u00fb"+
		"\u00f6\3\2\2\2\u00fb\u00f7\3\2\2\2\u00fb\u00f9\3\2\2\2\u00fc\u00ff\3\2"+
		"\2\2\u00fd\u00fb\3\2\2\2\u00fd\u00fe\3\2\2\2\u00fe\u0100\3\2\2\2\u00ff"+
		"\u00fd\3\2\2\2\u0100\u0101\t\3\2\2\u0101T\3\2\2\2\u0102\u0106\t\5\2\2"+
		"\u0103\u0105\t\6\2\2\u0104\u0103\3\2\2\2\u0105\u0108\3\2\2\2\u0106\u0104"+
		"\3\2\2\2\u0106\u0107\3\2\2\2\u0107V\3\2\2\2\u0108\u0106\3\2\2\2\u0109"+
		"\u010a\7\61\2\2\u010a\u010b\7\61\2\2\u010b\u010f\3\2\2\2\u010c\u010e\n"+
		"\7\2\2\u010d\u010c\3\2\2\2\u010e\u0111\3\2\2\2\u010f\u010d\3\2\2\2\u010f"+
		"\u0110\3\2\2\2\u0110\u011e\3\2\2\2\u0111\u010f\3\2\2\2\u0112\u0113\7\61"+
		"\2\2\u0113\u0114\7,\2\2\u0114\u0118\3\2\2\2\u0115\u0117\13\2\2\2\u0116"+
		"\u0115\3\2\2\2\u0117\u011a\3\2\2\2\u0118\u0119\3\2\2\2\u0118\u0116\3\2"+
		"\2\2\u0119\u011b\3\2\2\2\u011a\u0118\3\2\2\2\u011b\u011c\7,\2\2\u011c"+
		"\u011e\7\61\2\2\u011d\u0109\3\2\2\2\u011d\u0112\3\2\2\2\u011e\u011f\3"+
		"\2\2\2\u011f\u0120\b,\2\2\u0120X\3\2\2\2\u0121\u0122\t\b\2\2\u0122\u0123"+
		"\3\2\2\2\u0123\u0124\b-\2\2\u0124Z\3\2\2\2\13\2\u00e8\u00f3\u00fb\u00fd"+
		"\u0106\u010f\u0118\u011d\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}