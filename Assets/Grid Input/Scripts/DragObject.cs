using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool isDragging = false;
    private Transform _toDrag;
    private float _distance;
    private Vector3 _offset;

    private Vector3 NewGridPosition;
    private Vector3 oldGridPosition;

    // Update is called once per frame
    void Update()
    {
        Vector3 v3;
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit? hit = CastRay();
            if (hit.HasValue && hit.Value.collider.CompareTag("Draggable"))
            {
                _toDrag = hit.Value.transform;
                _distance = hit.Value.transform.position.z - Camera.main.transform.position.z;
                v3 = hit.Value.point;
                //_offset = _toDrag.position - v3; 
                isDragging = true;
            }
            
            oldGridPosition = transform.position; //current position of object
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance - 0.5f); // 0.5f so that after grabbing the object it comes up towards screen.
            v3 = Camera.main.ScreenToWorldPoint(v3);
            _toDrag.position = v3 + _offset;
            Ray objectRay = new Ray(transform.position, Vector3.forward);
            RaycastHit GridHit;
            if (Physics.Raycast(objectRay,out GridHit))
            {
                if (GridHit.collider.CompareTag("Grid"))
                {
                    NewGridPosition= GridHit.transform.position;
                }
            }
            else
            {
                NewGridPosition = oldGridPosition;  // if collider does not hit any grid then back to Old Grid
            }
            
            Debug.DrawRay(objectRay.origin,objectRay.direction* 10f,Color.yellow);
            
        }
        
        if (Input.GetMouseButton(0) == false && isDragging)
        {
            isDragging = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (oldGridPosition != NewGridPosition)
            {
                transform.position = NewGridPosition;
            }
            else
            {
                transform.position = oldGridPosition;
            }
        }
    }

    private RaycastHit? CastRay()
    {
        var mousPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousPos);
        RaycastHit hit;
        Debug.DrawRay(ray.origin,ray.direction*100f,Color.red);
        if (Physics.Raycast(ray,out hit))
        {
            return hit;
        }
        else
        {
            return null;
        } 
    }
}
