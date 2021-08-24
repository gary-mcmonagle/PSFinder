using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;
namespace PSFinder.src
{
    public class JohnLewis: Store
    {
         public JohnLewis() {
            this.name = "JohnLewis";
        }
        override async public Task<bool> TakeStock() {
            return await checkPs5Stock();
        }

        async private Task<bool> checkPs5Stock() {
            string url = "https://api.johnlewis.com/catalogue/graphql?key=AIzaSyDtVsqXz2-LpOo5-RFYiAa2InbnSyfNZAM&query=query%20getByProductIds(%24productIds%3A%20String!%2C%20%24skuIds%3A%20String!)%20%7B%0A%20%20productsV2(where%3A%20%7B%20pimProductIds%3A%20%5B%24productIds%5D%20%7D)%20%7B%0A%20%20%20%20__typename%0A%20%20%20%20...%20on%20SimpleProduct%20%7B%0A%20%20%20%20%20%20productTypeHierarchy%0A%20%20%20%20%7D%0A%20%20%20%20...%20on%20CompositeBundle%20%7B%0A%20%20%20%20%20%20productTypeHierarchy%0A%20%20%20%20%7D%0A%20%20%20%20title%0A%20%20%20%20unitOfMeasure%0A%20%20%20%20variantPriceRange%20%7B%0A%20%20%20%20%20%20for%0A%20%20%20%20%20%20display%20%7B%0A%20%20%20%20%20%20%20%20min%0A%20%20%20%20%20%20%20%20max%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20value%20%7B%0A%20%20%20%20%20%20%20%20min%0A%20%20%20%20%20%20%20%20max%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20reductionHistory%20%7B%0A%20%20%20%20%20%20%20%20chronology%0A%20%20%20%20%20%20%20%20display%20%7B%0A%20%20%20%20%20%20%20%20%20%20min%0A%20%20%20%20%20%20%20%20%20%20max%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%7D%0A%20%20%20%20aliases%20%7B%0A%20%20%20%20%20%20pimProductId%0A%20%20%20%20%7D%0A%20%20%20%20browsePageHierarchy%20%7B%0A%20%20%20%20%20%20name%0A%20%20%20%20%7D%0A%20%20%20%20variants(where%3A%20%7B%20skuIds%3A%20%5B%24skuIds%5D%20%7D)%20%7B%0A%20%20%20%20%20%20...%20on%20CompositeBundleVariant%20%7B%0A%20%20%20%20%20%20%20%20aliases%20%7B%0A%20%20%20%20%20%20%20%20%20%20skuId%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20...%20on%20StaticBundleVariant%20%7B%0A%20%20%20%20%20%20%20%20aliases%20%7B%0A%20%20%20%20%20%20%20%20%20%20skuId%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20...%20on%20StockVariant%20%7B%0A%20%20%20%20%20%20%20%20aliases%20%7B%0A%20%20%20%20%20%20%20%20%20%20skuId%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%20%20differentiators%20%7B%0A%20%20%20%20%20%20%20%20%20%20colour%0A%20%20%20%20%20%20%20%20%20%20size%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20title%0A%20%20%20%20%20%20images%20%7B%0A%20%20%20%20%20%20%20%20primary%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20price%20%7B%0A%20%20%20%20%20%20%20%20for%0A%20%20%20%20%20%20%20%20value%0A%20%20%20%20%20%20%20%20display%0A%20%20%20%20%20%20%20%20reductionHistory%20%7B%0A%20%20%20%20%20%20%20%20%20%20chronology%0A%20%20%20%20%20%20%20%20%20%20value%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20availability%20%7B%0A%20%20%20%20%20%20%20%20availableToOrder%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20parentProduct%20%7B%0A%20%20%20%20%20%20%20%20variants%20%7B%0A%20%20%20%20%20%20%20%20%20%20availability%20%7B%0A%20%20%20%20%20%20%20%20%20%20%20%20availableToOrder%0A%20%20%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%7D%0A%20%20%20%20%7D%0A%20%20%20%20reviewSummary%20%7B%0A%20%20%20%20%20%20averageRating%0A%20%20%20%20%20%20numberOfReviews%0A%20%20%20%20%7D%0A%20%20%7D%0A%7D%0A&variables=%7B%22productIds%22:%225115192%22,%22skuIds%22:%22239052700%22%7D";
            var result = await url.GetJsonAsync<GraphQLResponse>();
            this.stockCheckPassed = true;
            this.hasPs5Stock = result.data.productsV2[0].variants[0].availability.availableToOrder;
            return result.data.productsV2[0].variants[0].availability.availableToOrder;
        }
    }

    public class GraphQLResponse {
        public Data data { get; set; }
    }

     public class Data {
       public ProductsV2[] productsV2 { get; set; }
    }

    public class ProductsV2 {
         public Variant[] variants { get; set; }
    }

    public class Variant {
        public Availability availability { get; set; }
        public string title { get; set; }

    }
    public class Availability {
        public bool availableToOrder { get; set; }
    }
}