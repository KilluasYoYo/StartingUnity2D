using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 1f;

    static AudioPlayer instance;

    /*public AudioPlayer GetInstance()
    {
        return instance;
    }*/

    void Awake()
    {
        ManageSingleton();    
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            PlayClip(shootingClip,shootingVolume);
        }
    }

    public void PlayExplosionClip()
    {
        PlayClip(explosionClip,explosionVolume);
    }
    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
        }
    }
}
