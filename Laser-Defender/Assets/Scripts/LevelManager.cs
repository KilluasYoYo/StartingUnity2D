using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver()
    {
        WaitAndLoad("GameOver",delay);
    }
    public void QuitGame()
    {
        Debug.Log("Quittin Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("scene");
    }

}
