using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
namespace autoaccess
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnRun_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RunCodePage());
        }

        private async void btnLoadFile_Clicked(object sender, EventArgs e)
        {
            string FileText = "";
            var file = await FilePicker.PickAsync();
            if (file == null)
            {
                await DisplayAlert("error", "you didn't select any file.\nPlease choose a file, then try again", "OK");
                return;
            }

            var stream = await file.OpenReadAsync();
            using (var sr = new StreamReader(stream))
            {
                FileText = sr.ReadToEnd();
            }
            
await Navigation.PushAsync(new RunCodePage(FileText));
        }
    }
}
