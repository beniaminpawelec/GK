using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private MainGameController _mainGameController;
    public int PointValue = 0;

    void Awake()
    {
        _mainGameController = GameObject
            .FindGameObjectWithTag("MainGameController")
            .GetComponent<MainGameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _mainGameController
                .AddPointsToScore(PointValue);
            Destroy(gameObject);
        }
    }
}