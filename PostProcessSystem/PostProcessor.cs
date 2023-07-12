namespace JuhaKurisu.PostProcessSystem;

public class PostProcessor<T> : IPostProcessor<T>
{
    public T PostProcess(T value)
    {
        return value;
    }
}