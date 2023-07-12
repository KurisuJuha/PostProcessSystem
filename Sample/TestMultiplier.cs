using JuhaKurisu.PostProcessSystem;

namespace Sample;

public class TestMultiplier : IPostProcessor<int>
{
    public int PostProcess(int value)
    {
        return value * 10;
    }
}