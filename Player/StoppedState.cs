using System;
using MediaPlayerSystem;

namespace MediaPlayerSystem
{
    public class StoppedState : IPlayerState


    {

        public StoppedState(IPlayerState playerState) :
            this(playerState.MediaPlayer)
        {
        }

        public StoppedState(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
            this.time = 0;
        }

        public override void Pause()
        {
            Console.WriteLine("Stopped Player can't be paused");
        }

        public override void Play()
        {
            mediaPlayer.State = new PlayingState(this);
        }

        public override void Stop()
        {
            Console.WriteLine("Already Stopped");
        }
    }
}

