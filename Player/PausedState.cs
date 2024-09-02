using System;
using MediaPlayerSystem;

namespace MediaPlayerSystem
{
    public class PausedState : IPlayerState
    {
        public PausedState(IPlayerState playerState) :
            this(playerState.MediaPlayer)
        {
        }

        public PausedState(MediaPlayer mediaPlayer)
        {
            MediaPlayer = mediaPlayer;
            time = mediaPlayer.State.Time;
        }
        public override void Pause()
        {
            Console.WriteLine("Already Paused");
        }

        public override void Play()
        {
            mediaPlayer.State = new PlayingState(this);
        }

        public override void Stop()
        {
            mediaPlayer.State = new StoppedState(this);
        }
    }
}

