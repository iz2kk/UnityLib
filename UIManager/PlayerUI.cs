using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompMessage;
    // Start is called before the first frame update
   public void UpdateText(string messages)
    {
        prompMessage.text = messages;
    }
}
