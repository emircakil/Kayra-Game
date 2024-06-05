using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWMuska : MonoBehaviour
{
    [SerializeField] GameObject muskaManager;
    MuskaCount muskaCount;
    public ParticleSystem monsterParticleSystem;


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
                    Vector3 posPar = new Vector3(transform.position.x, transform.position.y +3, transform.position.z);
                    Instantiate(monsterParticleSystem, posPar, Quaternion.LookRotation(Vector3.up));
                    
                    Destroy(this.gameObject);
                }
            }
        }

    }




}
