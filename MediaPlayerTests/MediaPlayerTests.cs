using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaPlayerSystem;

namespace MediaPlayerTests
{
    [TestClass]
    public class MediaPlayerTests
    {
        private MediaPlayer mediaPlayer;

        [TestInitialize]
        public void Setup()
        {
            mediaPlayer = new MediaPlayer();
        }

        [TestMethod]
        public void InitialState_ShouldBeStopped()
        {
            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(StoppedState));
        }

        [TestMethod]
        public void Play_WhenStopped_ShouldTransitionToPlaying()
        {
            // Act
            mediaPlayer.Play();

            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(PlayingState));
            Assert.AreEqual(1, mediaPlayer.State.Time);
        }

        [TestMethod]
        public void Pause_WhenPlaying_ShouldTransitionToPaused()
        {
            // Arrange
            mediaPlayer.Play();

            // Act
            mediaPlayer.Pause();

            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(PausedState));
            Assert.AreEqual(1, mediaPlayer.State.Time); // The time should remain the same as it was before pausing
        }

        [TestMethod]
        public void Stop_WhenPlaying_ShouldTransitionToStopped()
        {
            // Arrange
            mediaPlayer.Play();

            // Act
            mediaPlayer.Stop();

            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, mediaPlayer.State.Time); // Time should reset to 0 when stopped
        }

        [TestMethod]
        public void Play_WhenPaused_ShouldTransitionToPlaying()
        {
            // Arrange
            mediaPlayer.Play();
            mediaPlayer.Pause();

            // Act
            mediaPlayer.Play();

            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(PlayingState));
            Assert.AreEqual(2, mediaPlayer.State.Time); // Time should increment
        }

        [TestMethod]
        public void Stop_WhenPaused_ShouldTransitionToStopped()
        {
            // Arrange
            mediaPlayer.Play();
            mediaPlayer.Pause();

            // Act
            mediaPlayer.Stop();

            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(StoppedState));
            Assert.AreEqual(0, mediaPlayer.State.Time); // Time should reset to 0 when stopped
        }

        [TestMethod]
        public void Pause_WhenStopped_ShouldNotChangeState()
        {
            // Act
            mediaPlayer.Pause();

            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(StoppedState)); // State should remain stopped
            Assert.AreEqual(0, mediaPlayer.State.Time); // Time should remain 0
        }

        [TestMethod]
        public void Stop_WhenAlreadyStopped_ShouldNotChangeState()
        {
            // Act
            mediaPlayer.Stop();

            // Assert
            Assert.IsInstanceOfType(mediaPlayer.State, typeof(StoppedState)); // State should remain stopped
            Assert.AreEqual(0, mediaPlayer.State.Time); // Time should remain 0
        }
    }
}
