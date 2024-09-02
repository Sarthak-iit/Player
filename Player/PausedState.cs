/******************************************************************************
 * Filename    = PausedState.cs
 *
 * Author      = Sarthak Garg
 *
 * Project     = MediaPlayer
 *
 * Description = Represents the paused state of the media player, allowing the user
 *               to resume or stop playback.
 *****************************************************************************/

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
        /// Initializes a new instance of the <see cref="PausedState"/> class.
        /// </summary>
        /// <param name="mediaPlayer">The media player context that is transitioning to the paused state.</param>
        public PausedState(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
            time = mediaPlayer.State.Time; // Keep the time from the previous state
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
            mediaPlayer.State = new PlayingState(mediaPlayer);
        }

        /// <summary>
        /// Handles the Stop action when the media player is in the paused state.
        /// Transitions the media player to the stopped state.
        /// </summary>
        public override void Stop()
        {
            mediaPlayer.State = new StoppedState(mediaPlayer);
        }
    }
}