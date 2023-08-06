using ParserDelphi.Words;

namespace ParserDelphi;

public class Parser
{
    private string pathToDelphi;
    public readonly Dictionary<string, string> DelphiObjects = new Dictionary<string,string>();

    private readonly List<ITypeWords> wordsClasses = new()
    {
        new Method(),
        new Class(),
        new Uses(),
        new Unit()
    };
    
    private readonly List<string> Words = new List<string>()
    {
        "uses",
        "type",
        "class",
        "strict",
        "Record",
        "procedure",
        "function",
        "protected",
        "public",
        "published"
    };

    public Parser(string path)
    {
        pathToDelphi = path;
    }
    
    public async Task Run()
    {
        using var reader = new StreamReader(pathToDelphi);
        while (await reader.ReadLineAsync() is { } text)
        {
            if(string.IsNullOrWhiteSpace(text))
                continue;
                
            foreach (var word in wordsClasses)
            {
                var result = word.CheckLine(text);
                
                if(result)
                    word.Save(DelphiObjects, text);

                if (word.IsEnd || !result) continue;

                do
                {
                    text = await reader.ReadLineAsync();
                    word.Save(DelphiObjects, text);
                        
                    text = await reader.ReadLineAsync();
                    if(string.IsNullOrWhiteSpace(text))
                        break;
                    
                    result = word.CheckLine(text);
                } while (word.IsEnd || result);
                    
                break;
            }
            
            Console.WriteLine(text);
        }
    }
}