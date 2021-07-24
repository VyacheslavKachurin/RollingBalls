using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject tutorialCanvas;
    public Vector2 position1;
    public Vector2 position2;
    private int isFirstTime;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("isPlayingFirstTime");
        isFirstTime =PlayerPrefs.GetInt("isPlayingFirstTime", 1);
        if (isFirstTime == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.pauseGame = true;
            gameManager.enabled = false;
            
            Debug.Log("executed");
            
        }

    }

    // Update is called once per frame
 public void acceptButton()
    {
         PlayerPrefs.SetInt("isPlayingFirstTime", 0);
        tutorialCanvas.SetActive(false);
        gameManager.enabled = true;
        GameManager.pauseGame = false ;


    }

}
