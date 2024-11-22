using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton eri�imi i�in static property

    public int maxMoves = 10;  // Maksimum hamle say�s�
    private int currentMoves; // Kullan�lan hamle say�s�

    public Frog[] frogs;      // T�m kurba�alar�n referans�

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

        Debug.Log("Oyun Ba�lad�!");
    }

    public void OnFrogTriggered()
    {
        if (!gameActive) return;

        currentMoves++;
        Debug.Log($"Hamle Say�s�: {currentMoves}/{maxMoves}");

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
            Debug.Log("Tebrikler! Oyunu Kazand�n�z!");
        }
        else
        {
            Debug.Log("�zg�n�z, oyunu kaybettiniz.");
        }
    }
}
