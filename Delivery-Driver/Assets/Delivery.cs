using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField]float destroyDelay = 1;
    bool hasPackage;
   void OnCollisionEnter2D(Collision2D other) 
   {
       Debug.Log("Can't you just drive it better?");
   }
   void OnTriggerEnter2D(Collider2D other) 
   {

       // hasPackage == false --> !hasPackage       !!!!
       if(other.tag == "Package" && hasPackage == true)
        {
            Debug.Log("I already have a package.");
        }
        
        if(other.tag == "Package" && hasPackage == false)
        {
            Debug.Log("I picked up the package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
        }


        if(other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Package delivered!!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }    
   }
}
