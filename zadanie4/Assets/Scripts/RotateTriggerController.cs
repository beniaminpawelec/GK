using UnityEngine;

public class RotateTriggerController : MonoBehaviour
{
    private bool _isInTrigged = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
            _isInTrigged = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
            _isInTrigged = false;
    }

    void Update()
    {
        var transform = GetComponent<Transform>();
        if (_isInTrigged)
            transform.Rotate(new Vector3(0.5f, 0, 0.5f), 1f);
    }
}
