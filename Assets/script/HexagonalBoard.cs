using UnityEngine;

public class HexagonalBoard : MonoBehaviour
{
    public int rows = 5; // Number of rows in the board
    public int columns = 5; // Number of columns in the board
    public GameObject hexCellPrefab; // Prefab for the hexagonal cell
    public float cellSize = 1f; // Size of each cell
    public float spacingPercentage = 0.1f; // Adjust the spacing around each cell

    private void Start()
    {
        GenerateHexagonalGrid();
    }

    private void GenerateHexagonalGrid()
    {

        // Ensure odd number of rows and columns
        rows = Mathf.Max(1, rows);
        if (rows % 2 == 0)
        {
            rows++;
        }

        columns = Mathf.Max(1, columns);
        if (columns % 2 == 0)
        {
            columns++;
        }

        float xOffset = cellSize * Mathf.Sqrt(3f) * 0.75f;
        float zOffset = cellSize * 1.5f;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate the position of the hexagonal cell based on its row and column
                float xPos = col * xOffset;
                float zPos = row * zOffset;
                if (col % 2 != 0)
                {
                    zPos += zOffset * 0.5f;
                }

                // Instantiate the hexagonal cell prefab
                GameObject hexCell = Instantiate(hexCellPrefab, transform);
                hexCell.transform.localPosition = new Vector3(xPos, 0f, zPos);
                hexCell.transform.rotation = Quaternion.Euler(-90f, 0f, 90f); // Set the rotation

                // Adjust the scale of the hexagonal cell to add spacing
                Vector3 cellScale = hexCell.transform.localScale;
                cellScale *= (1f - spacingPercentage);
                hexCell.transform.localScale = cellScale;
            }
        }
    }
}
