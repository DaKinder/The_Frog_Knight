using UnityEngine;
using System.Collections;
public class ShootingEnemy : Enemy
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnStep = 1f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float shootDistance = 1f;

    private Transform player;
    private float nextSpawnTime;
    private int playerLayerMask;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        playerLayerMask = 1 << player.gameObject.layer;
    }

    private void Update()
    {
        LookAtPlayer();
    }

    private void OnEnable()
    {
        StartCoroutine(ShootRepeat());
    }

    private IEnumerator ShootRepeat()
    {
        while (enabled)
        {
            Shoot();
            yield return new WaitForSeconds(spawnStep);
        }
        yield return null;
    }

    private void Shoot()
    {
        //Debug.DrawRay(transform.position, spawnPoint.forward, Color.green, shootDistance);
        if (Physics.Raycast(transform.position, spawnPoint.forward, out var hit, shootDistance, playerLayerMask))
        {
            var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.Init(player.tag);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, spawnPoint.forward);
    }
    private void OnDisable()
    {
        StopCoroutine(ShootRepeat());
    }
    
    private void LookAtPlayer()
    {
        Vector3 targetDirection = player.position - transform.position;
        targetDirection = new Vector3(targetDirection.x, 0, targetDirection.z);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}