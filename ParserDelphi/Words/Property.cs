using System.Text.RegularExpressions;

namespace ParserDelphi.Words;

public class Property : WordsBase,ITypeWords
{
    private const string WORD = "PROPERTY";
    
    public Property() : base(WORD) { }

    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "\\b*" + WORD + "\\b");
        IsEnd = true;
        
        return result;
    }

    public void Save(Dictionary<string, string> dic, string value)
    {
        var key = value.Replace(":", null).Trim().Split(' ')[1];
        
        if(!dic.TryGetValue(key, out _))
            dic.Add(WORD + ' ' + key, Parser.Info.AccessModifier + " " + value.Trim());
    }
}