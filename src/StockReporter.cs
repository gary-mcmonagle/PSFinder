using System;
using System.IO;
using System.Collections.Generic;
using PSFinder.src;
using System.Linq;

namespace PSFinder.src
{
    public class StockReporter
    {
        private List<Store> stores;
        public StockReporter(List<Store> stores) {
            this.stores = stores;
        }


        public void GenerateReport() {


            string email = "";
            foreach (Store store in this.stores) {
                email += store.StockAlert + "\n";
            }
            File.WriteAllText("email.html", email);
        }
    }
}