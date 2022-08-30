using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float additionalScrollSpeed;

    public GameObject[] backgrounds;

    public float[] scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        for(int background = 0; background < backgrounds.Length; background++){
            Renderer rend = backgrounds[background].GetComponent<Renderer>();
            float offset = Time.time * (scrollSpeed[background] + additionalScrollSpeed);
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
