using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHadEnded = false;

    [SerializeField] LoadingManager loadingManager;
    [SerializeField] string scenName;
    [SerializeField] float exitDelay;

    public void EndGame()
    {
        if(gameHadEnded == false)
        {
            gameHadEnded = true;
            Debug.Log("Game Over");
            Invoke("MainMenu", exitDelay);
        }
    }

    private void MainMenu()
    {
        HealthManager.health = 3;
        loadingManager.LoadScene(scenName);
    }
}
