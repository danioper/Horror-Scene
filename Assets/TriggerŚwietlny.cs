using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TriggerŚwietlny : MonoBehaviour
{
    PostProcessVolume volume;
    AutoExposure AE;
    Vignette vignette;
    public static TriggerŚwietlny instance;

    void Awake()
    {
        instance = this;
    }

    [Button]

    public void ShockThePlayer()
    {
        StartCoroutine(ShockThePlayerCoroutine());
    }

    IEnumerator ShockThePlayerCoroutine()
    {
        SetVolumeEnabledAndInvisible();
        yield return TransitVignetIntensityToOne(0.3f);
        yield return ContrastToLowest(0.1f);
        yield return BackToNeutral(0.3f);
        SetVolumeDisabled();

    }

    void SetVolumeEnabledAndInvisible()
    {
        if (volume == null) volume = GetComponent<PostProcessVolume>();
        volume.enabled = true;
        volume.profile.TryGetSettings(out AE);
        AE.enabled.value = true;
        volume.profile.TryGetSettings(out vignette);
        vignette.enabled.value = true;
        AE.maxLuminance.value = -3f;
    }

    IEnumerator TransitVignetIntensityToOne(float duration)
    {
        while (vignette.intensity < 1)
        {
            vignette.intensity.value += Time.deltaTime / duration;
            vignette.smoothness.value += Time.deltaTime / duration;
            //colorGrading.contrast.value += Time.deltaTime * 100f / duration;
            yield return null;
        }
    }

    IEnumerator ContrastToLowest(float duration)
    {
                  yield return null;

    }

    IEnumerator BackToNeutral(float duration)
    {
        vignette.intensity.value = 0;
        vignette.smoothness.value = 0.2f;
        yield return null;
    }

    void SetVolumeDisabled()
    {
        volume.enabled = false;
    }
}
