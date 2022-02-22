/*
*
*   This class intentionally left blank.  
*   @author Michael Heron
*   @version 1.0
*   
*/
using System.Media;
using WMPLib;

namespace Shard
{
    public class Sound        
    {
        private SoundPlayer player;
        private WindowsMediaPlayer wPlayer;

        public Sound()
        {
            player = new SoundPlayer();
            wPlayer = new WindowsMediaPlayer();
        }

        //Plays a .wav file asynchronosly from the specified filepath
        public void PlaySound(string path)
        {
            Debug.Log(path);
            if (path.EndsWith(".mp3"))
            {
                wPlayer.URL = path;
                wPlayer.controls.play();
            } else if (path.EndsWith(".wav"))
            {
                player.SoundLocation = path;
                player.Play();
            }
            
            
        }

        //Plays a .wav file synchronosly from the specified filepath
        public void PlaySoundSync(string path)
        {
            player.SoundLocation = path;
            player.PlaySync();
        }

        public void Stop()
        {
            wPlayer.controls.stop();
            player.Stop();
        }

    }
}
