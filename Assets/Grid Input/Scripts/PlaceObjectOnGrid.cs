using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    [SerializeField] private Transform gridCellPrefab;
    [SerializeField] private int height, width;

    void Start()
    {
        GenerateGrid();
    }
    private void GenerateGrid()
    {
        var _name = 0;
        float startX = -(width - 1) / 2f;  // Calculate the starting X position
        float startY = -(height - 1) / 2f; // Calculate the starting Y position
    
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldPosition = new Vector3(startX + x, 0, startY + y);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.transform.parent = gameObject.transform;
                obj.name = "Cell " + _name;
                _name++;
            }
        }
        gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

}