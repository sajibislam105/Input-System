using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private float _distance;
    private bool _dragging = false;
    private Vector3 _offset;
    private Transform _toDrag;
    

    private void Update()
    {
        Vector3 v3;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit?
            hit = CastRay(); // RayCasting from the CastRay function and returning as a RaycastHit data type with Nullable 
            if (hit.HasValue && hit.Value.collider.tag == "Dragable") //checking if its nullable or not 
            {
                _toDrag = hit.Value.transform;
                _distance = hit.Value.transform.position.z - Camera.main.transform.position.z; //Z is distance of camera to clicked object
                v3 = hit.Value.point;
                _offset = _toDrag.position - v3; //then the mouse is on the object 
                _dragging = true;
            }
        }
        
        if (Input.GetMouseButton(0) && _dragging)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            _toDrag.position = v3 + _offset;
        }
        
        if (Input.GetMouseButton(0) == false && _dragging)
        {
            _dragging = false;
        }
    }
    private RaycastHit? CastRay()
    {
        Vector3 touchPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit;
        }
        return null; //Ray Hit nothing
    }

}
