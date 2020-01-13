using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DromParser.Core.Dromjke
{
    class DromParserMain : IParser<ObservableCollection<Car>>
    {
        public ObservableCollection<Car> ParsePage(IHtmlDocument document)
        {
            var newlist = new ObservableCollection<Car>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && (item.ClassName.Contains("b-advItem b-advItem_pinned") || item.ClassName.Contains("b-advItem") || item.ClassName.Contains("b-advItem b-advItem_upped"))).OfType<IHtmlAnchorElement>();
            foreach (var item in items)
            {
                newlist.Add(new Car(item.GetAttribute("href")));
            }
            return newlist;
        }
        public ObservableCollection<Car> Parse(IHtmlDocument document, string carUrl, string keywords)
        {
            var carList = new ObservableCollection<Car>();
            var newCar = new Car(carUrl);
            var items = document.QuerySelectorAll("p").Where(item => item.TextContent != null && item.TextContent.Contains(keywords));
            foreach (var item in items)
            {
                newCar.Text = item.TextContent;
                carList.Add(newCar);
                break;
            }
            return carList;
        }
    }
}
