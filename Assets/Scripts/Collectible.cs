using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject muskaManager;
    MuskaCount muskaCount;

    private void Awake()
    {
        muskaCount = muskaManager.GetComponent<MuskaCount>();
    }

    public string GetDescription()
    {
        return "Muskayı Al";
    }

    public void Interact()
    {   
        muskaCount.increaseMuskaCount();
        Destroy(gameObject);
    }
}
