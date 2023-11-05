using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwiatlo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Darkener.instance.ShockThePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
