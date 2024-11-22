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
    public Color frogColor; // Kurba�an�n rengi
    public Direction facingDirection; // Kurba�an�n bak�� y�n�
    public float tongueExtendDistance = 5f; // Kurba�an�n dilinin ne kadar uza�a uzayaca��

    private Animator frogAnimator;


    private void Start()
    {
        frogAnimator = GetComponent<Animator>();
    }

    // Kurba�a ile etkile�ime girildi�inde yap�lacak i�lemler
    public void InteractWithFrog()
    {
        
        Debug.Log($"Kurba�a {frogColor} rengiyle t�kland�!");

        ExtendTongue(facingDirection);

        CheckForBerry(facingDirection);
    }

    // Kurba�an�n dilini uzatma fonksiyonu
    private void ExtendTongue(Direction direction)
    {
        // Animasyon ba�latma (iste�e ba�l�)
        if (frogAnimator != null)
        {
            frogAnimator.SetTrigger("ExtendTongue");
        }

        // Dilin uzama y�n�
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
            // E�er bir berriye �arpt�ysa
            Berry berry = hit.collider.GetComponent<Berry>();
            if (berry != null && berry.berryColor == frogColor)
            {
                
                berry.CollectBerry();
            }
        }
    }

    // Kurba�an�n yedi�i berriyi kontrol et
    private void CheckForBerry(Direction direction)
    {

    }
}
