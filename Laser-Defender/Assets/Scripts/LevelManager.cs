using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    [SerializeField] float delay = 1f;
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver()
    {
      StartCoroutine(WaitAndLoad(2,delay));
    }
    public void QuitGame()
    {
        Debug.Log("Quittin Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

}
