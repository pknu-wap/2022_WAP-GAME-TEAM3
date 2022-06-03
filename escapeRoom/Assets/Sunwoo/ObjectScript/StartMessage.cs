using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
            Invoke("OffMessage", 5.0f);
        }
    }

    void OffMessage()
    {
        text.SetActive(false);
    }
}
