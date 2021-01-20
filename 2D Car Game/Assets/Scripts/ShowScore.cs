using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    Text scoreText;
    ScoreSession scoreSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreSession = FindObjectOfType<ScoreSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreSession.GetScore().ToString();
    }
}