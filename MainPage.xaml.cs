
using System.Diagnostics;

namespace ColorGenerator
{
    public partial class MainPage : ContentPage
    {
        bool _isRandom = false;

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
            lblHex.Text = color.ToHex();
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
    }

}
