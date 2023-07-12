using JuhaKurisu.PostProcessSystem;

namespace Sample;

public class TestMultiplier : IPostProcessor<string>
{
    public string PostProcess(string value)
    {
        return value + "Multiplier";
    }
}