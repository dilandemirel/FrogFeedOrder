using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Frog : MonoBehaviour
{
    public Color frogColor; // Kurbaðanýn rengi
    public Direction facingDirection; // Kurbaðanýn bakýþ yönü
    public float tongueExtendDistance = 5f; // Kurbaðanýn dilinin ne kadar uzaða uzayacaðý

    private Animator frogAnimator;


    private void Start()
    {
        frogAnimator = GetComponent<Animator>();
    }

    // Kurbaða ile etkileþime girildiðinde yapýlacak iþlemler
    public void InteractWithFrog()
    {
        
        Debug.Log($"Kurbaða {frogColor} rengiyle týklandý!");

        ExtendTongue(facingDirection);

        CheckForBerry(facingDirection);
    }

    // Kurbaðanýn dilini uzatma fonksiyonu
    private void ExtendTongue(Direction direction)
    {
        // Animasyon baþlatma (isteðe baðlý)
        if (frogAnimator != null)
        {
            frogAnimator.SetTrigger("ExtendTongue");
        }

        // Dilin uzama yönü
        Vector3 tongueDirection = Vector3.zero;

        switch (direction)
        {
            case Direction.Up:
                tongueDirection = Vector3.forward; 
                break;
            case Direction.Down:
                tongueDirection = Vector3.back; 
                break;
            case Direction.Left:
                tongueDirection = Vector3.left; 
                break;
            case Direction.Right:
                tongueDirection = Vector3.right; 
                break;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, tongueDirection, out hit, tongueExtendDistance))
        {
            // Eðer bir berriye çarptýysa
            Berry berry = hit.collider.GetComponent<Berry>();
            if (berry != null && berry.berryColor == frogColor)
            {
                
                berry.CollectBerry();
            }
        }
    }

    // Kurbaðanýn yediði berriyi kontrol et
    private void CheckForBerry(Direction direction)
    {

    }
}
