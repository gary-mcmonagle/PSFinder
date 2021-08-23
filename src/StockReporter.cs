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

        public string getHtmlForStoreAlert(Store store) {
            string html = $"<div><h1>{store.Name}</h1> ";
            if(!store.SuccessfulStockCheck) {
                html += "<div><p>Failed getting stock</p></div>";
            }
            else {
                html += $"<div><p>{store.StockAlert}</p></div>";
            }
            html += "</div>";
            return html;
        }


        public void GenerateReport() {


            string emailHtml = "";
            foreach (Store store in this.stores) {
                emailHtml += getHtmlForStoreAlert(store);

            }
            File.WriteAllText("email.html", emailHtml);
        }
    }
}