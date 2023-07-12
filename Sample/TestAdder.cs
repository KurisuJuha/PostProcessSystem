using JuhaKurisu.PostProcessSystem;

namespace Sample;

public class TestAdder : IPostProcessor<string>
{
    public string PostProcess(string value)
    {
        return value + "Adder";
    }
}