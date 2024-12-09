using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRun : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.material.mainTextureOffset = new Vector2(Time.time * 0.2f, 0);
    }
}
