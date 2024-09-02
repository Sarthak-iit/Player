using System;

namespace MediaPlayerSystem
{
    /// <summary>
    /// Represents the paused state of the media player.
    /// In this state, the media is paused, and the user can either resume playing or stop the media.
    /// </summary>
    public class PausedState : PlayerState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PausedState"/> class by copying the state from another <see cref="PlayerState"/> instance.
        /// </summary>
        /// <param name="playerState">The state to copy, typically the previous state of the media player.</param>
        public PausedState(PlayerState playerState) :
            this(playerState.MediaPlayer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PausedState"/> class.
        /// </summary>
        /// <param name="mediaPlayer">The media player context that is transitioning to the paused state.</param>
        public PausedState(MediaPlayer mediaPlayer)
        {
            // Set the media player context and retrieve the current time from the previous state.
            MediaPlayer = mediaPlayer;
            time = mediaPlayer.State.Time;
        }

        /// <summary>
        /// Handles the Pause action when the media player is in the paused state.
        /// Since the media is already paused, this method simply informs the user.
        /// </summary>
        public override void Pause()
        {
            Console.WriteLine("Already Paused");
        }

        /// <summary>
        /// Handles the Play action when the media player is in the paused state.
        /// Transitions the media player to the playing state.
        /// </summary>
        public override void Play()
        {
            MediaPlayer.State = new PlayingState(this);
        }

        /// <summary>
        /// Handles the Stop action when the media player is in the paused state.
        /// Transitions the media player to the stopped state.
        /// </summary>
        public override void Stop()
        {
            MediaPlayer.State = new StoppedState(this);
        }
    }
}