using UnityEngine;
using UnityEngine.UI;   // � TMPro �� ������������� TextMeshProUGUI


public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;    // Legacy UI Text
    // [SerializeField] private TextMeshProUGUI bestScoreText; // � TMP

    void Start()
    {
        // ���� �� ����� ��� ������� � GameManager
        string playerName = GameManager.Instance.PlayerName;
        int highScore = GameManager.Instance.GetHighScore();

        bestScoreText.text = $"Best Score: {highScore}   Name: {playerName}";
    }
}
