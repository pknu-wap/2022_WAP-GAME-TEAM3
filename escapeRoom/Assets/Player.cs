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
        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. �յ� �¿�� ������ �����.
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        //�밢�� �̵����� �ϸ鼭 ��Ʈ2�� ���̰� �þ�⿡ 1�� ������ش�. (����ȭ:Normalize)
        dir.Normalize();

        // 3. �� �������� �̵��Ѵ�.
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

    }
}
