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
        private List<int> availableChannels = new List<int>() {0,1,2,3,4,5,6,7 };
        private SDL_mixer.ChannelFinishedDelegate channelFinished;

        private bool spatialMusic = false;
        private GameObject spatialMusicSource;
        private GameObject spatialMusicTarget;

        public Sound()
        {
            sounds = new Dictionary<string, IntPtr>();
            spatialSoundInstances = new List<SpatialSoundInstance>();

            SDL_mixer.Mix_OpenAudio(22050, SDL.AUDIO_S16SYS, 8, 4096);

            SDL_mixer.Mix_Init(SDL_mixer.MIX_InitFlags.MIX_INIT_MP3);


            channelFinished = x => { availableChannels.Add(x); };
            SDL_mixer.Mix_ChannelFinished(channelFinished);

            SDL_mixer.Mix_Volume(-1, defaultVolume);


        }


        //Load all the sounds that you want to use in your game
        public void LoadSound(string path, string name)
        {

            IntPtr chunk = IntPtr.Zero;
          
            if (path.EndsWith(".mp3"))
            {
                chunk = SDL_mixer.Mix_LoadMUS(path);

            }
            else if (path.EndsWith(".wav"))
            {
                chunk = SDL_mixer.Mix_LoadWAV(path);

            }

            sounds.Add(name, chunk);
        }


        public void PlaySound(string name)
        {
            SDL_mixer.Mix_PlayChannel(availableChannels[0], sounds[name], 0);
            availableChannels.RemoveAt(0);
            
        }


        // Function intended for playing soundtracks in games, not suitable for soudnd effects.
        public void PlayMusic(string name, int loops)
        {
            SDL_mixer.Mix_PlayMusic(sounds[name], loops);
            SDL_mixer.Mix_VolumeMusic(64);
            spatialMusic = false;
        }

        public void PlayMusic(string name, int loops, GameObject soundSource, GameObject soundTarget)
        {
            SDL_mixer.Mix_PlayMusic(sounds[name], loops);
            SDL_mixer.Mix_VolumeMusic((int)Math.Round(CalculateVolume(soundSource, soundTarget), MidpointRounding.AwayFromZero));
            spatialMusic = true;
            spatialMusicSource = soundSource;
            spatialMusicTarget = soundTarget;
        }

        public void PlaySound(string name, int loopCount)
        {
            SDL_mixer.Mix_PlayChannel(availableChannels[0], sounds[name], loopCount);
            availableChannels.RemoveAt(0);
            SDL_mixer.Mix_ChannelFinished((x => availableChannels.Add(x)));
        }


        //Overloaded function to allow you to play sound at a specific location for spatial sound effects.
        public void PlaySound(string name, GameObject soundSource, GameObject player)
        {

            List<SpatialSoundInstance> temp = new List<SpatialSoundInstance>();
            foreach (SpatialSoundInstance s in spatialSoundInstances)
            {
                if (!availableChannels.Contains(s.channel))
                {
                    temp.Add(s);
                }
            }

            foreach(SpatialSoundInstance s in temp)
            {
                spatialSoundInstances.Remove(s);
                SDL_mixer.Mix_Volume(s.channel, defaultVolume);
            }

            spatialSoundInstances.Add(new SpatialSoundInstance(availableChannels[0], soundSource, player));

            double vol = CalculateVolume(soundSource, player);



            SDL_mixer.Mix_PlayChannel(availableChannels[0], sounds[name], 0);
            availableChannels.RemoveAt(0);

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


                double newVolume = CalculateVolume(s.soundSource, s.soundTarget);

                SDL_mixer.Mix_Volume(s.channel, (int)Math.Round(defaultVolume / newVolume, MidpointRounding.AwayFromZero));
                
            }

            if (spatialMusic)
            {
                int newVol = (int)(defaultVolume / CalculateVolume(spatialMusicSource, spatialMusicTarget));

                SDL_mixer.Mix_VolumeMusic(newVol);

            }
        }


        private double CalculateVolume(GameObject a, GameObject b)
        {
            double Ypart = (a.Transform2D.Y + (a.Transform2D.Ht/2)) - (b.Transform2D.Y + b.Transform2D.Ht/2);
            double Xpart = a.Transform2D.X + a.Transform2D.Wid/2 - (b.Transform2D.X + b.Transform2D.Wid / 2);

            double distance = Math.Sqrt(Math.Pow(Ypart, 2) + Math.Pow(Xpart, 2)) + 0.1;

            return distance / 100;

        }

        public void SetDefaultVolume(int vol)
        {
            defaultVolume = vol;
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


