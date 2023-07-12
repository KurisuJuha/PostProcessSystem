using System.Collections.ObjectModel;

namespace JuhaKurisu.PostProcessSystem;

public class PostProcessor<T> : IPostProcessor<T>
{
    public readonly IReadOnlyCollection<ExecutionOrderConstraint> Constraints;

    public PostProcessor(params ExecutionOrderConstraint[] constraints)
    {
        Constraints = new ReadOnlyCollection<ExecutionOrderConstraint>(constraints);
    }

    public T PostProcess(T value)
    {
        return value;
    }
}