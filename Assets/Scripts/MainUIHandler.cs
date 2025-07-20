using UnityEngine;
using UnityEngine.UI;   // ή TMPro αν χρησιμοποιείς TextMeshProUGUI


public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;    // Legacy UI Text
    // [SerializeField] private TextMeshProUGUI bestScoreText; // ή TMP

    void Start()
    {
        // Πάρε το όνομα που κράτησε ο GameManager
        string playerName = GameManager.Instance.PlayerName;
        int highScore = GameManager.Instance.GetHighScore();

        bestScoreText.text = $"Best Score: {highScore}   Name: {playerName}";
    }
}
