using System.Text.RegularExpressions;
using ParserDelphi;

namespace ParserDelphi.Words;

public class Class : WordsBase, ITypeWords
{
    private const string WORD = "CLASS";

    public Class() : base(WORD)
    {
    }

    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "[=]\\W*" + WORD +"\\.*");
        IsEnd = true;

        return result;
    }
    
    public new void Save(Dictionary<string, string> dic, string value)
    {
        var key = WORD + " " + value.Trim().Split(' ').FirstOrDefault();
        if(!dic.TryGetValue(key, out _))
            dic.Add(key, value);
        ;
    }
}