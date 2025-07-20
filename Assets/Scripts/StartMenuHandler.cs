using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // αν χρησιμοποιείς TMP_InputField

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;

    // Καλείται από το On Click() του κουμπιού Start
    public void OnStartButton()
    {
        // 1) Έλεγχος / logging
        Debug.Log($"[StartMenu] OnStartButton(), nameInput.text = '{nameInput.text}'");

        if (string.IsNullOrWhiteSpace(nameInput.text))
        {
            Debug.LogWarning("[StartMenu] No name entered – aborting start.");
            return;
        }

        // 2) Αποθήκευση του ονόματος στον GameManager
        GameManager.Instance.SetPlayerName(nameInput.text);

        // 3) Φόρτωσε τη σκηνή "Main"
        SceneManager.LoadScene("Main");
    }
    public void OnQuitButton()
    {
#if UNITY_EDITOR
        // if we’re in the Editor, stop Play mode
        EditorApplication.ExitPlaymode();
#else
        // if we’re in a built app, quit the player
        Application.Quit();
#endif
    }
}
