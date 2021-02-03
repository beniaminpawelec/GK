using UnityEngine;

public class PyramidGenerator : MonoBehaviour
{
    public GameObject Obiects;
    public GameObject Origin;

    void Start()
    {
        var objectScale = Obiects.transform.localScale;
        var objectHeight = objectScale.y;
        var objectR = objectScale.x;
        var layerCount = 11;

        for (int k = 0; k < layerCount; k++)
        {
            var n = k;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Instantiate(
                        Obiects,
                        Origin.transform.position + new Vector3(
                            objectR / 2 * (layerCount - k) + i * objectR,
                            layerCount - k + objectR,
                            objectR / 2 * (layerCount - k) + j * objectR),
                        Quaternion.identity
                    );
        }
    }
}
