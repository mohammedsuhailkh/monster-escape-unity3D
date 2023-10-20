using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab; 
    private List<GameObject> coins; 
    private bool gameEnded = false; 

    void Start()
    {
        coins = new List<GameObject>();
        StartCoroutine(SpawnCoinRoutine());
    }

    IEnumerator SpawnCoinRoutine()
    {
        while (!gameEnded)
        {
            yield return new WaitForSeconds(3.0f); // Adjust the delay to 3 seconds

            if (!gameEnded)
            {
                SpawnCoin();
            }
        }
    }

    void SpawnCoin()
    {
        float x = Random.Range(-80f, 80f);
        float z = Random.Range(1f, 1f);
        Quaternion rotation = Quaternion.Euler(90f, 0f, 0f); 
        GameObject newCoin = Instantiate(coinPrefab, new Vector3(x, 7f, z), rotation);
        coins.Add(newCoin); 
    }

    public void DestroyCoin(GameObject coin)
    {
        coins.Remove(coin);
        Destroy(coin);
        SpawnCoin(); 
    }

    public void EndGame()
    {
        gameEnded = true;
    }
}
