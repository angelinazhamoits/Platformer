using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class Menu : MonoBehaviour
{ 
    public static Menu Z;
  [SerializeField]  private GameObject _pauseGameMenu;
  [SerializeField] private GameObject _gameOverMenu;

  private void Awake() => Z = this;
    void Update()

    {
     
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseGameMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
    }

    public void Resume()
    {
        _pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        _pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Retry ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ToMenu()
    {
     Time.timeScale = 1f;
     SceneManager.LoadScene(0);
    }

    internal void GameOver()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
} 
