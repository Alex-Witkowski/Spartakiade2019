using System;
using HolidayApp.Api;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HolidayApp.Models;
using HolidayApp.ViewModels;

namespace HolidayApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadData();
        }
    }
}