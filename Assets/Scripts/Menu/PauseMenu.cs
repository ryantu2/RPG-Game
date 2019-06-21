using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {


    
    public GameObject pausePanelUI;
	
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameManager.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pausePanelUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.isPaused = false;
    }

    private void Pause()
    {
        pausePanelUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.isPaused = true;
    }

    
}
