using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    public Text text;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            text.text = "인공지능 중간고사는 개같이 멸망 하였다. 더 이상 내 머리를 믿을 수 없다. 기말고사 시험지를 훔쳐서 조금이라도 만회해 보자.";
            StartCoroutine("TextOut", 3.0f);
        }
    }
    IEnumerator TextOut()
    {
        yield return new WaitForSeconds(5.0f);
        text.GetComponent<Text>().text = "";
    }
}
