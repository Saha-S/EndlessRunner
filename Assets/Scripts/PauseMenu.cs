using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameObject pauseMenu;
    public GameObject pauseButton; // Reference to the pause button to disable


    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Example of pause button input
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false); // Disable the pause button
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true); // Enable the pause button
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset(); // Implement your reset logic here
        isPaused = false;
        pauseButton.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuLevel);
    }
}
