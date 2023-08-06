namespace ParserDelphi.Words;

public class WordsBase
{
    private string WORD;
    public bool IsEnd { get; set; }

    public WordsBase(string word)
    {
        WORD = word;
    }
    
    public void Save(Dictionary<string,string> dic, string value)
    {
        if (dic.TryGetValue(WORD, out var result))
        {
            Update(dic, value, result);
            return;
        }
        
        dic.Add(WORD, value.Trim());
    }
    
    public void Update(Dictionary<string,string> dic, string value, string combineValue)
    {
        dic[WORD] = value + combineValue.Trim();
    }
}