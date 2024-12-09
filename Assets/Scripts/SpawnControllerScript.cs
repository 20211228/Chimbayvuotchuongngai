using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerScript : MonoBehaviour
{

    public GameObject Log;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLog());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnLog()
    {
        while (true)
        {
            GameObject newLog = Instantiate(Log, transform.position, new Quaternion());
            Vector3 potition = newLog.transform.position;
            potition.y = Random.Range(2f, 4.2f);
            newLog.transform.position = potition;

            yield return new WaitForSeconds(1);
        }
    }
}
