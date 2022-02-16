using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseEnd : MonoBehaviour
{
    public GameObject resume;
    public GameObject menu;
    public GameObject newGame;
    public TextMeshProUGUI result;
    bool isPaused = false;
    bool end = false;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !end)
        {
            TogglePause();
        }
    }

    public void End()
    {
        end = true;
        Time.timeScale = 0.0f;
        this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
        result.text = "Game Over";
        newGame.SetActive(true);
        menu.SetActive(true);
    }

    public void Replay(string name)
    {
        Manager.initial = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            //unpause
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            isPaused = false;
            Time.timeScale = 1.0f;
            result.text = "";
            resume.SetActive(false);
            menu.SetActive(false);
        }
        else
        {
            //pause
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
            isPaused = true;
            Time.timeScale = 0.0f;
            result.text = "Paused";
            resume.SetActive(true);
            menu.SetActive(true);
        }
    }

    public void LoadLevel(string name)
    {
        Time.timeScale = 1.0f;
        Manager.initial = true;
        SceneManager.LoadScene(name);
    }
}
