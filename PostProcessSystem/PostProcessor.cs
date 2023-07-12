namespace JuhaKurisu.PostProcessSystem;

public class PostProcessor<T> : IPostProcessor<T>
{
    private readonly HashSet<(Type, Type)> _edges = new();
    public HashSet<IPostProcessor<T>> PostProcessors = new();

    public PostProcessor(params ExecutionOrderConstraint[] constraints)
    {
        foreach (var constraint in constraints)
        foreach (var dependence in constraint.Dependencies)
            _edges.Add((constraint.Target, dependence));
    }

    public T PostProcess(T value)
    {
        var sortedPostProcessors = new List<IPostProcessor<T>>();
        var postProcessorReferenceCount = new Dictionary<IPostProcessor<T>, int>();

        foreach (var postProcessor in PostProcessors)
            postProcessorReferenceCount[postProcessor] =
                _edges.Count(edge => TypeEqual(postProcessor.GetType(), edge.Item2));

        var freePostProcessors = postProcessorReferenceCount.Where(pair => pair.Value == 0).Select(pair => pair.Key)
            .ToList();

        while (freePostProcessors.Any())
        {
            var targetPostProcess = freePostProcessors.First();
            freePostProcessors.RemoveAt(0);

            foreach (var edge in _edges.Where(edge => TypeEqual(targetPostProcess.GetType(), edge.Item1)))
            foreach (var nextTargetPostProcess in PostProcessors.Where(postProcess =>
                         TypeEqual(postProcess.GetType(), edge.Item2)))
            {
                postProcessorReferenceCount[nextTargetPostProcess]--;
                if (postProcessorReferenceCount[nextTargetPostProcess] == 0)
                    freePostProcessors.Add(nextTargetPostProcess);
            }

            sortedPostProcessors.Add(targetPostProcess);
        }

        foreach (var edge in _edges) Console.WriteLine(edge.ToString());
        foreach (var postProcess in freePostProcessors) Console.WriteLine(postProcess.GetType());
        foreach (var postProcessor in sortedPostProcessors) Console.WriteLine(postProcessor.GetType());

        return PostProcessors.Aggregate(value, (current, postProcessor) => postProcessor.PostProcess(current));
    }

    private bool TypeEqual(Type type1, Type type2)
    {
        return type1.IsSubclassOf(type2) || type1 == type2;
    }
}