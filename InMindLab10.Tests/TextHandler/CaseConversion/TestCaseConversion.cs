using Xunit;
using InMindLab10;

namespace InMindLab10.Tests.TextHandler.CaseConversion;

public class TestCaseConversion
{
    [Fact]
    public void TestToSnakeCase()
    {
        Assert.Equal("hello_world", InMindLab10.TextFormatter.ToSnakeCase("hello world"));
        Assert.Equal("my_text_example", InMindLab10.TextFormatter.ToSnakeCase("MyText Example"));
    }

    [Fact]
    public void TestToPascalCase()
    {
        Assert.Equal("HelloWorld", InMindLab10.TextFormatter.ToPascalCase("hello world"));
        Assert.Equal("MyTextExample", InMindLab10.TextFormatter.ToPascalCase("my_text-example"));
    }

    [Fact]
    public void TestToKebabCase()
    {
        Assert.Equal("hello-world", InMindLab10.TextFormatter.ToKebabCase("HelloWorld"));
        Assert.Equal("my-text-example", InMindLab10.TextFormatter.ToKebabCase("MyText Example"));
    }

    [Fact]
    public void TestToCamelCase()
    {
        Assert.Equal("helloWorld", InMindLab10.TextFormatter.ToCamelCase("hello world"));
        Assert.Equal("myTextExample", InMindLab10.TextFormatter.ToCamelCase("my_text-example"));
    }
}