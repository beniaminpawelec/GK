using UnityEngine;

public class WaterfallAnimationExecutor : MonoBehaviour
{
    public KeyCode KeyToAnimateStart;
    private ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        var waterfall 
            = GameObject.FindGameObjectWithTag("Waterfall");
        _particleSystem
            = waterfall.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyToAnimateStart))
            return;

        if (_particleSystem.isPlaying)
            _particleSystem.Stop();
        else
            _particleSystem.Play();
    }
}
