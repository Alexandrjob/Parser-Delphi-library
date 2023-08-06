using System.Text.RegularExpressions;
using ParserDelphi;

namespace ParserDelphi.Words;

public class Uses : WordsBase, ITypeWords
{
    private const string WORD = "USES";

    public Uses() : base(WORD) { }
    
    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "\\b" + WORD + "\\b");
        IsEnd = Regex.IsMatch(value, "\\s*;\\s*");
        
        return result;
    }
}