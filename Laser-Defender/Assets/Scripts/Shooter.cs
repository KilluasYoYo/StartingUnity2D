using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject porjectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 10f;
    [SerializeField] float baseFiringRate = 0.2f;
    [Header("IA")]
    [SerializeField] bool useIA;
    [SerializeField] float minFiringRate = 0.1f;
    [SerializeField] float firingRateVarience = 0f;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    void Start()
    {
        if(useIA)
        { 
           isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireCountinously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireCountinously()
    {
        while(true)
        {
            GameObject instance = Instantiate(porjectilePrefab, 
                                              transform.position,
                                              Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);
        
            float timeToNextProjectile = UnityEngine.Random.Range(baseFiringRate - firingRateVarience,
                                                                  baseFiringRate + firingRateVarience);
            
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFiringRate, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        

        }
    }
}
