using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;


namespace PSFinder.src
{
    public class Amazon : Store
    {

        private List<string> availableIds = new List<string>();
        public Amazon() {
            this.name = "Amazon";
        }
        List<string> ids = new List<string>{"B08H95Y452", "B08H97NYGP"};
        
        override async public Task<bool> TakeStock() {   
            var pageTasks = ids.Select(id => checkPage(id));
            var pages = await Task.WhenAll(pageTasks);
            var inStockPages = pages.Where(x => x == true).ToList();
            this.stockCheckPassed = true;
            this.hasPs5Stock = inStockPages.Count > 0;
            return inStockPages.Count > 0;
        }

        async private Task<string> getPage(string id)
        {
            string url = $"https://www.amazon.co.uk/dp/{id}";
            var result = await url.GetAsync();
            return await result.GetStringAsync();
        }

        async private Task<bool> checkPage(string id)
        {
            string page = await getPage(id);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(page); 
            var availability = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"availability\"]/span");
            var stockMessage = availability.FirstChild.InnerHtml.ToString().Trim();	
            return !stockMessage.Equals("Currently unavailable.");
        }
    }
}