﻿using System.Collections.ObjectModel;
using HolidayApp.ApiManagement;
using HolidayApp.Models;

namespace HolidayApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }


        private ObservableCollection<NagerHoliday> _holiday;

        public ObservableCollection<NagerHoliday> Holidays
        {
            get { return _holiday; }
            set
            {
                if(value != _holiday)
                {
                    _holiday = value;
                    OnPropertyChanged();
                }
            }
        }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;

            GetHolidays();
        }

        private async void GetHolidays()
        {
            var client = new NagerClient();

            var result = await client.GetHolidaysAsync(Item.Id, "2019");

            Holidays = new ObservableCollection<NagerHoliday>();

            foreach (var item in result)
            {
                Holidays.Add(item);
            }
        }
    }
}
