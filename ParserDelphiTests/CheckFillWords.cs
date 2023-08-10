using ParserDelphi;
using ParserDelphi;

namespace ParserDelphi;

public class CheckFillWords
{
    private const string PATH = @"C:\personal\source\delp.txt";
    private readonly Parser _parser = new Parser(PATH);
    
    [Fact]
    public async Task CheckUSES()
    {
        await _parser.Run();

        var result = _parser.DelphiObjects.TryGetValue("USES",out var value);
        result = result && value != string.Empty;
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckUNIT()
    {
        await _parser.Run();

        var result = _parser.DelphiObjects.TryGetValue("UNIT",out var value);
        result = result && value != string.Empty;
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckCLASS()
    {
        await _parser.Run();

        var result = _parser.DelphiObjects.TryGetValue("CLASS TDBPromoEvent",out var value);

        result = (result) && (value != string.Empty);
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckMETHOD()
    {
        await _parser.Run();

        var result = _parser.DelphiObjects.TryGetValue("METHOD SetStartDate",out var value);
        var result2 = _parser.DelphiObjects.TryGetValue("METHOD ProcessForm",out var value2);

        result = (result && result2) && (value != string.Empty && value2 != string.Empty);
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckACCESSMODIFIER()
    {
        await _parser.Run();

        var result = _parser.DelphiObjects.TryGetValue("METHOD SetStartDate",out var value);
        var result2 = _parser.DelphiObjects.TryGetValue("METHOD ProcessForm",out var value2);

        result = (result && result2) && (value.Contains("private") && value2.Contains("protected"));
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckPROPERTY()
    {
        await _parser.Run();

        var result = _parser.DelphiObjects.TryGetValue("PROPERTY PEVendor",out var value);
        var result2 = _parser.DelphiObjects.TryGetValue("PROPERTY ToResaler",out var value2);

        result = (result && result2) && (value != string.Empty && value2 != string.Empty);
        
        Assert.True(result);
    }
    
    [Fact]
    public async Task CheckMETHODBODY()
    {
        await _parser.Run();

        var result = _parser.DelphiObjects.TryGetValue("METHODBODY GetPESeriesObj",out var value);
        var result2 = _parser.DelphiObjects.TryGetValue("METHODBODY ProcessForm",out var value2);

        result = (result && result2) && (value != string.Empty && value2 != string.Empty);
        
        Assert.True(result);
    }
}