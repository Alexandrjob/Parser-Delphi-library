using System.Text.RegularExpressions;
using ParserDelphi;

namespace ParserDelphi.Words;

public class Unit : WordsBase, ITypeWords
{
    private const string WORD = "UNIT";

    public Unit() : base(WORD) { }

    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "\\b" + WORD + "\\b");
        IsEnd = true;
        
        return result;
    }
}