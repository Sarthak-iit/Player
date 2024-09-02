/******************************************************************************
 * Filename    = PlayerState.cs
 *
 * Author      = Sarthak Garg
 *
 * Project     = MediaPlayer
 *
 * Description = Represents the abstract base class for all states in the media player.
 *****************************************************************************/

namespace MediaPlayerSystem
{
    /// <summary>
    /// Represents an abstract base class for the different states of the media player.
    /// Each state (Playing, Paused, Stopped) will derive from this class.
    /// </summary>
    public abstract class PlayerState
    {
        /// <summary>
        /// The MediaPlayer instance associated with this state.
        /// Allows the state to interact with the MediaPlayer context.
        /// </summary>
        protected MediaPlayer mediaPlayer;

        /// <summary>
        /// The current position or time within the media.
        /// This represents the playback time and is typically measured in seconds.
        /// </summary>
        protected double time;

        /// <summary>
        /// Gets or sets the MediaPlayer instance associated with this state.
        /// </summary>
        public MediaPlayer MediaPlayer
        {
            get => mediaPlayer;
            set => mediaPlayer = value;
        }

        /// <summary>
        /// Gets the current playback time or position within the media.
        /// This is a read-only property.
        /// </summary>
        public double Time => time;

        /// <summary>
        /// Abstract method to handle the Play action.
        /// Each concrete state must implement its own behavior when the Play command is issued.
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// Abstract method to handle the Pause action.
        /// Each concrete state must implement its own behavior when the Pause command is issued.
        /// </summary>
        public abstract void Pause();

        /// <summary>
        /// Abstract method to handle the Stop action.
        /// Each concrete state must implement its own behavior when the Stop command is issued.
        /// </summary>
        public abstract void Stop();
    }
}