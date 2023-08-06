namespace ParserDelphi;

public interface ITypeWords
{
    public bool IsEnd { get; set; }
    public bool CheckLine(string value);
    public void Save(Dictionary<string, string> dic, string value);
    public void Update(Dictionary<string, string> dic, string value, string combineValue);
}