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
            for(int i=0;i<messages.Length;i++)
            {
                if (i == null)
                {
                    await TextToSpeech.SpeakAsync("null value");
                    return;
                }
await TextToSpeech.SpeakAsync(messages[i].ToString());
            }
        }//func
    }//class
}//namespace
