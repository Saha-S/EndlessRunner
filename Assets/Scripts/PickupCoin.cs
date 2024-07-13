using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    public int scoreToGive;
    ScoreManager scoreManager;
    AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        coinSound =GameObject.Find("coin").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") {
            scoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            coinSound.Play();
        }
    }
        
}
