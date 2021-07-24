using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gamePaused = false;
    private bool gameWon = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelText;
    private int level;
    public GameObject PausePanel;
    public GameObject ReplayPanel;
    public GameObject LevelCompletedPanel;
    public float timer;
    public static bool pauseGame = false;
    public static bool levelCompleted = false;
    public Button pauseButton;
    public Animator circleAnimator;
    private MusicManager musicManager;
    public static bool isSoundsOn = true;
   
    // Start is called before the first frame update
    void Awake()
    {
        try
        {
            musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        }
        catch
        {

        }
        Time.timeScale = 1;
        ShowLevel();
        pauseGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        if (timer > 0&&!pauseGame)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.RoundToInt(timer).ToString();
        }

            if (timer <= 0)
        {
            ShowPanel(LevelCompletedPanel);
            levelCompleted = true;
            UnlockNextLevel();

        }
    }

    private void UnlockNextLevel()
    {
        if (PlayerPrefs.GetInt(LevelManager.levelReachedKey) <level+1) {
            PlayerPrefs.SetInt(LevelManager.levelReachedKey, level + 1);
        }
    }

    private void ShowPanel(GameObject panelName)
    {
        pauseGame = true;
        panelName.SetActive(true);
    }
    private void ShowLevel()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = level.ToString();
    }
    public void PauseButton()
    {
        if (pauseGame == false)
        {
            
            ShowPanel(PausePanel);
        }
        else
        {
            PausePanel.SetActive(false);
            pauseGame = false;
        }
        
    }

    public void LoseLevel()
    {
        
        ShowPanel(ReplayPanel);
        pauseButton.interactable = false;
    }
    public void ReplayLevel()
    {
        pauseGame = false;
        SceneManager.LoadScene(level);
        
    }
    public void Continue()
    {
        HidePanel(PausePanel);
    }
    public void HidePanel(GameObject panelName)
    {
        pauseGame = false;
        panelName.SetActive(false);
    }
    
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void NextLevel()
    {
        circleAnimator.SetTrigger("Grow");
       // SceneManager.LoadScene(level + 1);
       
    }
    public void SwitchMusic()
    {
        musicManager.SwitchMute();
    }
    public void SwitchSounds()
    {
        isSoundsOn = !isSoundsOn;
    }
    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

}
