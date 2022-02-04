using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]float delayAmount=1;
    [SerializeField]ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            finishEffect.Play();
            Invoke("ReloadSceneOnFinishLine",delayAmount);
        }
    }
    void ReloadSceneOnFinishLine()
    {
        SceneManager.LoadScene(0);
        Debug.Log("I finished. Finally...");
    }
}
