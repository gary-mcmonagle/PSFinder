using System.Threading.Tasks;
namespace PSFinder.src
{
    public interface IStore
    {
        Task<bool> PlaystationIsAvailable();
        string Name { get; }
        string StockAlert { get; }
    }
}