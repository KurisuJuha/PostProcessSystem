namespace JuhaKurisu.PostProcessSystem;

public interface IPostProcessor<T>
{
    public T PostProcess(T value);
}