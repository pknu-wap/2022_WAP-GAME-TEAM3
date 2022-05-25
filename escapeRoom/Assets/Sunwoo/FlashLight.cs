using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    bool FlashState = false;
    public void UseFlash()
    {
        if (FlashState == false)
        {
            FlashState = true;
            transform.GetComponent<Light>().enabled = true;
        }
        else
        {
            FlashState = false;
            transform.GetComponent<Light>().enabled = false;
        }
    }
}
