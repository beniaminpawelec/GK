using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        renderer.material.SetColor("_Color", Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

        if (ScoresCounter.Score >= 9)
        {
            RemoveObjectsWithTag("cylinder");
            RemoveObjectsWithTag("capsule");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cylinder")
        {
            other.gameObject.SetActive(false);
            ScoresCounter.Score++;
        }
        else if (other.gameObject.tag == "capsule")
        {
            other.gameObject.SetActive(false);
            ScoresCounter.Score += 3;
        }
    }

    void RemoveObjectsWithTag(string tag)
    {
        var capsulePickUpsLeft = GameObject.FindGameObjectsWithTag(tag);

        if (capsulePickUpsLeft != null)
            foreach (var item in capsulePickUpsLeft)
                item.gameObject.SetActive(false);
    }


}
