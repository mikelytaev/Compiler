//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/mikhail/Compiler/gra.g4 by ANTLR 4.5

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5")]
[System.CLSCompliant(false)]
public partial class graLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, While=24, 
		Break=25, Continue=26, Switch=27, Case=28, Return=29, If=30, Else=31, 
		Union=32, Write=33, Read=34, Void_type=35, Int_type=36, Bool_type=37, 
		String_type=38, Int=39, Bool=40, String=41, Identifier=42, Comment=43, 
		Space=44;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "While", "Break", 
		"Continue", "Switch", "Case", "Return", "If", "Else", "Union", "Write", 
		"Read", "Void_type", "Int_type", "Bool_type", "String_type", "Int", "Bool", 
		"String", "Identifier", "Comment", "Space"
	};


	public graLexer(ICharStream input)
		: base(input)
	{
		Interpreter = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "'='", "'('", "')'", "','", "'{'", "'}'", "':'", "'*'", "'/'", 
		"'%'", "'+'", "'-'", "'<'", "'>'", "'<='", "'>='", "'=='", "'!='", "'&&'", 
		"'||'", "'['", "']'", "'while'", "'break'", "'continue'", "'switch'", 
		"'case'", "'return'", "'if'", "'else'", "'union'", "'write'", "'read'", 
		"'void'", "'int'", "'bool'", "'string'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		"While", "Break", "Continue", "Switch", "Case", "Return", "If", "Else", 
		"Union", "Write", "Read", "Void_type", "Int_type", "Bool_type", "String_type", 
		"Int", "Bool", "String", "Identifier", "Comment", "Space"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "gra.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x2.\x125\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x4)\t)\x4*\t"+
		"*\x4+\t+\x4,\t,\x4-\t-\x3\x2\x3\x2\x3\x3\x3\x3\x3\x4\x3\x4\x3\x5\x3\x5"+
		"\x3\x6\x3\x6\x3\a\x3\a\x3\b\x3\b\x3\t\x3\t\x3\n\x3\n\x3\v\x3\v\x3\f\x3"+
		"\f\x3\r\x3\r\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x11"+
		"\x3\x12\x3\x12\x3\x12\x3\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x3\x15"+
		"\x3\x15\x3\x15\x3\x16\x3\x16\x3\x16\x3\x17\x3\x17\x3\x18\x3\x18\x3\x19"+
		"\x3\x19\x3\x19\x3\x19\x3\x19\x3\x19\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A"+
		"\x3\x1A\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B"+
		"\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1D\x3\x1D\x3\x1D"+
		"\x3\x1D\x3\x1D\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1F"+
		"\x3\x1F\x3\x1F\x3 \x3 \x3 \x3 \x3 \x3!\x3!\x3!\x3!\x3!\x3!\x3\"\x3\"\x3"+
		"\"\x3\"\x3\"\x3\"\x3#\x3#\x3#\x3#\x3#\x3$\x3$\x3$\x3$\x3$\x3%\x3%\x3%"+
		"\x3%\x3&\x3&\x3&\x3&\x3&\x3\'\x3\'\x3\'\x3\'\x3\'\x3\'\x3\'\x3(\x6(\xE7"+
		"\n(\r(\xE(\xE8\x3)\x3)\x3)\x3)\x3)\x3)\x3)\x3)\x3)\x5)\xF4\n)\x3*\x3*"+
		"\x3*\x3*\x3*\x3*\a*\xFC\n*\f*\xE*\xFF\v*\x3*\x3*\x3+\x3+\a+\x105\n+\f"+
		"+\xE+\x108\v+\x3,\x3,\x3,\x3,\a,\x10E\n,\f,\xE,\x111\v,\x3,\x3,\x3,\x3"+
		",\a,\x117\n,\f,\xE,\x11A\v,\x3,\x3,\x5,\x11E\n,\x3,\x3,\x3-\x3-\x3-\x3"+
		"-\x3\x118\x2.\x3\x3\x5\x4\a\x5\t\x6\v\a\r\b\xF\t\x11\n\x13\v\x15\f\x17"+
		"\r\x19\xE\x1B\xF\x1D\x10\x1F\x11!\x12#\x13%\x14\'\x15)\x16+\x17-\x18/"+
		"\x19\x31\x1A\x33\x1B\x35\x1C\x37\x1D\x39\x1E;\x1F= ?!\x41\"\x43#\x45$"+
		"G%I&K\'M(O)Q*S+U,W-Y.\x3\x2\t\x3\x2\x32;\x3\x2$$\x5\x2\f\f\xF\xF$$\x5"+
		"\x2\x43\\\x61\x61\x63|\x6\x2\x32;\x43\\\x61\x61\x63|\x4\x2\f\f\xF\xF\x5"+
		"\x2\v\f\xE\xF\"\"\x12D\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2"+
		"\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2"+
		"\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17"+
		"\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2"+
		"\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2"+
		"\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3"+
		"\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2"+
		"\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2"+
		"?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x2\x43\x3\x2\x2\x2\x2\x45\x3\x2\x2\x2"+
		"\x2G\x3\x2\x2\x2\x2I\x3\x2\x2\x2\x2K\x3\x2\x2\x2\x2M\x3\x2\x2\x2\x2O\x3"+
		"\x2\x2\x2\x2Q\x3\x2\x2\x2\x2S\x3\x2\x2\x2\x2U\x3\x2\x2\x2\x2W\x3\x2\x2"+
		"\x2\x2Y\x3\x2\x2\x2\x3[\x3\x2\x2\x2\x5]\x3\x2\x2\x2\a_\x3\x2\x2\x2\t\x61"+
		"\x3\x2\x2\x2\v\x63\x3\x2\x2\x2\r\x65\x3\x2\x2\x2\xFg\x3\x2\x2\x2\x11i"+
		"\x3\x2\x2\x2\x13k\x3\x2\x2\x2\x15m\x3\x2\x2\x2\x17o\x3\x2\x2\x2\x19q\x3"+
		"\x2\x2\x2\x1Bs\x3\x2\x2\x2\x1Du\x3\x2\x2\x2\x1Fw\x3\x2\x2\x2!y\x3\x2\x2"+
		"\x2#|\x3\x2\x2\x2%\x7F\x3\x2\x2\x2\'\x82\x3\x2\x2\x2)\x85\x3\x2\x2\x2"+
		"+\x88\x3\x2\x2\x2-\x8B\x3\x2\x2\x2/\x8D\x3\x2\x2\x2\x31\x8F\x3\x2\x2\x2"+
		"\x33\x95\x3\x2\x2\x2\x35\x9B\x3\x2\x2\x2\x37\xA4\x3\x2\x2\x2\x39\xAB\x3"+
		"\x2\x2\x2;\xB0\x3\x2\x2\x2=\xB7\x3\x2\x2\x2?\xBA\x3\x2\x2\x2\x41\xBF\x3"+
		"\x2\x2\x2\x43\xC5\x3\x2\x2\x2\x45\xCB\x3\x2\x2\x2G\xD0\x3\x2\x2\x2I\xD5"+
		"\x3\x2\x2\x2K\xD9\x3\x2\x2\x2M\xDE\x3\x2\x2\x2O\xE6\x3\x2\x2\x2Q\xF3\x3"+
		"\x2\x2\x2S\xF5\x3\x2\x2\x2U\x102\x3\x2\x2\x2W\x11D\x3\x2\x2\x2Y\x121\x3"+
		"\x2\x2\x2[\\\a=\x2\x2\\\x4\x3\x2\x2\x2]^\a?\x2\x2^\x6\x3\x2\x2\x2_`\a"+
		"*\x2\x2`\b\x3\x2\x2\x2\x61\x62\a+\x2\x2\x62\n\x3\x2\x2\x2\x63\x64\a.\x2"+
		"\x2\x64\f\x3\x2\x2\x2\x65\x66\a}\x2\x2\x66\xE\x3\x2\x2\x2gh\a\x7F\x2\x2"+
		"h\x10\x3\x2\x2\x2ij\a<\x2\x2j\x12\x3\x2\x2\x2kl\a,\x2\x2l\x14\x3\x2\x2"+
		"\x2mn\a\x31\x2\x2n\x16\x3\x2\x2\x2op\a\'\x2\x2p\x18\x3\x2\x2\x2qr\a-\x2"+
		"\x2r\x1A\x3\x2\x2\x2st\a/\x2\x2t\x1C\x3\x2\x2\x2uv\a>\x2\x2v\x1E\x3\x2"+
		"\x2\x2wx\a@\x2\x2x \x3\x2\x2\x2yz\a>\x2\x2z{\a?\x2\x2{\"\x3\x2\x2\x2|"+
		"}\a@\x2\x2}~\a?\x2\x2~$\x3\x2\x2\x2\x7F\x80\a?\x2\x2\x80\x81\a?\x2\x2"+
		"\x81&\x3\x2\x2\x2\x82\x83\a#\x2\x2\x83\x84\a?\x2\x2\x84(\x3\x2\x2\x2\x85"+
		"\x86\a(\x2\x2\x86\x87\a(\x2\x2\x87*\x3\x2\x2\x2\x88\x89\a~\x2\x2\x89\x8A"+
		"\a~\x2\x2\x8A,\x3\x2\x2\x2\x8B\x8C\a]\x2\x2\x8C.\x3\x2\x2\x2\x8D\x8E\a"+
		"_\x2\x2\x8E\x30\x3\x2\x2\x2\x8F\x90\ay\x2\x2\x90\x91\aj\x2\x2\x91\x92"+
		"\ak\x2\x2\x92\x93\an\x2\x2\x93\x94\ag\x2\x2\x94\x32\x3\x2\x2\x2\x95\x96"+
		"\a\x64\x2\x2\x96\x97\at\x2\x2\x97\x98\ag\x2\x2\x98\x99\a\x63\x2\x2\x99"+
		"\x9A\am\x2\x2\x9A\x34\x3\x2\x2\x2\x9B\x9C\a\x65\x2\x2\x9C\x9D\aq\x2\x2"+
		"\x9D\x9E\ap\x2\x2\x9E\x9F\av\x2\x2\x9F\xA0\ak\x2\x2\xA0\xA1\ap\x2\x2\xA1"+
		"\xA2\aw\x2\x2\xA2\xA3\ag\x2\x2\xA3\x36\x3\x2\x2\x2\xA4\xA5\au\x2\x2\xA5"+
		"\xA6\ay\x2\x2\xA6\xA7\ak\x2\x2\xA7\xA8\av\x2\x2\xA8\xA9\a\x65\x2\x2\xA9"+
		"\xAA\aj\x2\x2\xAA\x38\x3\x2\x2\x2\xAB\xAC\a\x65\x2\x2\xAC\xAD\a\x63\x2"+
		"\x2\xAD\xAE\au\x2\x2\xAE\xAF\ag\x2\x2\xAF:\x3\x2\x2\x2\xB0\xB1\at\x2\x2"+
		"\xB1\xB2\ag\x2\x2\xB2\xB3\av\x2\x2\xB3\xB4\aw\x2\x2\xB4\xB5\at\x2\x2\xB5"+
		"\xB6\ap\x2\x2\xB6<\x3\x2\x2\x2\xB7\xB8\ak\x2\x2\xB8\xB9\ah\x2\x2\xB9>"+
		"\x3\x2\x2\x2\xBA\xBB\ag\x2\x2\xBB\xBC\an\x2\x2\xBC\xBD\au\x2\x2\xBD\xBE"+
		"\ag\x2\x2\xBE@\x3\x2\x2\x2\xBF\xC0\aw\x2\x2\xC0\xC1\ap\x2\x2\xC1\xC2\a"+
		"k\x2\x2\xC2\xC3\aq\x2\x2\xC3\xC4\ap\x2\x2\xC4\x42\x3\x2\x2\x2\xC5\xC6"+
		"\ay\x2\x2\xC6\xC7\at\x2\x2\xC7\xC8\ak\x2\x2\xC8\xC9\av\x2\x2\xC9\xCA\a"+
		"g\x2\x2\xCA\x44\x3\x2\x2\x2\xCB\xCC\at\x2\x2\xCC\xCD\ag\x2\x2\xCD\xCE"+
		"\a\x63\x2\x2\xCE\xCF\a\x66\x2\x2\xCF\x46\x3\x2\x2\x2\xD0\xD1\ax\x2\x2"+
		"\xD1\xD2\aq\x2\x2\xD2\xD3\ak\x2\x2\xD3\xD4\a\x66\x2\x2\xD4H\x3\x2\x2\x2"+
		"\xD5\xD6\ak\x2\x2\xD6\xD7\ap\x2\x2\xD7\xD8\av\x2\x2\xD8J\x3\x2\x2\x2\xD9"+
		"\xDA\a\x64\x2\x2\xDA\xDB\aq\x2\x2\xDB\xDC\aq\x2\x2\xDC\xDD\an\x2\x2\xDD"+
		"L\x3\x2\x2\x2\xDE\xDF\au\x2\x2\xDF\xE0\av\x2\x2\xE0\xE1\at\x2\x2\xE1\xE2"+
		"\ak\x2\x2\xE2\xE3\ap\x2\x2\xE3\xE4\ai\x2\x2\xE4N\x3\x2\x2\x2\xE5\xE7\t"+
		"\x2\x2\x2\xE6\xE5\x3\x2\x2\x2\xE7\xE8\x3\x2\x2\x2\xE8\xE6\x3\x2\x2\x2"+
		"\xE8\xE9\x3\x2\x2\x2\xE9P\x3\x2\x2\x2\xEA\xEB\ah\x2\x2\xEB\xEC\a\x63\x2"+
		"\x2\xEC\xED\an\x2\x2\xED\xEE\au\x2\x2\xEE\xF4\ag\x2\x2\xEF\xF0\av\x2\x2"+
		"\xF0\xF1\at\x2\x2\xF1\xF2\aw\x2\x2\xF2\xF4\ag\x2\x2\xF3\xEA\x3\x2\x2\x2"+
		"\xF3\xEF\x3\x2\x2\x2\xF4R\x3\x2\x2\x2\xF5\xFD\t\x3\x2\x2\xF6\xFC\n\x4"+
		"\x2\x2\xF7\xF8\a^\x2\x2\xF8\xFC\a^\x2\x2\xF9\xFA\a^\x2\x2\xFA\xFC\a$\x2"+
		"\x2\xFB\xF6\x3\x2\x2\x2\xFB\xF7\x3\x2\x2\x2\xFB\xF9\x3\x2\x2\x2\xFC\xFF"+
		"\x3\x2\x2\x2\xFD\xFB\x3\x2\x2\x2\xFD\xFE\x3\x2\x2\x2\xFE\x100\x3\x2\x2"+
		"\x2\xFF\xFD\x3\x2\x2\x2\x100\x101\t\x3\x2\x2\x101T\x3\x2\x2\x2\x102\x106"+
		"\t\x5\x2\x2\x103\x105\t\x6\x2\x2\x104\x103\x3\x2\x2\x2\x105\x108\x3\x2"+
		"\x2\x2\x106\x104\x3\x2\x2\x2\x106\x107\x3\x2\x2\x2\x107V\x3\x2\x2\x2\x108"+
		"\x106\x3\x2\x2\x2\x109\x10A\a\x31\x2\x2\x10A\x10B\a\x31\x2\x2\x10B\x10F"+
		"\x3\x2\x2\x2\x10C\x10E\n\a\x2\x2\x10D\x10C\x3\x2\x2\x2\x10E\x111\x3\x2"+
		"\x2\x2\x10F\x10D\x3\x2\x2\x2\x10F\x110\x3\x2\x2\x2\x110\x11E\x3\x2\x2"+
		"\x2\x111\x10F\x3\x2\x2\x2\x112\x113\a\x31\x2\x2\x113\x114\a,\x2\x2\x114"+
		"\x118\x3\x2\x2\x2\x115\x117\v\x2\x2\x2\x116\x115\x3\x2\x2\x2\x117\x11A"+
		"\x3\x2\x2\x2\x118\x119\x3\x2\x2\x2\x118\x116\x3\x2\x2\x2\x119\x11B\x3"+
		"\x2\x2\x2\x11A\x118\x3\x2\x2\x2\x11B\x11C\a,\x2\x2\x11C\x11E\a\x31\x2"+
		"\x2\x11D\x109\x3\x2\x2\x2\x11D\x112\x3\x2\x2\x2\x11E\x11F\x3\x2\x2\x2"+
		"\x11F\x120\b,\x2\x2\x120X\x3\x2\x2\x2\x121\x122\t\b\x2\x2\x122\x123\x3"+
		"\x2\x2\x2\x123\x124\b-\x2\x2\x124Z\x3\x2\x2\x2\v\x2\xE8\xF3\xFB\xFD\x106"+
		"\x10F\x118\x11D\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
