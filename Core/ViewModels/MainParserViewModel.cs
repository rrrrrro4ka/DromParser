using DromParser.Core.Dromjke;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DromParser.Core.ViewModels
{
    class MainParserViewModel : BaseViewModel
    {
        ParserWorker<ObservableCollection<Car>> parser;
        private string min_price;
        private string max_price;
        private int start_point;
        private int end_point;
        private string brand_auto;
        PrivodCars.Privod privod_auto;
        private DelegateCommand start_fun;
        private DelegateCommand end_fun;
        private Car car_info;
        private ObservableCollection<Car> result_parse;
        private ObservableCollection<string> comboBoxCar;
        private PrivodCars.Privod[] privodCar;
        private string search_key;
        #region Property
        public string MinPrice
        {
            get
            {
                return min_price;
            }
            set
            {
                min_price = value;
                OnPropertyChanged(nameof(MinPrice));
                start_fun.RaiseCanExecuteChanged();
            }
        }
        public string MaxPrice
        {
            get
            {
                return max_price;
            }
            set
            {
                max_price = value;
                OnPropertyChanged(nameof(MaxPrice));
                start_fun.RaiseCanExecuteChanged();
            }
        }
        public int StartPoint
        {
            get
            {
                return start_point;
            }
            set
            {
                start_point = value;
                OnPropertyChanged(nameof(StartPoint));
            }
        }
        public int EndPoint
        {
            get
            {
                return end_point;
            }
            set
            {
                end_point = value;
                OnPropertyChanged(nameof(EndPoint));
            }
        }
        public string Brand
        {
            get
            {
                return brand_auto;
            }
            set
            {
                brand_auto = value;
                OnPropertyChanged(nameof(brand_auto));
            }
        }
        public ObservableCollection<Car> CarsInformation
        {
            get
            {
                return result_parse;
            }
            set
            {
                result_parse = value;
                OnPropertyChanged(nameof(result_parse));
            }
        }
        public Car CarInfo
        {
            get
            {
                return car_info;
            }
            set
            {
                if (value != car_info)
                {
                    car_info = value;
                    OnPropertyChanged(nameof(CarInfo));
                }
            }
        }
        public ObservableCollection<string> ComboBoxCar
        {
            get
            {
                return comboBoxCar;
            }
        }
        public PrivodCars.Privod[] PrivodCar
        {
            get
            {
                return privodCar;
            }
        }
        public PrivodCars.Privod Privod
        {
            get
            {
                return privod_auto;
            }
            set
            {
                privod_auto = value;
                OnPropertyChanged(nameof(privod_auto));
            }
        }
        public string SearchKey
        {
            get
            {
                return search_key;
            }
            set
            {
                search_key = value;
                OnPropertyChanged(nameof(SearchKey));
                start_fun.RaiseCanExecuteChanged();
            }
        }
        #endregion

        public MainParserViewModel()
        {
            BrandCars brandCars = new BrandCars();
            comboBoxCar = brandCars.BrandCar;
            privodCar = new PrivodCars.Privod[] {
                PrivodCars.Privod.back,
                PrivodCars.Privod.forward,
                PrivodCars.Privod.WD
            };
            parser = new ParserWorker<ObservableCollection<Car>>(
                new DromParserMain()
                );
            result_parse = new ObservableCollection<Car>();
            parser.OnNewData += Parse_OnNewData;
            parser.OnCompleted += Parser_OnComleted;
        }
        private void Parse_OnNewData(object arg1, ObservableCollection<Car> arg2)
        {
            foreach (Car item in arg2)
            {
                result_parse.Add(item);
            }
        }
        private void Parser_OnComleted(object obj)
        {
            MessageBox.Show("Well Done!");
        }
        public DelegateCommand StartingParser
        {
            get
            {
                return start_fun = new DelegateCommand(StartParser, CanStartParser);
            }
        }
        private void StartParser(object args)
        {
            int privod_car = (int)(object)Privod;
            parser.Settings = new DromSettings(StartPoint, EndPoint, MinPrice, MaxPrice, Brand, privod_car.ToString());
            parser.Start(SearchKey);
        }
        private bool CanStartParser(object args)
        {
            if (String.IsNullOrEmpty(MinPrice) || String.IsNullOrEmpty(MaxPrice) || String.IsNullOrEmpty(SearchKey))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DelegateCommand StopParsering
        {
            get
            {
                return end_fun = new DelegateCommand(param => StopParser());
            }
        }
        private void StopParser()
        {
            parser.Abort();
            result_parse.Clear();
        }
    }
}
