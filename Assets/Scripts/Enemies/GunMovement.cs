using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        Quaternion.LookRotation(Vector3.forward);
    }
    private void Update()
    {
       LookAtPlayer();
    }
    private void LookAtPlayer()
    {
        var direction = player.transform.position - transform.position;
        direction = new Vector3(direction.x, direction.y, direction.z);
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
