
using NuGet.ContentModel;
using Xunit;
public class Testing
{
    [Fact]
    public void Test1()
    {

        string expectedvalue = "Please enter Patient ID";

        string actualvalue = "Please enter Patient ID";
        Assert.Contains(expectedvalue,actualvalue);

    }
}