using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
    public int rows; 
    public int columns; 
    public float cellSize = 1f;

    [Header("Prefabs")]
    public GameObject nodePrefab;
    public GameObject frogPrefab;
    public GameObject berryPrefab;

    private Node[,] grid;

    private void Start()
    {
        
        CreateGrid();

        // Test
        if (grid != null)
        {
            AddFrogToNode(grid[0, 0], Color.green, Direction.Right);
            AddBerryToNode(grid[0, 1], Color.red);
        }
        else
        {
            Debug.LogError("Grid olu�turulamad�. L�tfen kontrol edin.");
        }
    }

    private void CreateGrid()
    {
        if (nodePrefab == null)
        {
            Debug.LogError("Node prefab'i atanmad�! Grid olu�turulamad�.");
            return;
        }

        grid = new Node[rows, columns];

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                // Grid konumunu hesapla
                Vector3 position = new Vector3(x * cellSize, 0, y * cellSize);

                // Node prefab'ini instantiate et
                GameObject nodeObj = Instantiate(nodePrefab, position, Quaternion.identity, transform);
                nodeObj.name = $"Node ({x},{y})";

                // Node script'ini al
                Node node = nodeObj.GetComponent<Node>();
                if (node == null)
                {
                    Debug.LogError($"Node prefab'in �zerinde Node script'i eksik: {nodeObj.name}");
                    Destroy(nodeObj); // Yanlis bir prefab olusturulduysa yok et
                    continue;
                }

                // Grid'e ekle
                grid[x, y] = node;
            }
        }

        Debug.Log($"Grid ba�ar�yla olu�turuldu: {rows}x{columns}");
    }

    private void AddFrogToNode(Node node, Color color, Direction direction)
    {
        if (node == null)
        {
            Debug.LogError("Kurba�a eklenmek istenen Node bulunamad�.");
            return;
        }

        if (frogPrefab == null)
        {
            Debug.LogError("Kurba�a prefab'i atanmad�.");
            return;
        }

        
        GameObject frogObj = Instantiate(frogPrefab, node.transform);
        frogObj.transform.localPosition = Vector3.zero;

        
        Frog frog = frogObj.GetComponent<Frog>();
        if (frog == null)
        {
            Debug.LogError($"Kurba�a prefab'inde Frog script'i bulunamad�: {frogObj.name}");
            Destroy(frogObj);
            return;
        }

        
        frog.frogColor = color;
        frog.facingDirection = direction;

        
        Cell cell = frogObj.GetComponent<Cell>();
        if (cell != null)
        {
            node.AddCell(cell);
            Debug.Log($"Kurba�a {node.name} d���m�ne eklendi.");
        }
        else
        {
            Debug.LogError("Kurba�a prefab'i �zerinde Cell script'i bulunamad�.");
            Destroy(frogObj);
        }
    }

    private void AddBerryToNode(Node node, Color color)
    {
        if (node == null)
        {
            Debug.LogError("Berry eklenmek istenen Node bulunamad�.");
            return;
        }

        if (berryPrefab == null)
        {
            Debug.LogError("Berry prefab'i atanmad�.");
            return;
        }

        // Berry prefab'ini instantiate et
        GameObject berryObj = Instantiate(berryPrefab, node.transform);
        berryObj.transform.localPosition = Vector3.zero;

        
        Berry berry = berryObj.GetComponent<Berry>();
        if (berry == null)
        {
            Debug.LogError($"Berry prefab'inde Berry script'i bulunamad�: {berryObj.name}");
            Destroy(berryObj);
            return;
        }

        
        berry.berryColor = color;

        
        Cell cell = berryObj.GetComponent<Cell>();
        if (cell != null)
        {
            node.AddCell(cell);
            Debug.Log($"Berry {node.name} d���m�ne eklendi.");
        }
        else
        {
            Debug.LogError("Berry prefab'i �zerinde Cell script'i bulunamad�.");
            Destroy(berryObj);
        }
    }
}
