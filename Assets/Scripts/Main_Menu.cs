using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{


    public void Freeze()
    {
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Debug.Log("aaah quitou!");
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
