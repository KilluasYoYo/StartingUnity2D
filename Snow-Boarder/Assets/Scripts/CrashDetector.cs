using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]ParticleSystem crashEffect;
    [SerializeField]float delayAmount=1;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground")
        {
            crashEffect.Play();
            Invoke("ReloadSceneOnCrash",delayAmount);
            Debug.Log("Ouch! My head!");
        }
    }

    void ReloadSceneOnCrash()
    {
        SceneManager.LoadScene(0);
    }
}
