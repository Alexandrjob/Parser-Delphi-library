using System.Text.RegularExpressions;
using ParserDelphi;

namespace ParserDelphi.Words;

public class Method : WordsBase, ITypeWords
{
    private const string WORD = "METHOD";
    private const string WORDFIND = "PROCEDURE";
    private const string WORDFIND2 = "FUNCTION";
    
    public Method() : base(WORD) { }

    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "\\b*" + WORDFIND + "|" + WORDFIND2 + "\\b");
        IsEnd = true;
        
        return result;
    }
    
    public void Save(Dictionary<string,string> dic, string value)
    {
        var split = value.Replace("class", null).Trim().Split(new []{' ', ':', '('});
        var sp = value.Replace("class", null).Trim().Split(new []{' ', ':', '(', '.'});
        string key;
            
        if(split.Length == sp.Length)
            key = WORD + " " + split[1];
        else    
            key = WORD + " " + sp[2];
        
        if(!dic.TryGetValue(key, out _))
            dic.Add(key, value.Trim());
    }
}