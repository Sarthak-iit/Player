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
            // Assert that the initial state is Stopped
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

            // Assert that the state is now Playing and time is incremented
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

            // Assert that the state is now Paused and time remains the same
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PausedState));
            Assert.AreEqual(1, _mediaPlayer.State.Time);
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

            // Assert that the state is now Stopped and time is reset to 0
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, _mediaPlayer.State.Time);
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

            // Assert that the state is now Playing and time is incremented
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PlayingState));
            Assert.AreEqual(2, _mediaPlayer.State.Time);
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

            // Assert that the state is now Stopped and time is reset to 0
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, _mediaPlayer.State.Time);
        }

        /// <summary>
        /// Tests that calling Pause when the player is already Stopped does not change the state.
        /// </summary>
        [TestMethod]
        public void Pause_WhenStopped_ShouldNotChangeState()
        {
            // Act
            _mediaPlayer.Pause();

            // Assert that the state remains Stopped and time is still 0
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, _mediaPlayer.State.Time);
        }

        /// <summary>
        /// Tests that calling Stop when the player is already Stopped does not change the state.
        /// </summary>
        [TestMethod]
        public void Stop_WhenAlreadyStopped_ShouldNotChangeState()
        {
            // Act
            _mediaPlayer.Stop();

            // Assert that the state remains Stopped and time is still 0
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, _mediaPlayer.State.Time);
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

            // Assert that the state remains Playing and time is incremented
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PlayingState));
            Assert.AreEqual(2, _mediaPlayer.State.Time);
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

            // Assert that the state remains Paused and time is still the same
            Assert.IsInstanceOfType(_mediaPlayer.State, typeof(PausedState));
            Assert.AreEqual(1, _mediaPlayer.State.Time);
        }
    }
}