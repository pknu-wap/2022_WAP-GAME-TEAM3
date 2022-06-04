using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckingLock : MonoBehaviour
{
    public bool Doorlock = true;
    public GameObject Lockwindow;
    public InputField Door_InputField;

    public void CheckLock()
    {
        if (Doorlock)
        {
            Player.P_instance.moveMouse = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("실행");
            Lockwindow.SetActive(true);
        }
    }

    public void CheckButton()
    {
        Player.P_instance.moveMouse = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (Door_InputField.text == "1234" && Player.P_instance.lockname == "professor")
        {
            Debug.Log("오케이~");
            Door_InputField.text = "";
            Lockwindow.SetActive(false);
            Player.P_instance.currentSpot = "LabIn";
            SceneManager.LoadScene("2F_lab");
        }
        else if (Door_InputField.text == "23969" && Player.P_instance.lockname == "LabLock")
        {
            Debug.Log("오케이~");
            Door_InputField.text = "";
            Lockwindow.SetActive(false);
            transform.GetComponent<OpenKey>().GetMasterKey();
        }
        else
        {
            Debug.Log("땡");
            Door_InputField.text = "";
            Lockwindow.SetActive(false);
        }
    }

}
