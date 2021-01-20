using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    [SerializeField] Material[] materials;

    [SerializeField] GameObject meter;

    public void ActivateGlowEffect()
    {
        foreach(Material mat in materials)
        {
            mat.EnableKeyword("_EMISSION");
        }
    }

    public void DeactivateGlowEffect()
    {
        foreach (Material mat in materials)
        {
            mat.DisableKeyword("_EMISSION");
        }
    }

    public IEnumerator MeterDisappear()
    {
        yield return new WaitForSeconds(0.5f);
        meter.SetActive(false);
    }
}
