using autoaccess.scriptables;
using NLua;
using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace autoaccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RunCodePage : ContentPage
    {
        Lua LuaState { get; set; }
        public RunCodePage(string Code = "")
        {
            InitializeComponent();
            InitLua();
            edCode.Text = Code;
        }

        private void InitLua()
        {
            LuaState = new Lua();
            LuaState.LoadCLRPackage();
            LuaState.RegisterFunction("print", this, this.GetType().GetMethod("print"));

            LuaState["tts"] = new tts();
            LuaState["PowerIndicator"] = new PowerIndicator();
            LuaState["VibrationService"] = new VibrationService();
        }
        public async void print(params object[] values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var param in values)
            {
                if (param == null)
                {
                    sb.Append("nill\n");
                    continue;
                }
                sb.Append(param.ToString() + "\n");
            }
            await DisplayAlert("program output", sb.ToString(), "OK");
        }
        async void btnStartCode_Clicked(object sender, EventArgs e)
        {
            try
            {
                LuaState.DoString(edCode.Text);
            }
            catch (Exception exc)
            {
                await DisplayAlert("error", $"A fatal error was incountered while running your code\nException details:\n\tException type: {exc.GetType().ToString()}\n\terror message from interpreter:{exc.Message}.", "OK");
            }
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            edCode.Text = string.Empty;
            InitLua();

        }
    }
}