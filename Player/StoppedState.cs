/******************************************************************************
 * Filename    = StoppedState.cs
 *
 * Author      = Sarthak
 *
 * Project     = MediaPlayer
 *
 * Description = Represents the stopped state of the media player, preventing any
 *               playback actions until resumed.
 *****************************************************************************/

using System;

namespace MediaPlayerSystem
{

    /// <summary>
    /// Represents the stopped state of the media player.
    /// In this state, the media is stopped, and the user can either start playing or remain stopped.
    /// </summary>
    public class StoppedState : PlayerState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoppedState"/> class.
        /// </summary>
        /// <param name="mediaPlayer">The media player context that is transitioning to the stopped state.</param>
        public StoppedState(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
            time = 0; // Reset time to 0
        }

        /// <summary>
        /// Handles the Pause action when the media player is in the stopped state.
        /// Since the media is already stopped, pausing is not possible.
        /// </summary>
        public override void Pause()
        {
            Console.WriteLine("Stopped Player can't be paused");
        }

        /// <summary>
        /// Handles the Play action when the media player is in the stopped state.
        /// Transitions the media player to the playing state.
        /// </summary>
        public override void Play()
        {
            mediaPlayer.State = new PlayingState(mediaPlayer);
        }

        /// <summary>
        /// Handles the Stop action when the media player is in the stopped state.
        /// Since the media is already stopped, this method simply informs the user.
        /// </summary>
        public override void Stop()
        {
            Console.WriteLine("Already Stopped");
        }
    }
}