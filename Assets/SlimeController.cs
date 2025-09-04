using UnityEngine;

public class SlimeController : MonoBehaviour
{
    // ��˹���Ҥ�������㹡������͹�������ç���ⴴ� Inspector
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // �Ѻ����๹�� Animator ��� Rigidbody ���١����Ѻ GameObject ���
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. �������͹�����С�äǺ����͹����ѹ�Թ

        // �Ѻ��� input �ҡ���� A/D �����١�ë���/���
        float horizontalInput = Input.GetAxis("Horizontal");

        // �ѻവ���������� "Speed" � Animator
        // Mathf.Abs() ��������繺ǡ���� �����ҵ���Фè��Թ价ҧ�˹����
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // ���ҧ Vector3 ����Ѻ�������͹��� ������ input ������Ѻ
        // Time.deltaTime �����������͹����Һ������������Ѻ����÷�ͧ��
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // ����¹���˹觢ͧ GameObject �������͹���仵����ȷҧ���ӹǳ���
        transform.position += movement;

        // 2. ��á��ⴴ��С�äǺ����͹����ѹ���ⴴ

        // ��Ǩ�ͺ��Ҽ����蹡� Spacebar ��е���Ф����躹���
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ���¡ Trigger "Jump" � Animator ����������͹����ѹ���ⴴ
            animator.SetTrigger("Jump");

            // �� AddForce ���������ç���ⴴ㹷�ȷҧ���
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // ��駤�� isGrounded �� false ���ͻ�ͧ�ѹ��á��ⴴ��ҧ�ҡ��
            isGrounded = false;
        }
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // 3. ��õ�Ǩ�ͺ��ҵ���Ф����躹���

        // ��Ǩ�ͺ����ѵ�ط�誹�� Tag "Ground" �������
        // ����������� Tag "Ground" ���Ѻ�������ͧ�س
        if (collision.gameObject.CompareTag("Ground"))
        {
            // ��Ҫ��Ѻ��� ����駤�� isGrounded �� true �����������ö���ⴴ���ա����
            isGrounded = true;
        }
    }
}