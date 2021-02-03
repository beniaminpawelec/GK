using UnityEngine;
using static UnityEngine.Application;

public class ResetGameController : MonoBehaviour
{
    void OnTriggerEnter(
        Collider collider
    )
    {
        if (collider.gameObject.CompareTag("Player"))
            LoadLevel(loadedLevel);
    }
}
