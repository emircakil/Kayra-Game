using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWMuska : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject muskaManager;
    MuskaCount muskaCount;
    [SerializeField]ParticleSystem monsterParticleSystem;
    public GameObject monster;

    private void Awake()
    {
        muskaCount = muskaManager.GetComponent<MuskaCount>();
    }

    public string GetDescription()
    {
        return "Hortlağı Öldur";
    }

    public void Interact()
    {


        if (muskaCount.checkMuskaCount())
        {
            muskaCount.decreaseMuskaCount();
            monsterParticleSystem.transform.position = this.gameObject.transform.position;
            monsterParticleSystem.gameObject.SetActive(true);
            monsterParticleSystem.Play();
            Destroy(monster);


        }

    }

  



}
