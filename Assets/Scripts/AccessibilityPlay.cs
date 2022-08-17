using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibilityPlay : MonoBehaviour
{
    public AudioSource souce;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Obstaculo")
        {
            souce.Play();
		}
    }
}
