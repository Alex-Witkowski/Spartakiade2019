using System;
using System.Collections.Generic;
using HolidayApp.Api;
using HolidayApp.Models;

namespace HolidayApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private IEnumerable<Weekend> longWeekends;

        public Country Item { get; set; }

        public ItemDetailViewModel(Country item = null)
        {
            Title = item?.key;
            Item = item;
        }
        public IEnumerable<Weekend> LongWeekends
        {
            get => longWeekends;
            set
            {
                if (longWeekends != value)
                {
                    longWeekends = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void LoadData()
        {
            var client = new Client();
            LongWeekends = await client.GetLongWeekends(DateTime.Now.Year, Item.key);
        }
    }
}
