using JuhaKurisu.PostProcessSystem;
using Sample;

var postProcessor = new PostProcessor<int>(
    new ExecutionOrderConstraint(typeof(TestMultiplier), typeof(TestAdder))
)
{
    PostProcessors = new IPostProcessor<int>[]
    {
        new TestMultiplier(),
        new TestAdder()
    }.ToHashSet()
};

if (int.TryParse(Console.ReadLine(), out var value))
    Console.WriteLine(postProcessor.PostProcess(value));
else
    Console.WriteLine("Parse Error!!!!");