using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperHint : MonoBehaviour
{
    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;

    public void CheckPaper()
    {
        Player.P_instance.moveMouse = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (this.gameObject.name=="PaperHint1")
        {
            paper1.SetActive(true);
        }
        else if (this.gameObject.name == "PaperHint2")
        {
            paper2.SetActive(true);
        }
        else if (this.gameObject.name == "PaperHint3")
        {
            paper3.SetActive(true);
        }
    }

    public void CheckButton()
    {
        paper1.SetActive(false);
        paper2.SetActive(false);
        paper3.SetActive(false);
        Player.P_instance.moveMouse = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
