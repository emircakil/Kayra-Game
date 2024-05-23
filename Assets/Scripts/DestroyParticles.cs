using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(waitAndDestroy());
    }

    IEnumerator waitAndDestroy() { 
    
        yield return new WaitForSecondsRealtime(2f);
        this.gameObject.SetActive(false);

       
    }
}
