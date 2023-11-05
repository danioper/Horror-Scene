using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject prop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        player.transform.position = prop.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
