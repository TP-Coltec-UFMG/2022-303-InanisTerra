using UnityEngine;
using System.Collections;
using TMPro;

public class AlphaText : MonoBehaviour 
{
    public float speedFade;
    public TextMeshProUGUI textmeshPro;
    private float count;
 
    void Update () {
        count += speedFade * Time.deltaTime;
        textmeshPro.color = new Color(0.5f,0.5f,0.5f,Mathf.Sin(count)*0.5f);
    }
}