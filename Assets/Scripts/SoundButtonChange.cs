using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonChange : MonoBehaviour
{
    public Sprite turnedOn;
    public Sprite turnedOff;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        SwitchSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchSprite()
    {
        if (!GameManager.isSoundsOn)
        {

            image.sprite = turnedOff;
        }
        else
        {

            image.sprite = turnedOn;
        }

    }
}
