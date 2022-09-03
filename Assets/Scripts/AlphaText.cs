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
        textmeshPro.color = new Color(255f, 236f, 184f, Mathf.Sin(count)*1.9f);
    }
}