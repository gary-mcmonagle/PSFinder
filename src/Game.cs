using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;
using Newtonsoft.Json;
namespace PSFinder.src
{
    public class Game : Store
    {
        public Game() {
            this.name = "Game";
        }
        override async public Task<bool> TakeStock() {
            await checkPage();
            return true;
        }


        private async Task<string> getPage() {
            string url = "https://assets.game.net/_master/hardwarePages/playstation5/merch/210521/ps5.js";
            var result = await url.GetAsync();
            return await result.GetStringAsync();
        }

        async private Task<bool> checkPage()
        {
            string page = await getPage();

            var startLookup = "var contentPanelsThree =";
            var endLookUp = "buildContentPanel(contentPanelsThree, '3');";
            var startIndex = page.IndexOf(startLookup);
            var endIndex = page.IndexOf(endLookUp);
            var json = page.Substring(page.IndexOf(startLookup), endIndex - startIndex).Replace(startLookup, "");
            var panels = JsonConvert.DeserializeObject<Panel[]>(json);
            foreach (Panel panel in panels) {
                if(!panel.button.copy.Equals("Out of stock")) {
                    this.hasPs5Stock = true;
                }
            }
            this.stockCheckPassed = true;
            return true;
        }
    }

    class Panel {
        public Button button { get; set; }
    }
    class Button {
        public string copy;
    }
}