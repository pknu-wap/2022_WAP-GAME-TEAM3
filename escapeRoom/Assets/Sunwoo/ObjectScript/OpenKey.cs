using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKey : MonoBehaviour
{
    public GameObject KEY;
    public void GetOfficKey()
    {
        Player.P_instance.moveMouse = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        KEY.SetActive(true);
        Player.P_instance.officekey = true;
    }
    public void GetMasterKey()
    {
        Player.P_instance.moveMouse = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        KEY.SetActive(true);
        Player.P_instance.masterKey = true;
    }

    public void CheckOfficeKeyButton()
    {
        KEY.SetActive(false);
        Player.P_instance.moveMouse = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CheckmasterKeyButton()
    {
        KEY.SetActive(false);
        Player.P_instance.moveMouse = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
