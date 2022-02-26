using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int coinScore = 100;
    bool wasCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToPoint(coinScore);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        }    
    }


}
