using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. 앞뒤 좌우로 방향을 만든다.
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        //대각선 이동으로 하면서 루트2로 길이가 늘어나기에 1로 만들어준다. (정규화:Normalize)
        dir.Normalize();

        // 3. 그 방향으로 이동한다.
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

    }
}
