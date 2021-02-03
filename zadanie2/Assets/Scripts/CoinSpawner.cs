using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform[] ItemSpawns;
    public GameObject[] Coins;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var itemSpawn in ItemSpawns)
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip <= 0)
            {

            }

            var coin = Coins[Random.Range(0, Coins.Length)];
            Instantiate(coin, itemSpawn.position, Quaternion.identity);
        }
    }
}