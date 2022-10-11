using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    [SerializeField] GameObject door;
    bool DoorOpen;
    protected override void Interact()
    {
        DoorOpen = !DoorOpen;
        door.GetComponent<Animator>().SetBool("isOpenDoor", DoorOpen);

    }
}
