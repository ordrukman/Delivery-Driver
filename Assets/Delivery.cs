using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1 ,1 ,1 ,1);
    [SerializeField] Color32 noPackageColor = new Color32(1 ,1 ,1 ,1);

    [SerializeField] float timeToDestroy = 1f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision!!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, timeToDestroy);
        } else if(other.tag == "Customer") {
            if(hasPackage) {
                Debug.Log("Delivered Package");
                spriteRenderer.color = noPackageColor;
                hasPackage = false;
            } else {
                Debug.Log("pick the Package first!");
            }
        }
    }
}
