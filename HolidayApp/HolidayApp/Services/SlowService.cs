using HolidayApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HolidayApp.Services
{
    public class SlowService
    {
        public SlowService()
        {
            MessagingCenter.Subscribe<ItemsViewModel>(this, "FirstPageLoaded", HandleFirstPageLoaded);
        }

        private async void HandleFirstPageLoaded(ItemsViewModel vm)
        {
            await Task.Delay(10000);
            vm.Items.Add(new Models.Item { Id = "42", Description = "async loaded item", Text = "new Item" });
        }

    }
}
