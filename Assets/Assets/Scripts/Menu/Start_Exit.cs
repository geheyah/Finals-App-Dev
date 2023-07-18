using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Exit : MonoBehaviour
{
    [SerializeField] DigitalGlitch digitalGlitch;

    private void FixedUpdate()
    {
        digitalGlitch.intensity = 0.1f;
    }

    public void StartGame(string scenName)
    {
        SceneManager.LoadScene(scenName);
    }

    public void QuitGame()
    {
        Debug.Log("Exited the Game");
        Application.Quit();
    }
}
