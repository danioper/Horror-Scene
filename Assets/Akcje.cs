using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class Akcje : MonoBehaviour
{
    int index;
    [SerializeField] Animator drzwiAnim;
    [SerializeField] AudioSource drzwiaudio;
    [SerializeField] AudioSource obrazsound;
    [SerializeField] AudioSource lampaSound1;
    [SerializeField] AudioSource lampaSound2;
    [SerializeField] AudioSource lampaSound3;
    [SerializeField] AudioSource lampaSound4;
    [SerializeField] AudioSource happy;
    [SerializeField] GameObject obrazDuzy;
    [SerializeField] GameObject vodo1;
    [SerializeField] GameObject vodo2;
    [SerializeField] GameObject lampa1;
    [SerializeField] GameObject lampa2;
    [SerializeField] GameObject lampa3;
    [SerializeField] Animator lalkaTrigger;
    [SerializeField] AudioSource Ambient;

    [SerializeField] PostProcessVolume volume;
    AutoExposure AE;
    Vignette V;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (index) {
                case 0:
                    obrazsound.Play();
                    index++;
                    break;
                case 1:
                    StartCoroutine(DrzwiCoroutine());
                    index++;
                    break;
                case 2:
                    obrazDuzy.SetActive(true);
                    index++;
                    break;
                case 3:
                    happy.Play();
                    index++;
                    break;
                case 4:
                    vodo1.SetActive(true);
                    lampaSound1.Play();
                    StartCoroutine(pockoj());
                    //lampa1.SetActive(false);
                    index++;
                    break;
                case 5:
                    vodo2.SetActive(true);
                    lampaSound2.Play();
                    StartCoroutine(pockoj());
                    lampa2.SetActive(false);
                    index++;
                    break;
                case 6:
                    vodo2.SetActive(false);
                    lampaSound3.Play();
                    StartCoroutine(pockoj());
                    lampa3.SetActive(false);
                    index++;
                    volume.profile.TryGetSettings(out AE);
                    AE.enabled.value = true;
                    AE.maxLuminance.value = 5;
                    AE.minLuminance.value = 10;
                    Ambient.Stop();
                    break;
                case 7:
                    lalkaTrigger.SetTrigger("LalkaTrigger");
                    lampaSound4.Play();
                    volume.profile.TryGetSettings(out V);
                    V.enabled.value = true;
                    break;
            }
        }    
    }
    IEnumerator DrzwiCoroutine()
    {
        drzwiAnim.SetBool("Drzwi", true);
        yield return new WaitForSeconds(0.8f);
        drzwiaudio.Play();
    }
    IEnumerator pockoj()
    {
        UnityEngine.Debug.Log("Dupa");
        yield return new WaitForSeconds(0.5f);
    }
}
