using System;
using MediaPlayerSystem;

namespace MediaPlayerSystem
{
    public class PlayingState : IPlayerState
    {
        public PlayingState(IPlayerState playerState) :
            this(playerState.MediaPlayer)
        {
        }

        public PlayingState(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
            time = mediaPlayer.State.Time + 1;
        }

        public override void Pause()
        {
            mediaPlayer.State = new PausedState(this);
        }

        public override void Play()
        {
            this.time += 1;
        }

        public override void Stop()
        {
            mediaPlayer.State = new StoppedState(this);
        }
    }
}

