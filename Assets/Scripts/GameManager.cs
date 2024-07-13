using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    Vector3 gereratorStartPoint;
    public PlayerController thePlayer;
    Vector3 playerStartPoint;

    PlatformRemover[] platformList;

    ScoreManager scoreManager;

    public PlayAgainMenu playAgain;
    public GameObject pauseButton; // Reference to the pause button to disable


    // Start is called before the first frame update
    void Start()
    {
        gereratorStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        // StartCoroutine("RestartGameCo");
        scoreManager.scoreIncresing = false;
        thePlayer.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(true);
        if (pauseButton != null)
        {
            pauseButton.SetActive(false);
        }

    }
    public void Reset()
    {
        
        playAgain.gameObject.SetActive(false);
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = gereratorStartPoint;
        thePlayer.gameObject.SetActive(true);
        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }

        // to clear platforms after player die
        platformList = FindObjectsOfType<PlatformRemover>();

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncresing = true;

        for (int i = 1; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
    }
   
}
