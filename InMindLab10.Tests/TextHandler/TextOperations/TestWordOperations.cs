using Xunit;

namespace InMindLab10.Tests.TextHandler.TextOperations;

public class TestWordOperations
{
    [Fact]
    public void TestWordCount()
    {
        Assert.Equal(3, InMindLab10.TextStatistics.WordCount("Hello world example"));
        Assert.Equal(0, InMindLab10.TextStatistics.WordCount(""));
    }

    [Fact]
    public void TestCharacterCount()
    {
        Assert.Equal(11, InMindLab10.TextStatistics.CharacterCount("Hello World"));
        Assert.Equal(0, InMindLab10.TextStatistics.CharacterCount(""));
    }

    [Fact]
    public void TestMostCommonWord()
    {
        Assert.Equal("hello", InMindLab10.TextStatistics.MostCommonWord("hello world hello"));
        Assert.Equal("example", InMindLab10.TextStatistics.MostCommonWord("example example test"));
    }

    [Fact]
    public void TestLeastCommonWord()
    {
        Assert.Equal("world", InMindLab10.TextStatistics.LeastCommonWord("hello world hello"));
        Assert.Equal("test", InMindLab10.TextStatistics.LeastCommonWord("example example test"));
    }
}