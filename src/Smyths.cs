using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;
namespace PSFinder.src
{
    public class Smyths : Store
    {
        public Smyths() {
            this.name = "Smyths";
        }
        override async public Task<bool> TakeStock() {
            return true;
        }
    }
}