using System.Collections.ObjectModel;

namespace JuhaKurisu.PostProcessSystem;

public class ExecutionOrderConstraint
{
    public readonly Type Target;
    public readonly IReadOnlyCollection<Type> Dependencies;

    public ExecutionOrderConstraint(Type target, params Type[] dependencies)
    {
        Target = target;
        Dependencies = new ReadOnlyCollection<Type>(dependencies);
    }
}