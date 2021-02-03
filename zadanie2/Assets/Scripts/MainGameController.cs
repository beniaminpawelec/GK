using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    private int _score;
    private bool _isEnd;

    public Text ScoreTextControl;
    public Text TimeTextControl;
    
    public float GameTime = 30.0f;
    public int WinScore = 30;

    // Update is called once per frame
    void Update()
    {
        if(_isEnd)
            return;

        GameTime -= Time.deltaTime;
        if (GameTime <= 0.0f)
        {
            _isEnd = true;
            GameTime = 0.0f;
        }

        if (_score >= WinScore)
        {
            _isEnd = true;
            Application
                .LoadLevel(Application.loadedLevel);
        }

        ScoreTextControl.text = $"Score: {_score}";
        TimeTextControl.text 
            = $"Time: 0:{Mathf.CeilToInt(GameTime)}"
                .PadLeft(2, '0');
    }

    public void AddPointsToScore(int point)
    {
        _score += point;
    }
}
