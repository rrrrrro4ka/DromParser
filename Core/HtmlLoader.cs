using DromParser.Core.Dromjke;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DromParser.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            if (settings.Brand != null && settings.Privod != null)
            {
                url = $"{settings.BaseUrlWithBrand}/{settings.Brand}/all/{settings.Prefix}/?minprice={settings.MinPrice}&maxprice={settings.MaxPrice}&privod={settings.Privod}";
            }
            if (settings.Brand != null && settings.Privod == null)
            {
                url = $"{settings.BaseUrlWithBrand}/{settings.Brand}/all/{settings.Prefix}/?minprice={settings.MinPrice}&maxprice={settings.MaxPrice}";
            }
            if (settings.Brand == null && settings.Privod != null)
            {
                url = $"{settings.BaseUrl}/{settings.Prefix}/?minprice={settings.MinPrice}&maxprice={settings.MaxPrice}&privod={settings.Privod}";
            }
            if (settings.Brand == null && settings.Privod == null)
            {
                url = $"{settings.BaseUrl}/{settings.Prefix}/?minprice={settings.MinPrice}&maxprice={settings.MaxPrice}";
            }
        }
        public HtmlLoader()
        {
            client = new HttpClient();
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            string currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
        public async Task<string> GetSourceByPage(string urlCar)
        {
            string currentUrl = $"{urlCar}";
            var responce = await client.GetAsync(currentUrl);
            string source = null;
            if (responce != null && responce.StatusCode == HttpStatusCode.OK)
            {
                source = await responce.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
