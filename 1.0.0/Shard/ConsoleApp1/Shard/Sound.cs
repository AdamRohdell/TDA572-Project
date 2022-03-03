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
        private List<SpatialSoundInstance> spatialSoundInstances;
        private int soundCount = 0;
        private int defaultVolume = 100;

        public Sound()
        {
            sounds = new Dictionary<string, IntPtr>();
            spatialSoundInstances = new List<SpatialSoundInstance>();

            SDL_mixer.Mix_OpenAudio(22050, SDL.AUDIO_S16SYS, 8, 4096);


            SDL_mixer.Mix_ReserveChannels(3);

            SDL_mixer.Mix_Volume(-1, defaultVolume);
        }


        //Load all the sounds that you want to use in your game
        public void LoadSound(string path, string name)
        {
            //   IntPtr chunk = SDL_mixer.Mix_LoadWAV(path);
            IntPtr chunk = SDL_mixer.Mix_LoadWAV(path);
            Debug.Log(chunk.ToString());
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
        public void PlaySound(string name, GameObject soundSource, GameObject player)
        {
            int nextAvailableChannel = 3;

            if (SDL_mixer.Mix_Playing(0) == 0)
            {
                nextAvailableChannel = 0;
            } else if (SDL_mixer.Mix_Playing(1) == 0)
            {
                nextAvailableChannel = 1;
            } else if (SDL_mixer.Mix_Playing(2) == 0)
            {
                nextAvailableChannel = 2;
            }

            if (nextAvailableChannel == 3)
            {
                throw new Exception("Too many spatial sounds active at once");
            }

            SpatialSoundInstance temp = spatialSoundInstances.Find(x => x.channel == nextAvailableChannel);
            if (temp != null)
            {
                spatialSoundInstances.Remove(temp);
            }

            spatialSoundInstances.Add(new SpatialSoundInstance(nextAvailableChannel, soundSource, player));

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


        // Gets run by Bootstrap to update the sound volumes and playbacks for spatial sounds.

        public void UpdateSpatialSounds()
        {
            foreach(SpatialSoundInstance s in spatialSoundInstances)
            {
                double Ypart = s.soundSource.Transform2D.Y - s.soundTarget.Transform2D.Y;
                double Xpart = s.soundSource.Transform2D.X - s.soundTarget.Transform2D.X;

                double distance = Math.Sqrt(Math.Pow(Ypart, 2) + Math.Pow(Xpart, 2)) + 0.1;

                double volMultiplier = Math.Log2(distance);

                double newVolume = 1 / volMultiplier;

                SDL_mixer.Mix_Volume(s.channel, (int)Math.Round(newVolume, MidpointRounding.AwayFromZero));
                
            }
        }





        private class SpatialSoundInstance
        {
            public int channel;
            public GameObject soundSource;
            public GameObject soundTarget;

            public SpatialSoundInstance(int c, GameObject sSource, GameObject sTarget)
            {
                channel = c;
                soundSource = sSource;
                soundTarget = sTarget;

            }
        }
    }
}


