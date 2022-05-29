using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public Text text;
    public void P_Interaction()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Player.P_instance.interactDistance))
        {
            if (hit.collider.CompareTag("204frontin")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "204frontin";
                SceneManager.LoadScene("Room2F_204");
            }
            else if (hit.collider.CompareTag("204backin")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "204backin";
                SceneManager.LoadScene("Room2F_204");
            }
            else if (hit.collider.CompareTag("204backout")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "204backout";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("204frontout")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "204frontout";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("OfficeIn")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "OfficeIn";
                SceneManager.LoadScene("Room2f_1");
            }
            else if (hit.collider.CompareTag("OfficeOut")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "OfficeOut";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("LabIn")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "LabIn";
                SceneManager.LoadScene("2F_lab");
            }
            else if (hit.collider.CompareTag("LabOut")) // 문 상호작용
            {
                Player.P_instance.currentSpot = "LabOut";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("Professor"))
            {
                Player.P_instance.lockname = "professor";
                transform.GetComponent<CheckingLock>().CheckLock();
            }
            Debug.Log(hit.transform.gameObject.name);
        }
    }

    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(3.0f);
        text.GetComponent<Text>().text = "";
    }
}
