using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoorPlay()
    {
        StartCoroutine(LaunchEmilyCoroutine());
    }
    IEnumerator LaunchEmilyCoroutine()
    {
        GetComponent<Animator>().SetBool("Drzwi", true);
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Play();
    }
}
