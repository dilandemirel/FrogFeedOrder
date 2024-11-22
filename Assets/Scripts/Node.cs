using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Transform cellContainer;
    private Stack<Cell> cellStack = new Stack<Cell>();

    private void Awake()
    {
        if (cellContainer == null)
        {
            cellContainer = transform.Find("cellContainer");

            if (cellContainer == null)
            {
                Debug.LogError("CellContainer bulunamadý.");
            }
        }
    }

  
    public void AddCell(Cell cell)
    {  
        cell.transform.SetParent(cellContainer);

        cellStack.Push(cell);
        UpdateActiveCell();
    }

    public Cell GetActiveCell()
    {
        return cellStack.Count > 0 ? cellStack.Peek() : null;
    }

    private void UpdateActiveCell()
    {
        foreach (var cell in cellStack)
        {
            cell.gameObject.SetActive(false);
        }

        if (cellStack.Count > 0)
        {
            cellStack.Peek().gameObject.SetActive(true);
        }
    }

    public void RemoveTopCell()
    {
        if (cellStack.Count > 0)
        {
            var removedCell = cellStack.Pop();
            Destroy(removedCell.gameObject);
            UpdateActiveCell();
        }
    }
}
