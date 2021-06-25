using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{

       public delegate void TapAction(Touch touch);
    public static event TapAction onTap;

    public Vector2 movement;
    public float tapMaxMovement = 50.0f;
   public bool tapGesture=false;

    private void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase==TouchPhase.Began)
            {
                movement = Vector2.zero;
                Debug.Log("BEGAN");
            }
            else if(touch.phase==TouchPhase.Moved || touch.phase==TouchPhase.Stationary)
            {
                movement = movement + touch.deltaPosition;
                if(movement.magnitude>tapMaxMovement)
                {
                    tapGesture = true;
                    Debug.Log("MOVED");
                }

                
            }
            else
            {
                if(!tapGesture)
                {
                    if(onTap!=null)
                    {
                        onTap(touch);
                    }
                    tapGesture = false;
                }
            }
        }
    }




}
