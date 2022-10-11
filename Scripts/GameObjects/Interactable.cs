using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool UseEvent;
    public string promptMessage;
    public void BaseInteract()
    {
        // invoke event
        if (UseEvent)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        //interact
        Interact();
    }

    protected virtual void Interact()
    {

    }

}
