using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SwipeInputSystem : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 touchPos;
    private float deltaX, deltaZ;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
           Touch touch = Input.GetTouch(0);
           Ray ray = Camera.main.ScreenPointToRay(touch.position);
           RaycastHit hit;
           if (Physics.Raycast(ray,out hit))
           {
               touchPos = hit.point;
           }
           switch (touch.phase)
           {
               case TouchPhase.Began:
                   deltaX = touchPos.x - transform.position.x;
                   //deltaZ = touchPos.y - transform.position.y;
                   deltaZ = touchPos.z - transform.position.z;
                   break;
               case TouchPhase.Moved:
                   _rigidbody.MovePosition(new Vector3(touchPos.x-deltaX,1.1f,touchPos.z - deltaZ));
                   _rigidbody.rotation = Quaternion.Euler(Vector3.zero);
                   break;
               case TouchPhase.Ended:
                   _rigidbody.velocity = Vector3.zero;
                   break;
           }
        }
    }
}
