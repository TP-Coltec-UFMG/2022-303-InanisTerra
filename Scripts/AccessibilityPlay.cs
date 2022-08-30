using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibilityPlay : MonoBehaviour
{
    public AudioSource Ob1_2;
    public AudioSource Ob3;
    public AudioSource itemcoming;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Obstaculo")
        {
            Ob1_2.Play();
        }
        if (collision.gameObject.tag == "Obs3")
        {
            Ob3.Play();
        }
        if (collision.gameObject.tag == "Item")
        {
            itemcoming.Play();
        }
    }
}
