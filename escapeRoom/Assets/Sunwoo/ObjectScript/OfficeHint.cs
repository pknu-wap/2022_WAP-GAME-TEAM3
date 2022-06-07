using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeHint : MonoBehaviour
{
    public GameObject hint;

    public void CheckHint()
    {
        Player.P_instance.moveMouse = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        hint.SetActive(true);
        Player.P_instance.officekey = true;
    }

    public void CheckHintButton()
    {
        hint.SetActive(false);
        Player.P_instance.moveMouse = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
