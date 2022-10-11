
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Interactable), true)]
public class InteractEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();
        if (target.GetType() == typeof(InteractionOnlyEvent))
        {
            //interactable.promptMessage = EditorGUILayout.TextField("Promp Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("Event only Interact can only use Unity Events", MessageType.Info);
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.UseEvent = true;
                interactable.gameObject.AddComponent<InteractionEvent>();

            }
        }
        else
        {
            if (interactable.UseEvent)
            {
                if (interactable.GetComponent<InteractionEvent>() == null)
                {
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                if (interactable.GetComponent<InteractionEvent>() != null)
                {
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}
