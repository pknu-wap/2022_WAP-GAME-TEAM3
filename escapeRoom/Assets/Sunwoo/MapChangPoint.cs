using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChangPoint : MonoBehaviour
{
    public string transferMapName; //이동할 맵이름       
    public Transform target; // 이동할 타겟 설정

    private Player thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
    }

    // 박스 콜라이더에 닿는 순간 이벤트 발생
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            thePlayer.currentSpot = transferMapName;
            //SceneManager.LoadScene(transferMapName);
            thePlayer.transform.position = target.transform.position;

        }
    }
}
