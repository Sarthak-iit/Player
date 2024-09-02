/******************************************************************************
 * Filename    = MediaPlayerTests.cs
 *
 * Author      = Sarthak Garg
 *
 * Project     = MediaPlayer
 *
 * Description = Contains unit tests for the MediaPlayer class to ensure proper 
 *               functionality of the state transitions and actions.
 *****************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaPlayerSystem;

namespace MediaPlayerTests
{
    [TestClass]
    public class MediaPlayerTests
    {
        private MediaPlayer _mediaPlayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaPlayer"/> class before each test.
        /// This method is called before each test method in the class.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mediaPlayer = new MediaPlayer();
        }

        /// <summary>
        /// Tests that the initial state of the media player is Stopped.
        /// </summary>
        [TestMethod]
        public void InitialState_ShouldBeStopped()
        {
            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState));
        }

        /// <summary>
        /// Tests the transition from Stopped to Playing when Play is called.
        /// </summary>
        [TestMethod]
        public void Play_WhenStopped_ShouldTransitionToPlaying()
        {
            // Act
            _mediaPlayer.Play();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PlayingState));
            Assert.AreEqual(1, _mediaPlayer.State.Time);
        }

        /// <summary>
        /// Tests the transition from Playing to Paused when Pause is called.
        /// </summary>
        [TestMethod]
        public void Pause_WhenPlaying_ShouldTransitionToPaused()
        {
            // Arrange
            _mediaPlayer.Play();

            // Act
            _mediaPlayer.Pause();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PausedState));
            Assert.AreEqual(1, _mediaPlayer.State.Time); // The time should remain the same as it was before pausing
        }

        /// <summary>
        /// Tests the transition from Playing to Stopped when Stop is called.
        /// </summary>
        [TestMethod]
        public void Stop_WhenPlaying_ShouldTransitionToStopped()
        {
            // Arrange
            _mediaPlayer.Play();

            // Act
            _mediaPlayer.Stop();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, _mediaPlayer.State.Time); // Time should reset to 0 when stopped
        }

        /// <summary>
        /// Tests the transition from Paused to Playing when Play is called.
        /// </summary>
        [TestMethod]
        public void Play_WhenPaused_ShouldTransitionToPlaying()
        {
            // Arrange
            _mediaPlayer.Play();
            _mediaPlayer.Pause();

            // Act
            _mediaPlayer.Play();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PlayingState));
            Assert.AreEqual(2, _mediaPlayer.State.Time); // Time should increment
        }

        /// <summary>
        /// Tests the transition from Paused to Stopped when Stop is called.
        /// </summary>
        [TestMethod]
        public void Stop_WhenPaused_ShouldTransitionToStopped()
        {
            // Arrange
            _mediaPlayer.Play();
            _mediaPlayer.Pause();

            // Act
            _mediaPlayer.Stop();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, _mediaPlayer.State.Time); // Time should reset to 0 when stopped
        }

        /// <summary>
        /// Tests that calling Pause when the player is already Stopped does not change the state.
        /// </summary>
        [TestMethod]
        public void Pause_WhenStopped_ShouldNotChangeState()
        {
            // Act
            _mediaPlayer.Pause();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState)); // State should remain stopped
            Assert.AreEqual(0, _mediaPlayer.State.Time); // Time should remain 0
        }

        /// <summary>
        /// Tests that calling Stop when the player is already Stopped does not change the state.
        /// </summary>
        [TestMethod]
        public void Stop_WhenAlreadyStopped_ShouldNotChangeState()
        {
            // Act
            _mediaPlayer.Stop();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState)); // State should remain stopped
            Assert.AreEqual(0, _mediaPlayer.State.Time); // Time should remain 0
        }

        /// <summary>
        /// Tests that calling Play when the player is already Playing does not change the state.
        /// </summary>
        [TestMethod]
        public void Play_WhenPlaying_ShouldNotChangeState()
        {
            // Arrange
            _mediaPlayer.Play();

            // Act
            _mediaPlayer.Play();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PlayingState)); // State should remain playing
            Assert.AreEqual(2, _mediaPlayer.State.Time); // Time should increment by 1
        }

        /// <summary>
        /// Tests that calling Pause when the player is already Paused does not change the state.
        /// </summary>
        [TestMethod]
        public void Pause_WhenPaused_ShouldNotChangeState()
        {
            // Arrange
            _mediaPlayer.Play();
            _mediaPlayer.Pause();

            // Act
            _mediaPlayer.Pause();

            // Assert
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PausedState)); // State should remain paused
            Assert.AreEqual(1, _mediaPlayer.State.Time); // Time should remain the same
        }
    }
}