using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "Muskayi al";
    }

    public void Interact()
    {
        Destroy(gameObject);
    }
}
