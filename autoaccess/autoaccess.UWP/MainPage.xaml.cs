namespace autoaccess.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new autoaccess.App());
        }
    }
}
