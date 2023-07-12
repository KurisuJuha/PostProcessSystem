using System.Collections.ObjectModel;

namespace JuhaKurisu.PostProcessSystem;

public class PostProcessor<T> : IPostProcessor<T>
{
    public readonly IReadOnlyCollection<ExecutionOrderConstraint> Constraints;
    public IPostProcessor<T>[] PostProcessors;

    public PostProcessor(params ExecutionOrderConstraint[] constraints)
    {
        Constraints = new ReadOnlyCollection<ExecutionOrderConstraint>(constraints);
        PostProcessors = Array.Empty<IPostProcessor<T>>();
    }

    public T PostProcess(T value)
    {
        return PostProcessors.Aggregate(value, (current, postProcessor) => postProcessor.PostProcess(current));
    }
}