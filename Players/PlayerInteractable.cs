using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    Camera cam;
    //
    [SerializeField] float distance = 30f;
    [SerializeField] LayerMask maskLayer;
    //
    PlayerUI playerUI;
    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        cam =  GetComponent<PlayerLook>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        InteractRay();
    }

    void InteractRay()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;
        bool isRayDetected = Physics.Raycast(ray, out hitInfo, distance, maskLayer);
        if (isRayDetected)
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                playerUI.UpdateText(interactable.promptMessage);
            }
        }
    }
}
