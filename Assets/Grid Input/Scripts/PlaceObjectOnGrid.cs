using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    [SerializeField] private Transform _gridCellPrefab;
    [SerializeField] private int _height, _width;
    private Plane _plane;
    void Start()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        //_nodes = new Node[_width, _height];
        var name = 0;
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector3 worldPosition = new Vector3(x, 0, y);
                Transform obj = Instantiate(_gridCellPrefab, worldPosition, Quaternion.identity);
                obj.transform.parent = gameObject.transform;
                obj.name = "Cell " + name;
                name++;
            }
        }
        gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }
}