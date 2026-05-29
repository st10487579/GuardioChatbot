using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace GuardioChatbot
{
    // START OF NAMESPACE
    public class VoiceGreeting
    {
        // METHOD TO PLAY GREETING SOUND
        public void Greet()
        {
            try
            {
                // GET PROJECT DIRECTORY AND LOAD voice.wav
                string autoPath =
                    AppDomain.CurrentDomain.BaseDirectory
                    + "voice.wav";

                // CREATE SOUND PLAYER
                SoundPlayer greetMe =
                    new SoundPlayer(autoPath);

                // PLAY SOUND
                greetMe.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Error playing sound: "
                    + ex.Message);
            }
        }
    }
}