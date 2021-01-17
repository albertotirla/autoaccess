using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using NLua;
using autoaccess.scriptables;

namespace autoaccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RunCodePage : ContentPage
    {
        Lua LuaState { get; set; }
        public RunCodePage( string Code="")
        {
            InitializeComponent();
            InitLua();
            edCode.Text = Code;
        }

        private void InitLua()
        {
            LuaState = new Lua();
            LuaState["__page__"]=this;
            /*
             * because of the nature of alert displaying support in xamarin.forms, we need the screen we're on to call it, since it's a method implemented in the ContentPage base class.
             * for now, I decided to implement the print function which almost every lua script expects with a redirect to the DisplayAlert method. But as I want to be compatible with other interpreters, at least on this one, the function needs to be static in .net terminology.
             * So, I will put the current instance of the ContentPage class(this keyword) in the global table with a weird name, then I'll run some lua code at startup to create the tipical print function one will expect from other interpreters.
             */
            const string PrintFunctionCode = "function print(message) __page__:DisplayAlert(\"program output\", tostring(message), \"OK\") end";
            LuaState.LoadCLRPackage();
            LuaState.DoString(PrintFunctionCode);
                        LuaState.RegisterFunction("speak", this.GetType().GetMethod("speak"));
            //LuaState.RegisterFunction("vibrate", this.GetType().GetMethod("Vibrate"));
            LuaState["PowerIndicator"] = new PowerIndicator();
            LuaState["VibrationService"] = new VibrationService();
        }   

        public static async void speak(Object MessageToSpeak)
        {
            if (MessageToSpeak == null)
            {
                await TextToSpeech.SpeakAsync("null value");
                return;
            }
            await TextToSpeech.SpeakAsync(MessageToSpeak.ToString());
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
            //await DisplayAlert("information", $"the code you were about to run is:\n{edCode.Text}", "OK");
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            edCode.Text = string.Empty;
            InitLua();
        
        }
    }
}