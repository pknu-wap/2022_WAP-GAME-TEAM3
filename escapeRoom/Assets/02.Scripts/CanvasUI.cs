using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    public static CanvasUI canvas = null;
    public GameObject[] life;
    private void Awake()
    {
        if (canvas == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때 
        {
            canvas = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지 
        }
        else
        {
            if (canvas != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미 
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제 
        }

        for(int i = 0; i< Player.P_instance.life; i++)
        {
            life[i].SetActive(true);
        }
    }
}
