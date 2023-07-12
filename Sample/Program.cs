using JuhaKurisu.PostProcessSystem;
using Sample;

var postProcessor = new PostProcessor<string>(
    new ExecutionOrderConstraint(typeof(TestAdder), typeof(TestMultiplier)),
    new ExecutionOrderConstraint(typeof(TestMultiplier), typeof(TestAdder))
)
{
    PostProcessors = new IPostProcessor<string>[]
    {
        new TestMultiplier(),
        new TestAdder(),
        new TestHoge(),
        new TestFoo()
    }.ToHashSet()
};

Console.WriteLine(postProcessor.PostProcess(Console.ReadLine() ?? ""));