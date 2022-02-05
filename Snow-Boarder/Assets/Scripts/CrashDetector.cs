using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    bool hasCrashed;
    [SerializeField]ParticleSystem crashEffect;
    [SerializeField]float delayAmount=1;
    [SerializeField] AudioClip crashSFX;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && hasCrashed == false)
        {
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadSceneOnCrash",delayAmount);
            Debug.Log("Ouch! My head!");
            FindObjectOfType<PlayerController>().disableControls();
            hasCrashed = true;
        }
    }

    void ReloadSceneOnCrash()
    {
        SceneManager.LoadScene(0);
    }
}
