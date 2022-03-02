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
using SDL2;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace Shard
{
    public class Sound        
    {
        private byte[][] soundFiles;
        private MemoryStream ms;
        private Dictionary<string, IntPtr> sounds;
        private int soundCount = 0;

        public Sound()
        {
            SDL_mixer.Mix_OpenAudio(22050, SDL.AUDIO_S16SYS, 4, 4096);
        }


        //Load all the sounds that you want to use in your game
        public void LoadSound(string path, string name)
        {
            IntPtr chunk = SDL_mixer.Mix_LoadWAV(path);
            sounds.Add(name, chunk);
        }


        public void PlaySound(string name)
        {

            SDL_mixer.Mix_PlayChannel(-1, sounds[name], 0);
            
        }

        public void PlaySound(string name, int loopCount)
        {
            SDL_mixer.Mix_PlayChannel(-1, sounds[name], loopCount);
        }


        //Overloaded function to allow you to play sound at a specific location for spatial sound effects.
        public void PlaySound(string name, int x, int y, GameObject player)
        {
            
        }


        public void Pause()
        {
            SDL_mixer.Mix_Pause(-1);
        }

        public void Pause(int channel)
        {
            SDL_mixer.Mix_Pause(channel);
        }

        public void ChangeVolume(int volume)
        {
            SDL_mixer.Mix_Volume(-1, volume);
        }
        public void ChangeVolume(int volume, int channel)
        {
            SDL_mixer.Mix_Volume(channel, volume);
        }
    }
}
