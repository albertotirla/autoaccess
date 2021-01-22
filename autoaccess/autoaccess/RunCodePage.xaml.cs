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
//            LuaState["__page__"]=this;
            const string PrintFunctionCode = "function print(message) __page__:DisplayAlert(\"program output\", tostring(message), \"OK\") end";
            LuaState.LoadCLRPackage();
            LuaState.DoString(PrintFunctionCode);
                        
LuaState["tts"]=new tts();
            //LuaState.RegisterFunction("vibrate", this.GetType().GetMethod("Vibrate"));
            LuaState["PowerIndicator"] = new PowerIndicator();
            LuaState["VibrationService"] = new VibrationService();
        }   
public static async void speak(Object MessageToSpeak)
        {
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