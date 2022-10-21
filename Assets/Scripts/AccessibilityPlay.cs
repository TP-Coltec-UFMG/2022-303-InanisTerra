using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessibilityPlay : MonoBehaviour
{
    [SerializeField] AudioSource Ob1;
    [SerializeField] AudioSource Ob2;
    [SerializeField] AudioSource Ob3;
    [SerializeField] AudioSource itemcoming;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Obstaculo_sound")
        {
            Ob1.Play();
        }
        if (collision.gameObject.tag == "Obstaculo2")
        {
            Ob2.Play();
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
