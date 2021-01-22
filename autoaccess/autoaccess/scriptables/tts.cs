using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace autoaccess.scriptables
{
    public class tts
    {
        public async void speak(params object[] messages)
        {
            foreach(var message in messages)
            {
                if (message == null)
                {
                    await TextToSpeech.SpeakAsync("null value");
                    return;
                }
await TextToSpeech.SpeakAsync(message.ToString());
            }
        }//func
    }//class
}//namespace
