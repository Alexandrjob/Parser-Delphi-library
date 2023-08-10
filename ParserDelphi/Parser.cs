using ParserDelphi.Words;

namespace ParserDelphi;

public class Parser
{
    private string pathToDelphi;
    public readonly Dictionary<string, string> DelphiObjects = new Dictionary<string, string>();

    private readonly List<ITypeWords> wordsClasses = new()
    {
        new MethodBody(),
        new Property(),
        new AccessModifier(),
        new Method(),
        new Class(),
        new Uses(),
        new Unit()
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
            if (string.IsNullOrWhiteSpace(text))
                continue;

            foreach (var word in wordsClasses)
            {
                var result = word.CheckLine(text);

                if (result)
                    word.Save(DelphiObjects, text);

                if (word.IsEnd || !result) continue;

                do
                {
                    text = await reader.ReadLineAsync();
                    word.CheckLine(text);
                    
                    word.Save(DelphiObjects, text);
                } while (!word.IsEnd);

                break;
            }

            Console.WriteLine(text);
        }
    }

    public static class Info
    {
        private static string? _accessModifier;
        public static string? ClassName { get; set; }

        public static string? MethodName { get; set; }

        public static string? AccessModifier
        {
            get => _accessModifier;
            set
            {
                string?[] result = value.Trim().Split(' ');
                _accessModifier = result.Length == 2 ? result[1] : result[0];
            }
        }
    }
}