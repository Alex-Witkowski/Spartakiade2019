using System;
using System.Collections.Generic;
using HolidayApp.Api;
using HolidayApp.Models;

namespace HolidayApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private IEnumerable<Holiday> holidays;

        public Country Item { get; set; }

        public ItemDetailViewModel(Country item = null)
        {
            Title = item?.key;
            Item = item;
        }
        public IEnumerable<Holiday> Holidays
        {
            get => holidays;
            set
            {
                if (holidays != value)
                {
                    holidays = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void LoadData()
        {
            var client = new Client();
            Holidays = await client.GetPublicHolidays(DateTime.Now.Year, Item.key);
        }
    }
}
