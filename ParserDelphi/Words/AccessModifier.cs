using System.Text.RegularExpressions;

namespace ParserDelphi.Words;

public class AccessModifier : WordsBase, ITypeWords
{
    private const string WORD = "ACCESSMODIFIER";
    
    private const string WORD_PUBLIC = "PUBLIC";
    private const string WORD_PRIVATE = "PRIVATE";
    private const string WORD_PROTECTED = "PROTECTED";
    private const string WORD_PUBLISHED = "PUBLISHED";
    
    public AccessModifier() : base(WORD) { }

    public bool CheckLine(string value)
    {
        var result = Regex.IsMatch(value.ToUpper(), "\\b*" + WORD_PUBLIC + "|" + WORD_PRIVATE + "|" + WORD_PROTECTED + "|" + WORD_PUBLISHED + "\\b");
        IsEnd = true;
        
        return result;
    }

    public void Save(Dictionary<string, string> dic, string value)
    {
        Parser.Info.AccessModifier = value;
    }
}