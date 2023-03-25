using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destoryDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && hasPackage == false)
        {
            Destroy(other.gameObject, destoryDelay);
            spriteRenderer.color = hasPackageColor;
            Debug.Log("물품픽업i~!");
            hasPackage = true;
        }
        if(other.tag =="Customer" && hasPackage)
        {
            Debug.Log("물품 배달 완료");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
