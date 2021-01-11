using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{

    [SerializeField] Color notPressedColor;
    [SerializeField] Color pressedColor;
    [SerializeField] Animator animator;

    Renderer meshRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Push"))
        {
            animator.SetBool("Push", false);
            meshRenderer.material.SetColor("_BaseColor", notPressedColor);
        }
    }

    public void Push()
    {
        meshRenderer.material.SetColor("_BaseColor", pressedColor);
        animator.SetBool("Push", true);
    }
}
