using AngleSharp.Html.Dom;
using DromParser.Core.Dromjke;
using System.Collections.ObjectModel;

namespace DromParser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document, string carUrl, string keywords);
        ObservableCollection<Car> ParsePage(IHtmlDocument document);
    }
}
