using System.Text.RegularExpressions;
using static System.String;

namespace ParserDelphi.Words;

public class MethodBody : WordsBase, ITypeWords
{
    private const string WORD = "METHODBODY";
    
    private const string WORD_CONST = "CONST";
    private const string WORD_VAR = "VAR";
    private const string WORD_BEGIN = "BEGIN";
    
    private const string WORD_END = "END";

    private string body = Empty;

    public MethodBody() : base(WORD) { }

    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "^" + WORD_BEGIN + "|" + "^" + WORD_CONST + "|" + "^" + WORD_VAR);
        IsEnd = Regex.IsMatch(value.ToUpper(), "^" + WORD_END);

        return result;
    }

    public void Save(Dictionary<string, string> dic, string value)
    {
        body += value + " ";

        if(!IsEnd)
            return;

        var key = WORD + ' ' + Parser.Info.MethodName;
        if (dic.TryGetValue(key, out _))
        {
            body = Empty;
            return;
        }
        
        dic.Add(key, body);
        body = Empty;
    }
}