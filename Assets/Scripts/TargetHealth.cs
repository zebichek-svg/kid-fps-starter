using UnityEngine;

public class TargetHealth : MonoBehaviour
{
    [Header("Target Settings")]
    public int points = 10;
    public float maxHealth = 50f;
    public float respawnDelay = 1.5f;
    public float moveRadius = 3f;

    private float currentHealth;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool active = true;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (!active)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        active = false;

        if (GameManager.instance != null)
        {
            GameManager.instance.AddScore(points);
        }

        StartCoroutine(RespawnRoutine());
    }

    private System.Collections.IEnumerator RespawnRoutine()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);

        Vector3 randomOffset = new Vector3(
            Random.Range(-moveRadius, moveRadius),
            Random.Range(-0.5f, 1.5f),
            Random.Range(-moveRadius, moveRadius)
        );

        transform.position = originalPosition + randomOffset;
        transform.rotation = originalRotation;
        currentHealth = maxHealth;
        active = true;
        gameObject.SetActive(true);
    }
}
