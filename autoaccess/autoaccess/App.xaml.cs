using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace autoaccess
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("app_startup.wav");
            player.Play();
        }
        

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
    