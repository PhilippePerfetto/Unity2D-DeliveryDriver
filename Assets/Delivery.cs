using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool taken = false;
    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("OnTriggerEnter2D");

        if (other.tag == "Package" && !taken)
        {
            taken = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, 0.5f);
        }
        else if (other.tag == "Customer" && taken)
        {
            Debug.Log("Victory");
            taken = false;
            spriteRenderer.color = noPackageColor;
            Destroy(other.gameObject, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
