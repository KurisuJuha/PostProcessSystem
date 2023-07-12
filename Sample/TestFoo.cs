using JuhaKurisu.PostProcessSystem;

namespace Sample;

public class TestFoo : IPostProcessor<string>
{
    public string PostProcess(string value)
    {
        return value + "Foo";
    }
}