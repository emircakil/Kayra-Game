using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWMuska : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject muskaManager;
    MuskaCount muskaCount;
    [SerializeField]ParticleSystem monsterParticleSystem;

    private void Awake()
    {
        muskaCount = muskaManager.GetComponent<MuskaCount>();
    }

    public string GetDescription()
    {
        return "Hortlagi Oldur";
    }

    public void Interact()
    {

        

        if (muskaCount.checkMuskaCount())
        {
            muskaCount.decreaseMuskaCount();
            monsterParticleSystem.transform.position = this.gameObject.transform.position;
            monsterParticleSystem.gameObject.SetActive(true);
            monsterParticleSystem.Play();
            Destroy(this.gameObject);


        }

    }

  



}
