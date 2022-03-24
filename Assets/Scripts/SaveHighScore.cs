[System.Serializable]
public class SaveHighScore
{
    public int highScore;
    public bool music;

    public SaveHighScore(Spawner sp)
    {
        highScore = sp.highScore;
        music = sp.music;
    }
}
