using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        cameraShake = Camera.main.GetComponent<CameraShake>();    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayExplosionClip();
            ShakeCamera();
        //    damageDealer.Hit();
        }  

    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(!isPlayer)
            {
                scoreKeeper.ModifyScore(score);
            }
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        if(isPlayer)
        {
        levelManager.LoadGameOver();
        }
    }

   void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
