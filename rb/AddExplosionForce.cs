using UnityEngine;

namespace rb
internal class AddExplosionForce : Bomb
{
    public float _radius = 2.0F;
    public float _power = 10.0F;

    void Start()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(_power, explosionPosition, _radius, 3.0F);
            }
                
        }
    }
}
