using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Button restartButton;
    public Button quitButton;

    public bool isGameStarted = false;

    void Start()
    {
        if (restartButton != null && startButton != null && quitButton != null)
        {
            restartButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }

    public void ShowRestartButton()
    {
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
