using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string PlayerName { get; private set; }
    private int highScore;
    private string highScorePlayer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScorePlayer = PlayerPrefs.GetString("HighScorePlayer", "Nobody");
        }
        else Destroy(gameObject);
    }
    
    public void SetPlayerName(string name) => PlayerName = name;

    public int GetHighScore() => highScore;
    public string GetHighScorePlayer() => highScorePlayer;

    public void TrySetNewHighScore(int score)
    {
        if (score <= highScore) return;
        highScore = score;
        highScorePlayer = PlayerName;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetString("HighScorePlayer", highScorePlayer);
        PlayerPrefs.Save();
        SaveHighScore();
    }
    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetString("HighScorePlayer", highScorePlayer);
        PlayerPrefs.Save();
    }
    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScorePlayer = PlayerPrefs.GetString("HighScorePlayer", "Nobody");
    }
}
