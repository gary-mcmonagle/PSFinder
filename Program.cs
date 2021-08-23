using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PSFinder.src;
using System.Linq;



namespace PSFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();            
        }

        static async Task MainAsync(string[] args)
        {

            List<Store> stores = new List<Store>{
                new Amazon(),
                new JohnLewis()
            };
            var stockTasks = stores.Select(store => store.TakeStock()).ToList();
            await Task.WhenAll(stockTasks);

            var stockMessages = stores.Select(store => store.StockAlert).ToList();


            StockReporter sr = new StockReporter(stores);
            sr.GenerateReport();
        }

    }
}
