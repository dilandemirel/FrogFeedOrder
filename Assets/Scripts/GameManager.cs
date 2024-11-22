using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton eriþimi için static property

    public int maxMoves = 10;  // Maksimum hamle sayýsý
    private int currentMoves; // Kullanýlan hamle sayýsý

    public Frog[] frogs;      // Tüm kurbaðalarýn referansý

    private bool gameActive = true;

    private void Awake()
    {
        // Singleton kontrol
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        currentMoves = 0;
        gameActive = true;

        foreach (var frog in frogs)
        {
            frog.gameObject.SetActive(true);
        }

        Debug.Log("Oyun Baþladý!");
    }

    public void OnFrogTriggered()
    {
        if (!gameActive) return;

        currentMoves++;
        Debug.Log($"Hamle Sayýsý: {currentMoves}/{maxMoves}");

        if (currentMoves >= maxMoves)
        {
            EndGame(false); 
        }


        if (AreAllFrogsFed())
        {
            EndGame(true);
        }
    }

    private bool AreAllFrogsFed()
    {
        foreach (var frog in frogs)
        {
            if (frog.gameObject.activeSelf) return false;
        }
        return true;
    }

    private void EndGame(bool hasWon)
    {
        gameActive = false;

        if (hasWon)
        {
            Debug.Log("Tebrikler! Oyunu Kazandýnýz!");
        }
        else
        {
            Debug.Log("Üzgünüz, oyunu kaybettiniz.");
        }
    }
}
