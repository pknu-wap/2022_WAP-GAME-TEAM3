using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /*
    public Rigidbody playerRigidbody;
    public Camera fpsCam;

    float MoveSpeed = 5.0f;
    float rotSpeed = 3.0f;
    float currentRot = 0f;

    // Update is called once per frame
    void Update()
    {
        Move();
        RotCtrl();
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * MoveSpeed;
        float zSpeed = zInput * MoveSpeed;

        transform.Translate(Vector3.forward * zSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
    }

    void RotCtrl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        // 마우스 반전
        currentRot -= rotX;

        // 마우스가 특정 각도를 넘어가지 않게 예외처리
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        // Camera는 Player의 자식이므로 플레이어의 Y축 회전은 Camera에게도 똑같이 적용됨
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        // Camera의 transform 컴포넌트의 로컬로테이션의 오일러각에 
        // 현재X축 로테이션을 나타내는 오일러각을 할당해준다.
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
    */
    
    public CharacterController SelectPlayer; // 제어할 캐릭터 컨트롤러
    public Camera fpsCam;
    public float Speed = 5.0f;  // 이동속도
    public float JumpPow = 5.0f;

    private float Gravity = 10.0f; // 중력   
    private Vector3 MoveDir = Vector3.zero; // 캐릭터의 움직이는 방향.
    private bool JumpButtonPressed = false;  //  최종 점프 버튼 눌림 상태
    private bool FlyingMode = false;  // 행글라이더 모드여부

    float rotSpeed = 3.0f;
    float currentRot = 0f;

    public AudioClip footStepSound;
    public float footStepDelay;
    private float nextFootstep = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
        RotCtrl();
        if (Input.GetKeyDown(KeyCode.E))
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("2Fstair"))
                {
                    SceneManager.LoadScene("2Floor");
                }
                else if (hit.collider.CompareTag("JouhyunRoom"))
                {
                    SceneManager.LoadScene("JouhyunRoom");
                }    
              
                    Debug.Log(hit.transform.gameObject.name);
            }
        }
    }

    private void Move()
    {
        if (SelectPlayer == null) return;
        // 캐릭터가 바닥에 붙어 있는 경우만 작동합니다.
        // 캐릭터가 바닥에 붙어 있지 않다면 바닥으로 추락하고 있는 중이므로
        // 바닥 추락 도중에는 방향 전환을 할 수 없기 때문입니다.
        if (SelectPlayer.isGrounded)
        {
            // 키보드에 따른 X, Z 축 이동방향을 새로 결정합니다.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // 오브젝트가 바라보는 앞방향으로 이동방향을 돌려서 조정합니다.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            // 속도를 곱해서 적용합니다.
            MoveDir *= Speed;

            // 스페이스 버튼에 따른 점프 : 최종 점프버튼이 눌려있지 않았던 경우만 작동
            if (JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
            }
        }
        // 캐릭터가 바닥에 붙어 있지 않다면
        else
        {
            // 하강중에 스페이스 버튼을 누르면 슬로우 낙하모드 발동!
            if (MoveDir.y < 0 && JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                FlyingMode = true;
            }

            if (FlyingMode)
            {
                JumpButtonPressed = true;

                // 중력 수치를 감속합니다.
                MoveDir.y *= 0.95f;

                // 하지만 하늘에서 정지해 있는 일은 벌어지지 않게 하기 위해
                // 최소 초당 -1의 하강 속도는 유지합니다.
                if (MoveDir.y > -1) MoveDir.y = -1;

                // 또한 이 때는 방향전환이 가능합니다.
                MoveDir.x = Input.GetAxis("Horizontal");
                MoveDir.z = Input.GetAxis("Vertical");
            }
            else
                // 중력의 영향을 받아 아래쪽으로 하강합니다.           
                MoveDir.y -= Gravity * Time.deltaTime;
        }

        // 점프버튼이 눌려지지 않은 경우
        if (!Input.GetButton("Jump"))
        {
            JumpButtonPressed = false;  // 최종점프 버튼 눌림 상태 해제
            FlyingMode = false;         // 행글라이더 모드 해제
        }
        // 앞 단계까지는 캐릭터가 이동할 방향만 결정하였으며,
        // 실제 캐릭터의 이동은 여기서 담당합니다.
        SelectPlayer.Move(MoveDir * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && !JumpButtonPressed)
        {
            nextFootstep -= Time.deltaTime;
            if (nextFootstep <= 0)
            {
                GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
                nextFootstep += footStepDelay;
            }
        }
}
    void RotCtrl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        // 마우스 반전
        currentRot -= rotX;

        // 마우스가 특정 각도를 넘어가지 않게 예외처리
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        // Camera는 Player의 자식이므로 플레이어의 Y축 회전은 Camera에게도 똑같이 적용됨
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        // Camera의 transform 컴포넌트의 로컬로테이션의 오일러각에 
        // 현재X축 로테이션을 나타내는 오일러각을 할당해준다.
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
}