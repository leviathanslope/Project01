using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Done");
    }
}
