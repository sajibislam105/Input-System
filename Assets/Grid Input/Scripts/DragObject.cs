using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera _camera; 
    
    private bool _isDragging;
    private Transform _toDrag;
    private float _distance;
    private Vector3 _offset;

    private Vector3 _newGridPosition;
    private Vector3 _oldGridPosition;

    private void Awake()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    {
        Vector3 v3;
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit? hit = CastRay();
            if (hit.HasValue && hit.Value.collider.CompareTag("Draggable"))
            {
                _toDrag = hit.Value.transform;
                _distance = hit.Value.transform.position.z - _camera.transform.position.z;
                //v3 = hit.Value.point;
                //_offset = _toDrag.position - v3;
                _isDragging = true;
            }
            _oldGridPosition = transform.position; //current position of object
        }
        
        if (Input.GetMouseButton(0) && _isDragging)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance - 0.5f); // 0.5f so that after grabbing the object it comes up towards screen.
            v3 = _camera.ScreenToWorldPoint(v3);
            _toDrag.position = v3 + _offset;

            Ray objectRay = new Ray(transform.position, Vector3.forward);
            RaycastHit GridHit;
            if (Physics.Raycast(objectRay,out GridHit))
            {
                if(GridHit.collider.CompareTag("Grid"))
                {
                    _newGridPosition= GridHit.transform.position;
                }
            }
            else
            {
                _newGridPosition = _oldGridPosition;  // if collider does not hit any grid then back to Old Grid                    
            }
        }
        
        if (Input.GetMouseButton(0) == false && _isDragging)
        {
            _isDragging = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.position = _oldGridPosition != _newGridPosition ? _newGridPosition : _oldGridPosition;
            /*
            if (_oldGridPosition != _newGridPosition)
            {
                transform.position = _newGridPosition;
            }
            else
            {
                transform.position = _oldGridPosition;
            }
            */
        }
    }

    private RaycastHit? CastRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin,ray.direction*100f,Color.red);
        if (Physics.Raycast(ray,out hit))
        {
            return hit;
        }
        return null;
    }
}
