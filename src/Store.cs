using System.Threading.Tasks;
namespace PSFinder.src

{
    abstract public class Store
    {
        private protected string name = "";
        private protected string stockAlert = "";
        private protected bool hasStock = false;

        abstract public Task<bool> TakeStock();
        public string Name
        {
            get { return  name; }
        }
        public string StockAlert
        {
            get { return getStockMessage(); }
        }
        public bool HasStock
        {
            get { return hasStock; }
        }


        private protected string getStockMessage() {
            if(hasStock) {
                return "In Stock";
            }
            return $"No stock available at {name}";
        }

    }
}