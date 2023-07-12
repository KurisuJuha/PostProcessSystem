using System.Collections.ObjectModel;

namespace JuhaKurisu.PostProcessSystem;

public class ExecutionOrderConstraint
{
    public readonly ReadOnlyCollection<Type> Dependencies;
    public readonly Type Target;

    public ExecutionOrderConstraint(Type target, params Type[] dependencies)
    {
        Target = target;
        Dependencies = new ReadOnlyCollection<Type>(dependencies);
    }
}