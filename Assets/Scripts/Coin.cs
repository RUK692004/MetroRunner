using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin touched by : " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin Collected!");
            AudioManager.Instance.PlayCoin();

            CoinManager.Instance.AddCoin();

            Destroy(gameObject);
        }
    }
}