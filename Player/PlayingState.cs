/******************************************************************************
 * Filename    = PlayingState.cs
 *
 * Author      = Sarthak Garg
 *
 * Project     = MediaPlayer
 *
 * Description = Represents the playing state of the media player, allowing the user
 *               to pause or stop playback.
 *****************************************************************************/

using System;

namespace MediaPlayerSystem
{
    /// <summary>
    /// Represents the playing state of the media player.
    /// In this state, the media is actively playing, and the user can pause or stop the media.
    /// </summary>
    public class PlayingState : PlayerState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayingState"/> class.
        /// </summary>
        /// <param name="mediaPlayer">The media player context that is transitioning to the playing state.</param>
        public PlayingState(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
            time = mediaPlayer.State.Time + 1;
        }

        /// <summary>
        /// Handles the Pause action when the media player is in the playing state.
        /// Transitions the media player to the paused state.
        /// </summary>
        public override void Pause()
        {
            mediaPlayer.State = new PausedState(mediaPlayer);
        }

        /// <summary>
        /// Handles the Play action when the media player is in the playing state.
        /// This method increments the current playback time.
        /// </summary>
        public override void Play()
        {
            time += 1; // Increment time
        }

        /// <summary>
        /// Handles the Stop action when the media player is in the playing state.
        /// Transitions the media player to the stopped state.
        /// </summary>
        public override void Stop()
        {
            mediaPlayer.State = new StoppedState(mediaPlayer);
        }
    }
}