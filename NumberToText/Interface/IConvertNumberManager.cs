
namespace NumberToText.Interface
{
    public interface IConvertNumberManager<in T1, out T2>
    {
        T2 Manage(T1 number);
    }
}
