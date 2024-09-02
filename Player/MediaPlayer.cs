using System;
using MediaPlayerSystem;

namespace MediaPlayerSystem
{
    public class MediaPlayer
    {

        private IPlayerState playerState;
        public MediaPlayer()
        {
            this.State = new StoppedState(this);
        }

        public IPlayerState State { get; set; }

        public void Play()
        {
            State.Play();
            Console.WriteLine("Song Played");
            Console.WriteLine($"Current Time: {this.State.Time}");
        }

        public void Stop()
        {
            State.Stop();
            Console.WriteLine("Song Stopped");
            Console.WriteLine($"Current Time: {this.State.Time}");
        }

        public void Pause()
        {
            State.Pause();
            Console.WriteLine("Song Paused");
            Console.WriteLine($"Current Time: {this.State.Time}");
        }
    }
}

