using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 1f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    private RaycastHit[] hits = new RaycastHit[8];

    private void Awake()
    {
        mainCam = this.gameObject.GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {

        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);

        int hitCount = Physics.RaycastNonAlloc(ray, hits, interactionDistance);

        bool hitSomething = false;

        for (int i = 0; i < hitCount; i++)
        {
            RaycastHit hit = hits[i];
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (hit.collider.tag == "Interact")
                {
                    hitSomething = true;
                    interactionText.text = interactable.GetDescription();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.Interact();
                    }
                }
            }
        }

        interactionUI.SetActive(hitSomething);
    }
}