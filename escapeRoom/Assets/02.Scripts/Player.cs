using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /* // �̱��� // * instance��� ������ static���� ������ �Ͽ� �ٸ� ������Ʈ ���� ��ũ��Ʈ������ instance�� �ҷ��� �� �ְ� �մϴ� */
    public static Player P_instance = null; 
    private void Awake()
    {
        Debug.Log("�÷��̾� �̱��� ����!");
        if (P_instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������ 
        {
            P_instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ���� 
        } 
        else 
        { 
            if (P_instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ� 
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ���� 
        } 
    }

    public CharacterController SelectPlayer; // ������ ĳ���� ��Ʈ�ѷ�
    public Camera fpsCam;
    public float Speed = 5.0f;  // �̵��ӵ�
    public float JumpPow = 5.0f;

    private float Gravity = 20.0f; // �߷�   
    private Vector3 MoveDir = Vector3.zero; // ĳ������ �����̴� ����.
    private bool JumpButtonPressed = false;  //  ���� ���� ��ư ���� ����

    float rotSpeed = 3.0f;
    float currentRot = 0f;

    public AudioClip footStepSound;
    public float footStepDelay = 0.5f;
    private float nextFootstep = 0;
    public bool slowStep = false;
    public int life = 3;

    public string currentSpot = "1FStart";
    public string lockname = "";
    public float interactDistance = 3.0f;

    // Update is called once per frame
    void Update()
    {
        Move();
        RotCtrl();
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.GetComponent<Interaction>().P_Interaction();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Find("Main Camera").GetComponent<FlashLight>().UseFlash();
        }
    }

    private void Move()
    {
        if (SelectPlayer == null) return;
        // ĳ���Ͱ� �ٴڿ� �پ� �ִ� ��츸 �۵��մϴ�.
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ� �ٴ����� �߶��ϰ� �ִ� ���̹Ƿ�
        // �ٴ� �߶� ���߿��� ���� ��ȯ�� �� �� ���� �����Դϴ�.
        if (SelectPlayer.isGrounded)
        {
            // Ű���忡 ���� X, Z �� �̵������� ���� �����մϴ�.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // ������Ʈ�� �ٶ󺸴� �չ������� �̵������� ������ �����մϴ�.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            // �ӵ��� ���ؼ� �����մϴ�.
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<AudioSource>().volume = 0.35f;
                footStepDelay = 1.0f;
                Speed = 2.0f;
            }
            else
            {
                GetComponent<AudioSource>().volume = 1.0f;
                footStepDelay = 0.5f;
                Speed = 5.0f;
            }
            MoveDir *= Speed;

            // �����̽� ��ư�� ���� ���� : ���� ������ư�� �������� �ʾҴ� ��츸 �۵�
            if (JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                JumpButtonPressed = true;
                MoveDir.y = JumpPow;
            }
        }
        // ĳ���Ͱ� �ٴڿ� �پ� ���� �ʴٸ�
        else
        {
            // �߷��� ������ �޾� �Ʒ������� �ϰ��մϴ�.           
            MoveDir.y -= Gravity * Time.deltaTime;
        }

        // ������ư�� �������� ���� ���
        if (!Input.GetButton("Jump"))
        {
            JumpButtonPressed = false;  // �������� ��ư ���� ���� ����
        }
        // �� �ܰ������ ĳ���Ͱ� �̵��� ���⸸ �����Ͽ�����,
        // ���� ĳ������ �̵��� ���⼭ ����մϴ�.
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

        // ���콺 ����
        currentRot -= rotX;

        // ���콺�� Ư�� ������ �Ѿ�� �ʰ� ����ó��
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        // Camera�� Player�� �ڽ��̹Ƿ� �÷��̾��� Y�� ȸ���� Camera���Ե� �Ȱ��� �����
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        // Camera�� transform ������Ʈ�� ���÷����̼��� ���Ϸ����� 
        // ����X�� �����̼��� ��Ÿ���� ���Ϸ����� �Ҵ����ش�.
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
}