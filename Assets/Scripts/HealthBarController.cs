using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float damageAmount = 10f;

    [Header("UI References")]
    public Image healthBarFill;

    void Start()
    {
        // ��˹���������������آ�Ҿ
        currentHealth = maxHealth;

        // �Ѿഷ Health Bar �������
        UpdateHealthBar();
    }

    void OnCollisionEnter(Collision collision)
    {
        // ��Ǩ�ͺ��Ҫ��Ѻ�ѵ�ط���� tag "Dangerous"
        if (collision.gameObject.CompareTag("Dangerous"))
        {
            TakeDamage(damageAmount);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ��Ǩ�ͺ��Ҫ��Ѻ�ѵ�ط���� tag "Dangerous" (����Ѻ Trigger Collider)
        if (other.CompareTag("Dangerous"))
        {
            TakeDamage(damageAmount);
        }
    }

    void TakeDamage(float damage)
    {
        // Ŵ�آ�Ҿ
        currentHealth -= damage;

        // ��Ǩ�ͺ�������آ�Ҿ��ӡ��� 0
        currentHealth = Mathf.Max(0, currentHealth);

        // �Ѿഷ Health Bar
        UpdateHealthBar();

        // ��Ǩ�ͺ����آ�Ҿ�� 0 �������
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // �Ѿഷ Fill Amount �ͧ Image
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        // ����� Player ���ͨѴ���������آ�Ҿ�� 0
        Debug.Log("Player died!");
        // Destroy(gameObject);
    }
}