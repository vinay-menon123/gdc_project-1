using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject GameOverScreen;
    // Start is called before the first frame update
    private void awake()
    {
        isGameOver = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            GameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel ()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         isGameOver = false;
     }
}
