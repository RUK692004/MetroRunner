using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public TMP_Text coinText;

    private int coinCount = 0;

    void Awake()
    {
        Instance = this;

        UpdateUI();
    }

    public void AddCoin()
    {
        coinCount++;

        UpdateUI();

        Debug.Log("Coins : " + coinCount);
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text =
                "COINS : " + coinCount;
        }
    }

    public int GetCoins()
    {
        return coinCount;
    }
}