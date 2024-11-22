using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol fare tuþu
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                HandleMouseClick(hit.collider.gameObject);
            }
        }
    }

    private void HandleMouseClick(GameObject clickedObject)
    {
        if (clickedObject.CompareTag("Frog"))
        {
            clickedObject.GetComponent<Frog>().InteractWithFrog();
        }
        else if (clickedObject.CompareTag("Berry"))
        {
            clickedObject.GetComponent<Berry>().CollectBerry();
        }
    }

}
