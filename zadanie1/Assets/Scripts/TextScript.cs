using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    TextMesh textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Score Sign").GetComponent<TextMesh>();

        textObject.text = "Score: " + ScoresCounter.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoresCounter.Score < 9)
            textObject.text = "Score: " + ScoresCounter.Score.ToString();
        else
            textObject.text = "YOU WIN!!!";

    }
}
