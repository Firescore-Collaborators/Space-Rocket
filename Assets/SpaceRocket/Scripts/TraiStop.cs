using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraiStop : MonoBehaviour
{
    [SerializeField] Animator animator;

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Fill"))
        {
            animator.SetBool("Fill", false);

        }

    }
}
