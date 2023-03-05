using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    //private Vector3 offset = new Vector3(0, 11.0f, 0);

    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = new Vector3(player.transform.position.x, 15f, player.transform.position.z);
    }
}
