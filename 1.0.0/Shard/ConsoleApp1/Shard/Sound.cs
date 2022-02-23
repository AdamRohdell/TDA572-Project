/*
*
*   This class intentionally left blank.  
*   @author Michael Heron
*   @version 1.0
*   
*/
using System.Media;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace Shard
{
    public class Sound        
    {
        private SoundPlayer player;
        private byte[][] soundFiles;
        private MemoryStream ms;
        private Dictionary<string, int> soundNames;
        private int soundCount = 0;



        public Sound()
        {
            soundFiles = new byte[32][];
            soundNames = new Dictionary<string, int>();
            player = new SoundPlayer();
        }


        //Load all the sounds that you want to use in your game, up to 32 sounds can currently be loaded.
        public void LoadSound(string path, string name)
        {
            if (soundCount == 32)
            {
                throw new System.Exception("Too many sounds loaded! Unload some sounds to free up space.");
            }
            Debug.Log(path);
            soundFiles[soundCount] = File.ReadAllBytes(path);
            soundNames.Add(name, soundCount);
            soundCount++;
        }

        //Plays a .wav file asynchronosly from the specified filepath
        public void PlaySound(string name)
        {
            int index = soundNames[name];
            ms = new MemoryStream(soundFiles[index]);
            player.Stream = ms;
            player.Play();
        }


        //Overloaded function to allow you to play sound at a specific location for spatial sound effects.
        public void PlaySound(string name, int x, int y, GameObject player)
        {
            
        }

        //Plays a .wav file synchronosly from the specified filepath
        public void PlaySoundSync(string path)
        {
            player.SoundLocation = path;
            player.PlaySync();
        }

        public void UnloadSound(string name)
        {
            //TODO: ADD UNLOAD FUNCTIONALITY HERE
        }

        public void Stop()
        {
            player.Stop();
            
        }

    }
}
