using System.Text.RegularExpressions;

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
        var className = value.Trim().Split(' ').FirstOrDefault();
        var key = WORD + " " + className;

        Parser.Info.ClassName = className;
        
        if(!dic.TryGetValue(key, out _))
            dic.Add(key, value);
    }
}