using ParserDelphi;
using ParserDelphi;

namespace ParserDelphi;

public class CheckFillWords
{
    private const string path = @"C:\Users\adm\Desktop\delp.txt";
    private readonly Parser parser = new Parser(path);
    
    [Fact]
    public async Task CheckUSES()
    {
        await parser.Run();

        var result = parser.DelphiObjects.TryGetValue("USES",out var value);
        result = result && value != string.Empty;
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckUNIT()
    {
        await parser.Run();

        var result = parser.DelphiObjects.TryGetValue("UNIT",out var value);
        result = result && value != string.Empty;
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckCLASS()
    {
        await parser.Run();

        var result = parser.DelphiObjects.TryGetValue("CLASS TDBPromoEvent",out var value);
        var result2 = parser.DelphiObjects.TryGetValue("CLASS TInitNewPromoEvent",out var value2);

        result = (result && result2) && (value != string.Empty && value2 != string.Empty);
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckMETHOD()
    {
        await parser.Run();

        var result = parser.DelphiObjects.TryGetValue("METHOD SetCreateDate",out var value);
        var result2 = parser.DelphiObjects.TryGetValue("METHOD CheckManager",out var value2);

        result = (result && result2) && (value != string.Empty && value2 != string.Empty);
        
        Assert.True(result);
    }
}