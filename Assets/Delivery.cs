using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color(0.3196659f, 0.735849f, 0.2596297f, 1);
    [SerializeField] Color32 noPackageColor = new Color(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;
    [SerializeField] float destroyDelay = 0.5f;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("ouch");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage){
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if(other.tag == "Customer" && hasPackage == true){
            Debug.Log("Package delivered!");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
