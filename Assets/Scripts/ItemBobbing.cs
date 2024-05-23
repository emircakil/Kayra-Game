using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBobbing : MonoBehaviour
{
    public float bobbingSpeed = 7f; 
    public float bobbingAmount = 0.2f;
    private float lerpSpeed = 5f;

    private Vector3 defaultPosition;

    void Start()
    {

        defaultPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            float bobbingOffset = Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;
            Vector3 bobbingPosition = defaultPosition + new Vector3(0, bobbingOffset, 0);

            transform.localPosition = bobbingPosition;
        }

        else {
            transform.localPosition = Vector3.Lerp(transform.localPosition, defaultPosition, lerpSpeed * Time.deltaTime);
        }
    }
   
}
