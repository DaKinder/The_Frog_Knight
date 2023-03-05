using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    public GameObject player;
    private AudioListener listener;

    void Start()
    {
        player = GameObject.Find("Player");
        listener = player.GetComponent<AudioListener>();

        //GameObject.Find("Directional Light").GetComponent<Transform>();

        Debug.Log(listener.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
