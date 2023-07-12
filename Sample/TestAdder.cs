using JuhaKurisu.PostProcessSystem;

namespace Sample;

public class TestAdder : IPostProcessor<int>
{
    public int PostProcess(int value)
    {
        return value + 1;
    }
}