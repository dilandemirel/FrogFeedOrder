using UnityEngine;

public class Berry : MonoBehaviour
{
    public Color berryColor;

    public void CollectBerry()
    {
        Debug.Log("Berry topland�!");

        GameManager.Instance.OnFrogTriggered();

        Destroy(gameObject);
    }
}
