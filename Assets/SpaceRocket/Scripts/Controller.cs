using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   
    [SerializeField] Animator animator;

    Renderer meshRenderer;

    [SerializeField] Animator leftTrailAnimator;
    [SerializeField] Animator rightTrailAnimator;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Left"))
        {
            animator.SetBool("Left", false);
            
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Right"))
        {
            animator.SetBool("Right", false);
           
        }

        
    }

    public void Left()
    {
        gameObject.SetActive(true);
        animator.SetBool("Left", true);
        StartCoroutine(Disable());
        rightTrailAnimator.SetBool("Fill", true);
    }

    public void Right()
    {
        gameObject.SetActive(true);
        animator.SetBool("Right", true);
        StartCoroutine(Disable());
        leftTrailAnimator.SetBool("Fill", true);
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(1.22f);
        gameObject.SetActive(false);
    }
}
