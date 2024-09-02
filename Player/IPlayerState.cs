namespace MediaPlayerSystem;


public abstract class IPlayerState
{

    protected MediaPlayer mediaPlayer;
    protected double time;

    public MediaPlayer MediaPlayer
    {
        get { return mediaPlayer; }
        set { mediaPlayer = value; }
    }

    public double Time
    {
        get { return time; }
        set { time = value; }
    }
    public abstract void Play();
    public abstract void Pause();
    public abstract void Stop();
}

