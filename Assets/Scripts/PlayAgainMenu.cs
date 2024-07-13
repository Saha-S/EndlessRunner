using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainMenu : MonoBehaviour
{
    public string menuLevel;


    // Start is called before the first frame update
    public void RestartGame()
    {
       
        FindObjectOfType<GameManager>().Reset();


    }

    public void QuitGame() {
        
        SceneManager.LoadScene(menuLevel);
    }
}
