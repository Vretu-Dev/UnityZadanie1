using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    Camera mainCamera;

    private static GameEnding instance;
    private float elapsedTime = 0f;
    


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }
    public static void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void GameOver(string reason)
    {
        if (instance != null && instance.gameOverPanel != null)
        {
            instance.gameOverPanel.SetActive(true);
            instance.mainCamera.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Transform winTransform = instance.gameOverPanel.transform.Find("Win");
            Transform loseTransform = instance.gameOverPanel.transform.Find("Lose");
            GameObject crosshair = GameObject.Find("Crosshair");

            crosshair.SetActive(false);

            if (reason == "Win")
            {
                loseTransform.gameObject.SetActive(false);

                Transform timerTransform = instance.gameOverPanel.transform.Find("Timer");
                if (timerTransform != null)
                {
                    TextMeshProUGUI timerText = timerTransform.GetComponent<TextMeshProUGUI>();
                    if (timerText != null)
                    {
                        timerText.text = "Twój czas: " + FormatTime(instance.elapsedTime);
                    }
                }
            }  
            else
            {
                winTransform.gameObject.SetActive(false);
            }
        }
    }
    private static string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100f) % 100f);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
