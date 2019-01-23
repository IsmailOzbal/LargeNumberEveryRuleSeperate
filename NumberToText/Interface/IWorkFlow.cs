

namespace NumberToText.Interface
{
    public interface IWorkFlow<in T1, out T2>
    {
        T2 Manage(T1 number);
    }
}
