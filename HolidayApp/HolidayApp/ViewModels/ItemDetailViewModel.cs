using System;
using System.Collections.Generic;
using HolidayApp.ApiManagement;
using HolidayApp.Models;

namespace HolidayApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private IEnumerable<NagerLongWeekend> longWeekends;

        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }

        public IEnumerable<NagerLongWeekend> LongWeekends
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
            var client = new NagerClient();
            LongWeekends = await client.GetLongWeekendAsync(Item.Id, DateTime.Now.Year.ToString());
        }
    }
}
