using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHadEnded = false;

    [SerializeField] LoadingManager loadingManager;
    [SerializeField] string sceneName;
    [SerializeField] float exitDelay;

    public GameObject levelCompleteUI;

    public void CompleteLevel()
    {
        StartCoroutine(LoadSceneCompleteLevel());
    }

    IEnumerator LoadSceneCompleteLevel()
    {
        levelCompleteUI.SetActive(true);
        yield return new WaitForSeconds(3);
        loadingManager.LoadScene(sceneName);
    }

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
        HealthManager.health = 5;
        loadingManager.LoadScene(sceneName);
    }
}
