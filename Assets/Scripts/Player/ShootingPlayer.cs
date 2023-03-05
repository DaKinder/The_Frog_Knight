using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _bombPrefab;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(_bombPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }

    }
}
