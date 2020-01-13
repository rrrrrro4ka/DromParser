
namespace DromParser.Core.Dromjke
{
    class DromSettings : IParserSettings
    {
        public DromSettings(int start, int end, string min, string max, string brand, string privod)
        {
            StartPoint = start;
            EndPoint = end;
            MinPrice = min;
            MaxPrice = max;
            Brand = brand;
            Privod = privod;
        }
        public string BaseUrl { get; set; } = "https://auto.drom.ru/region54/all";
        public string BaseUrlWithBrand { get; set; } = "https://auto.drom.ru/region54";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string Brand { get; set; }
        public string Privod { get; set; }
    }
}
