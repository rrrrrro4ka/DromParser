using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DromParser.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }
        string BaseUrlWithBrand { get; set; }
        string Prefix { get; set; }
        int StartPoint { get; set; }
        int EndPoint { get; set; }
        string MinPrice { get; set; }
        string MaxPrice { get; set; }
        string Brand { get; set; }
        string Privod { get; set; }
    }
}
