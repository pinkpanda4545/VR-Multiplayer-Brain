using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationDelay : MonoBehaviour
{
    public GameObject narration1;
    public GameObject narration2;
    
    void Start()
    {
        StartCoroutine(Wait3Seconds()); 
    }

    IEnumerator Wait3Seconds()
    {
        yield return new WaitForSeconds(3);
        narration1.SetActive(true); 
        narration2.SetActive(true);
    }
}
