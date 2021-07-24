using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;
    private int levelReached;
    public bool deleteData;
    public static string levelReachedKey = "levelReached";
    public Sprite padlock;
    // Start is called before the first frame update
    void Start()
    {
        

        levelReached = PlayerPrefs.GetInt(levelReachedKey, 1);
        for(int i = 0; i < buttons.Length; i++)
        {
            if (i+1 > levelReached)
            {
                
                    buttons[i].interactable = false;
                buttons[i].GetComponent<Image>().sprite = padlock;
                }
               
                
                
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        DeleteData();
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void DeleteData()
    {
        if (deleteData)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("data deleted");
        }
    }
}
