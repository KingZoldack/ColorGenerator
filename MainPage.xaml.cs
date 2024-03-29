﻿
//using Android.Widget;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics;

namespace ColorGenerator
{
    public partial class MainPage : ContentPage
    {
        bool _isRandom = false;
        string _hexvale = "";
        const double width = 400; 
        const double height = 600;

        public MainPage()
        {
            InitializeComponent();

            this.Appearing += (sender, e) =>
            {
                if (Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
                {
                    Window.Width = width;
                    Window.Height = height;
                    Window.MinimumHeight = height;
                    Window.MaximumHeight = height;
                    Window.MaximumWidth = width;
                    Window.MinimumWidth = width;
                }
            };


        }

        private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!_isRandom) 
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);
                
                SelectColor(color);        
            }
        }

        private void SelectColor(Color color)
        {
            mainGrid.BackgroundColor = color;
            btnGenerate.Background = color;
            _hexvale = color.ToHex();
            lblHex.Text = $"Hex: {_hexvale}";
        }

        private void btnGenerate_Clicked(object sender, EventArgs e)
        {
            _isRandom = true;

            var randomNumber = new Random();

            Color color = Color.FromRgb(randomNumber.NextDouble(), randomNumber.NextDouble(), randomNumber.NextDouble());

            SelectColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;

            _isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(_hexvale);

            var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            toast?.Show();
        }

        private void imgbtnCopy_Pressed(object sender, EventArgs e)
        {
            imgbtnCopy.Opacity = 0.5;
        }

        private void imgbtnCopy_Released(object sender, EventArgs e)
        {
            imgbtnCopy.Opacity = 1;
        }
    }

}
