using UnityEngine;

public enum CellType
{
    Frog,      
    Arrow,     
    Berry       
}

public class Cell : MonoBehaviour
{
    public CellType cellType;

    public Color cellColor;

    private bool isActive = true;

    public void Interact()
    {
        switch (cellType)
        {
            case CellType.Frog:
                HandleFrogInteraction();
                break;
            case CellType.Arrow:
                HandleArrowInteraction();
                break;
            case CellType.Berry:
                HandleBerryInteraction();
                break;
        }
    }

    private void HandleFrogInteraction()
    {
        Debug.Log("Kurba�ayla etkile�ime girdi!");
    }

    private void HandleArrowInteraction()
    {
        Debug.Log("Ok ile etkile�ime girdi!");
    }

    private void HandleBerryInteraction()
    {
        Debug.Log("Meyve etkile�ime girdi!");
    }

    public void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void SetColor(Color color)
    {
        cellColor = color;
        GetComponent<Renderer>().material.color = color;
    }
}
