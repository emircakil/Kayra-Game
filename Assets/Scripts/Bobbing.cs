using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float bobbingSpeed = 5f;
    public float bobbingAmount = 0.01f; 

    private Vector3 defaultPosition; 

    void Start()
    {
        defaultPosition = transform.localPosition;
    }

    void Update()
    {
      
        float bobbingOffset = Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;
        Vector3 bobbingPosition = defaultPosition + new Vector3(0, bobbingOffset, 0);

        
        transform.localPosition = bobbingPosition;
    }
}
