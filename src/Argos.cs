using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;
namespace PSFinder.src
{
    public class Argos: Store
    {
        public Argos() {
            this.name = "Argos";
        }

        override async public Task<bool> TakeStock() {
            string url = $"https://www.argos.co.uk/product/8349024";
            var headers = new {
                host = "www.argos.co.uk",
                Accept = "*/*"
            };
            var result = await url
                .WithHeaders(headers)
                .WithAutoRedirect(false)
                .GetAsync();

            if(result.StatusCode == 302) {
                this.stockCheckPassed = true;
                this.hasPs5Stock = !result.Headers.FirstOrDefault("location").Equals("https://www.argos.co.uk/vp/oos/ps5.html");
            }
            return false;
        }
    }
}