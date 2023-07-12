using JuhaKurisu.PostProcessSystem;
using Sample;

PostProcessor<int> postProcessor = new PostProcessor<int>();
postProcessor.PostProcessors = new IPostProcessor<int>[]
{
    new TestAdder(),
    new TestMultiplier(),
};

if (int.TryParse(Console.ReadLine(), out var value))
{
    Console.WriteLine(postProcessor.PostProcess(value));   
}
else
{
    Console.WriteLine("Parse Error!!!!");
}