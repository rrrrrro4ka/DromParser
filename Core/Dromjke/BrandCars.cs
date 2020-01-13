using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DromParser.Core.Dromjke
{
    class BrandCars
    {
        ObservableCollection<string> brand_cars = new ObservableCollection<string>
            {
                "toyota",
                "mercedes-benz",
                "nissan",
                "honda",
                "mitsubishi",
                "bmw",
                "volkswagen",
                "ford",
                "infiniti",
                "volvo",
                "porsche",
                "kia",
                "land_rover",
                "subaru",
                "skoda",
                "hyundai",
                "mazda",
                "lexus",
                "jaguar",
                "cadillac",
                "chrysler",
                "audi",
                "chevrolet"
            };
        public ObservableCollection<string> BrandCar
        {
            get
            {
                return brand_cars;
            }
        }
    }
}
