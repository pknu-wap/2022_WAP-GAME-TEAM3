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
            if (hit.collider.CompareTag("204frontin")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "204frontin";
                SceneManager.LoadScene("Room2F_204");
            }
            else if (hit.collider.CompareTag("204backin")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "204backin";
                SceneManager.LoadScene("Room2F_204");
            }
            else if (hit.collider.CompareTag("204backout")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "204backout";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("204frontout")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "204frontout";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("OfficeIn")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "OfficeIn";
                SceneManager.LoadScene("Room2f_1");
            }
            else if (hit.collider.CompareTag("OfficeOut")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "OfficeOut";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("LabIn")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "LabIn";
                SceneManager.LoadScene("2F_lab");
            }
            else if (hit.collider.CompareTag("LabOut")) // �� ��ȣ�ۿ�
            {
                Player.P_instance.currentSpot = "LabOut";
                SceneManager.LoadScene("2Floor");
            }
            else if (hit.collider.CompareTag("Professor"))
            {
                Player.P_instance.lockname = "professor";
                hit.transform.GetComponent<CheckingLock>().CheckLock();
            }
            else if (hit.collider.CompareTag("lockDoor"))
            {
                text.text = "���� ���� ����. �����ִ� ���� ã�ƺ��°� ���ھ�.";
                StartCoroutine(TextOut());
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
