using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public Vector3 scene;

    void Start()
    {
        scene = new Vector3(1f, 1f, 1f);
    }
    
    void Update()
    {
        transform.Translate(Vector3.down * 1 * Time.deltaTime);
    }
}
