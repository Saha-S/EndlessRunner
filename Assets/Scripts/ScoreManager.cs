using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.Mathematics;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoretxt;

    public TMP_Text highScoretxt;
    public float scoreCount, highScoreCount, pointPerSecond;
    public bool scoreIncresing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncresing)
        {
            scoreCount += pointPerSecond * Time.deltaTime;
        }
        
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
        }

        scoretxt.text = "Score: " + math.round(scoreCount);
        highScoretxt.text = "High Score: " + math.round(highScoreCount);
    }
    public void AddScore(int pointToAdd)
    {
        scoreCount += pointToAdd;
        
    }
}
