using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CotScript : MonoBehaviour
{
    public float Speed = 5;
    float PostLimit;

    // Start is called before the first frame update
    void Start()
    {
        PostLimit = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime*Speed*-1,0,0);
        if (transform.position.x < PostLimit)
        {
            Destroy(gameObject);
        }
    }
}
