using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool gameispause = false;
    public GameObject pausemenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameispause)
            {
                Resume();
            }
            else
            {
                pauseMENU();
            }
        }
    }
    public void Returntogame()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameispause = false;
    }

    void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameispause = false;
    }
    void pauseMENU()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameispause = true;
    }
}
