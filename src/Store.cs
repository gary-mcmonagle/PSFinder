using System.Threading.Tasks;
namespace PSFinder.src

{
    abstract public class Store
    {
        private protected string name = "";
        private protected string stockAlert = "";
        private protected bool hasPs5Stock = false;

        private protected bool stockCheckPassed = false;

        abstract public Task<bool> TakeStock();
        public string Name
        {
            get { return  name; }
        }
        public string StockAlert
        {
            get { return getStockMessage(); }
        }
        public bool HasPs5Stock
        {
            get { return hasPs5Stock; }
        }


        private protected string getStockMessage() {
            if(!this.stockCheckPassed) {
                return $"Could not get stock for {name}";
            }
            if(hasPs5Stock) {
                return "In Stock";
            }
            return $"No stock available at {name}";
        }

    }
}