using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouch : MonoBehaviour
{
    // Start is called before the first frame update

    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch[] touches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (i <= 1)
                {
                    Touch touch = Input.GetTouch(i);
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touch.phase == TouchPhase.Began)
                    {
                        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                        if (touchedCollider != null)
                        {
                            try
                            {
                                BallDragging ballScript = touchedCollider.GetComponent<BallDragging>();
                                ballScript.TurnDraggingOn(i);
                            }
                            catch
                            {

                            }
                        }
                    }

                }
            }
        }
    }
   
   
}
