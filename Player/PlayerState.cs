namespace MediaPlayerSystem;


public abstract class PlayerState
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
    }
    public abstract void Play();
    public abstract void Pause();
    public abstract void Stop();
}

