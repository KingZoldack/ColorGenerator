
//using Android.Widget;
using System.Diagnostics;

namespace ColorGenerator
{
    public partial class MainPage : ContentPage
    {
        bool _isRandom = false;
        string _hexvale = "";

        public MainPage()
        {
            InitializeComponent();
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
            lblHex.Text = _hexvale;
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

    }

}
