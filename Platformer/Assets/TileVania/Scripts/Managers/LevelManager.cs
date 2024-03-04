using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public event Action OnNextLevelLoad;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerStats.ResetStats();
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        OnNextLevelLoad?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
