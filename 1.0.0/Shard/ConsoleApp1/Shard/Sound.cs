/*
*
*   This class intentionally left blank.  
*   @author Michael Heron
*   @version 1.0
*   
*/

using System.Media;

namespace Shard
{
    public class Sound        
    {
        private SoundPlayer player;

        public Sound()
        {
            player = new SoundPlayer();
        }

        //Plays a .wav file asynchronosly from the specified filepath
        public void PlaySound(string path)
        {
            player.SoundLocation = path;
            player.Play();
        }

        //Plays a .wav file synchronosly from the specified filepath
        public void PlaySoundSync(string path)
        {
            player.SoundLocation = path;
            player.PlaySync();
        }

    }
}
