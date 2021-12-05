using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace TTS
{
    class Program
    {
        static void Main(string[] args)
        {
            var synthesizer = new SpeechSynthesizer();
            foreach (var arg in args)
            {
                if (arg.Contains("-l")){
                    foreach (var voice in synthesizer.GetInstalledVoices())
                    {
                        var info = voice.VoiceInfo;
                        Console.WriteLine($"{info.Name}|{ info.Culture}");
                    }
                    Environment.Exit(0);
                }
            }
            String text = "";
            if (args.Length >= 1)
            {
                if (args.Length == 2)
                {
                    synthesizer.SelectVoice(args[1]);
                }
                text = args[0];
                synthesizer.Speak(text);
            }
            else {
                Console.WriteLine("Usage: tts.exe text voice");
                Console.WriteLine("-l list installed voices");
                Environment.Exit(-1);
            }
        }
    }
}
