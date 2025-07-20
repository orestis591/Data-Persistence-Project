using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // �� ������������� TMP_InputField

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;

    // �������� ��� �� On Click() ��� �������� Start
    public void OnStartButton()
    {
        // 1) ������� / logging
        Debug.Log($"[StartMenu] OnStartButton(), nameInput.text = '{nameInput.text}'");

        if (string.IsNullOrWhiteSpace(nameInput.text))
        {
            Debug.LogWarning("[StartMenu] No name entered � aborting start.");
            return;
        }

        // 2) ���������� ��� �������� ���� GameManager
        GameManager.Instance.SetPlayerName(nameInput.text);

        // 3) ������� �� ����� "Main"
        SceneManager.LoadScene("Main");
    }
    public void OnQuitButton()
    {
#if UNITY_EDITOR
        // if we�re in the Editor, stop Play mode
        EditorApplication.ExitPlaymode();
#else
        // if we�re in a built app, quit the player
        Application.Quit();
#endif
    }
}
