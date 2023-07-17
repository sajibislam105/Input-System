using System;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;

    private void Update()
    {
        Vector3 v3;
        Vector3 pos = Input.mousePosition;
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider.tag == "Dragable")
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    dragging = true;
                }
            }
        }
        
        if (Input.GetMouseButton(0) && dragging)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }

        if (Input.GetMouseButton(0) == false && dragging)
        {
            dragging = false;
        }
        
        
        
        

    }
}
