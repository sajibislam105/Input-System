using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float lastFingerPositionX;
    private float moveFactorX;
    public float MoveFactorX => moveFactorX; 
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFingerPositionX;
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}