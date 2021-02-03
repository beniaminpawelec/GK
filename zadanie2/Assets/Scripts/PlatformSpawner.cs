using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public int MaxPlatforms = 20;
    public GameObject Platform;
    public float HorizontalMin = 7.5f;
    public float HorizontalMax = 14f;
    public float VerticalMin = -6f;
    public float VerticalMax = 6f;
    private Vector2 OriginPosition;

    void Start()
    {
        OriginPosition = transform.position;
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < MaxPlatforms; i++)
        {
            var randomPosition = OriginPosition + new Vector2(
                                     Random.Range(HorizontalMin, HorizontalMax),
                                     Random.Range(VerticalMin, VerticalMax)
                                 );
            Instantiate(Platform, randomPosition, Quaternion.identity);
            OriginPosition = randomPosition;
        }
    }
}