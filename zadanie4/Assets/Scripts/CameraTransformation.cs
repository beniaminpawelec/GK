using UnityEngine;

public class CameraTransformation : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Offset;

    void Start()
    {
        Offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Player.transform.position + Offset;
    }
}
