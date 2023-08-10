using System.Text.RegularExpressions;
using ParserDelphi;

namespace ParserDelphi.Words;

public class Method : WordsBase, ITypeWords
{
    private const string WORD = "METHOD";
    private const string WORD_PROCEDURE = "PROCEDURE";
    private const string WORD_FUNCTION = "FUNCTION";
    
    public Method() : base(WORD) { }

    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "\\b*" + WORD_PROCEDURE + "|" + WORD_FUNCTION + "\\b");
        IsEnd = true;
        
        return result;
    }

    public void Save(Dictionary<string,string> dic, string value)
    {
        var trimStr = value.Replace("class", null).Trim().Split(' ', ':',';', '(');
        
        // В сторке может быть так что перед методом идет класс через точку, тут мы проверкой размера массива узнаем, какой элемент брать.
        var split = trimStr[1].Split('.').ToArray();
        var key = string.Empty;
        
        if (split.Length == 1)
        {
            key = $"{WORD} {split[0]}";
            Parser.Info.MethodName = split[0];
        }
        else
        {
            key = $"{WORD} {split[1]}";
            Parser.Info.MethodName = split[1];
        }

        if (dic.TryGetValue(key, out _)) return;

        var entryValue = $"{Parser.Info.AccessModifier} {value.Trim()}";
        dic.Add(key, entryValue);
    }
}