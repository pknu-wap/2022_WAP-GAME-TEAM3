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
                if (Player.P_instance.officekey == true)
                {
                    Player.P_instance.currentSpot = "OfficeIn";
                    SceneManager.LoadScene("Room2f_1");
                }
                else
                {
                    text.text = "키가 필요할 것 같다. 키를 먼저 찾아보자.";
                    StartCoroutine("TextOut", 3.0f);
                }
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
            else if (hit.collider.CompareTag("1FclassRoom"))
            {
                Player.P_instance.currentSpot = "1FCRIN";
                SceneManager.LoadScene("1F_Classroom");
            }
            else if (hit.collider.CompareTag("1FCRout"))
            {
                Player.P_instance.currentSpot = "1FCRout";
                SceneManager.LoadScene("1Floor");
            }
            else if (hit.collider.CompareTag("Professor"))
            {
                Player.P_instance.lockname = "professor";
                hit.transform.GetComponent<CheckingLock>().CheckLock();
            }
            else if (hit.collider.CompareTag("closeDoor"))
            {
                text.text = "문이 잠긴것 같다. 열려있는 방을 찾아보는게 좋겠어.";
                StartCoroutine("TextOut", 3.0f);
            }
            else if (hit.collider.CompareTag("PaperHint1")|| hit.collider.CompareTag("PaperHint2")|| hit.collider.CompareTag("PaperHint3"))
            {
                hit.transform.GetComponent<PaperHint>().CheckPaper();
            }
            else if(hit.collider.CompareTag("getOfficKey") && Player.P_instance.officekey == false)
            {
                hit.transform.GetComponent<OpenKey>().GetOfficKey();
                text.text = "학과 사무실 키를 획득하였다!";
                StartCoroutine("TextOut", 3.0f);
            }
            else if (hit.collider.CompareTag("LabLock") && Player.P_instance.masterKey == false)
            {
                Player.P_instance.lockname = "LabLock";
                hit.transform.GetComponent<CheckingLock>().CheckLock();
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
