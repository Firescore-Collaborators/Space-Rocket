using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetPriority(int priority)
    {
        GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }
}
