using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _bombSpeed = 1f;
    [SerializeField] private float _bombDamage = 80f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _bombSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ThrowBomb(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        ThrowBomb(other.gameObject);
    }

    private void ThrowBomb(GameObject collision)
    {
        if (collision.TryGetComponent(out HealthManager health))
        {
            health.TakeDamage(_bombDamage);
            Destroy(gameObject);
        }
    }
}
