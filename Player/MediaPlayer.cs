/******************************************************************************
 * Filename    = MediaPlayer.cs
 *
 * Author      = Sarthak Garg
 *
 * Project     = MediaPlayer
 *
 * Description = Defines the MediaPlayer context that manages the current state and
 *               interactions with the playback states.
 *****************************************************************************/

using System;

namespace MediaPlayerSystem
{
    /// <summary>
    /// Represents the media player, which can play, pause, and stop media.
    /// The media player operates in different states, which determine its behavior.
    /// </summary>
    public class MediaPlayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaPlayer"/> class.
        /// The media player starts in the stopped state.
        /// </summary>
        public MediaPlayer()
        {
            State = new StoppedState(this);
        }

        /// <summary>
        /// Gets or sets the current state of the media player.
        /// </summary>
        public PlayerState State { get; set;}

        /// <summary>
        /// Plays the media.
        /// Transitions the media player to the playing state if it is not already playing.
        /// </summary>
        public void Play()
        {
            State.Play();
            Console.WriteLine("Song Played");
            Console.WriteLine($"Current Time: {State.Time}");
        }

        /// <summary>
        /// Stops the media.
        /// Transitions the media player to the stopped state if it is not already stopped.
        /// </summary>
        public void Stop()
        {
            State.Stop();
            Console.WriteLine("Song Stopped");
            Console.WriteLine($"Current Time: {State.Time}");
        }

        /// <summary>
        /// Pauses the media.
        /// Transitions the media player to the paused state if it is not already paused.
        /// </summary>
        public void Pause()
        {
            State.Pause();
            Console.WriteLine("Song Paused");
            Console.WriteLine($"Current Time: {State.Time}");
        }
    }
}