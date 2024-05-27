using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWMuska : MonoBehaviour
{
    [SerializeField] GameObject muskaManager;
    MuskaCount muskaCount;
    [SerializeField]ParticleSystem monsterParticleSystem;


    private void Awake()
    {
        muskaCount = muskaManager.GetComponent<MuskaCount>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player") {

            if (Input.GetKeyDown(KeyCode.F)) {

                if (muskaCount.checkMuskaCount())
                {
                    muskaCount.decreaseMuskaCount();
                    Vector3 posParticle = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    monsterParticleSystem.transform.position = posParticle;
                    monsterParticleSystem.gameObject.SetActive(true);
                    monsterParticleSystem.Play();
                    Destroy(this.gameObject);
                }
            }
        }

    }




}
