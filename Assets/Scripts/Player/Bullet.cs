using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10000f;
    [SerializeField] private float _shootDamage = 10f;

    private Rigidbody rb;

    private string targetTag;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        rb.AddTorque(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
    public void Init(string targetTag)
    {
        this.targetTag = targetTag;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Shoot(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Shoot(other.gameObject);
    }

    private void Shoot(GameObject collision)
    {
        if(collision.TryGetComponent(out HealthManager health))
        {
            health.TakeDamage(_shootDamage);
        }
        Destroy(gameObject);
    }

    
}
