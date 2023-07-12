using JuhaKurisu.PostProcessSystem;

namespace Sample;

public class TestHoge : IPostProcessor<string>
{
    public string PostProcess(string value)
    {
        return value + "Hoge";
    }
}