using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuskTrail : MonoBehaviour
{
    [SerializeField]ParticleSystem duskTrail;



    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            duskTrail.Play();
        }
    }
    void OnCollisionExit2D(Collision2D other) 
    {     
        if(other.gameObject.tag == "Ground")
        {
            duskTrail.Stop();
        } 
    }


}
