using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public GameObject PlayerSphere;
    public Camera MainCamera;

    private Vector3 _playerCameraForce;

    void Start()
    {
        _playerCameraForce
            = PlayerSphere.GetComponent<ConstantForce>().force;
        StartGame();
    }

    void Update()
    {
        MainCamera.transform.position 
            += _playerCameraForce;
    }

    public void StartGame()
    {
        var rigidBody = PlayerSphere.GetComponent<Rigidbody>();
        rigidBody.useGravity = true;

        var constantForce = PlayerSphere.GetComponent<ConstantForce>();
        constantForce.force = new Vector3(-10, 0, 10);
    }
}
