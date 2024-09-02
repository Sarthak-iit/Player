namespace MediaPlayerSystem;


public abstract class PlayerState
{

    protected MediaPlayer mediaPlayer;

    protected double time;

    public MediaPlayer MediaPlayer
    { get; set; }

    public double Time => time;
    public abstract void Play();
    public abstract void Pause();
    public abstract void Stop();
}

