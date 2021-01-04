using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RocketController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float duration = 0.1f;
    [SerializeField] float magnitude = 5f;
    [SerializeField] float timeAfterCameZoomsOut = 1f;

    [SerializeField] CinemachineVirtualCamera zoomCamera;
    //public CameraShake cameraShake;

     [SerializeField] float boostSpeed = 0.1f;

    [SerializeField] float stageSerperationForce =20f;
     [SerializeField] Vector3 stageSeperationAngularVelocity = new Vector3(4f, -3f, 2.4f);

    bool hasLaunched = false;
    bool speedUp = false;

   

    float speed = 1.0f;
    
    int priority = -1;
    // Start is called before the first frame update
    void Start()
    {
        
      //speed = animator.GetFloat("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("s"))
        {
            hasLaunched = true;
            animator.SetBool("Start", true);
            
            transform.Find("Stage5").gameObject.transform.Find("Flame").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail1").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail2").gameObject.SetActive(true);
            
        }

        if(hasLaunched)
        {
            hasLaunched = false;
            priority *= -1;
            StartCoroutine(SetPriority());
            //speed = animator.GetFloat("Speed");
            SpeedUp();
            //speedUp = true;
            //zoomCamera.Priority = 1;
        }

     
    }

    private void SpeedUp()
    {
        speed += boostSpeed;
        animator.SetFloat("Speed", speed);
    }

    


    private IEnumerator SetPriority()
    {
        yield return new WaitForSeconds(timeAfterCameZoomsOut);
        if(priority > 0)
            zoomCamera.Priority = 1;

        else if(priority < 0)
            zoomCamera.Priority = 99;

    }

    public void SeperateStage6()
    {
        priority *= -1;
        StartCoroutine(SetPriority());
        CinemachineShake.Instance.ShakeCamera(magnitude, duration);
        GameObject stage6 = gameObject.transform.Find("6").gameObject;
        stage6.transform.Find("6").gameObject.transform.Find("Flame").gameObject.SetActive(false);
        stage6.transform.Find("Sphere").gameObject.transform.Find("Flame").gameObject.SetActive(false);
        stage6.transform.Find("Sphere1").gameObject.transform.Find("Flame").gameObject.SetActive(false);

        stage6.transform.parent = null;
        Rigidbody rb = stage6.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(stageSerperationForce * Vector3.right);
        rb.angularVelocity = stageSeperationAngularVelocity;
        //speed = animator.GetFloat("Speed");
        SpeedUp();
        
        GameObject stage5 = gameObject.transform.Find("Stage5").gameObject;
        stage5.transform.Find("Flame").gameObject.SetActive(true);
        stage5.transform.Find("Trail").gameObject.SetActive(true);
        Destroy(stage6, 2f);
    }

    public void SeperateStage5()
    {
        priority *= -1;
        StartCoroutine(SetPriority());
        CinemachineShake.Instance.ShakeCamera(magnitude, duration);
        GameObject stage5 = gameObject.transform.Find("Stage5").gameObject;
        stage5.transform.Find("Flame").gameObject.SetActive(false);

        stage5.transform.parent = null;
        Rigidbody rb = stage5.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(12f * stageSerperationForce * Vector3.right);
        rb.angularVelocity = 15 * stageSeperationAngularVelocity;
        //speed = animator.GetFloat("Speed");
        SpeedUp();
        
        GameObject stage4 = gameObject.transform.Find("Stage4").gameObject;
        stage4.transform.Find("Flame").gameObject.SetActive(true);
        stage4.transform.Find("Trail").gameObject.SetActive(true);
        Destroy(stage5, 2f);
    }

    public void SeperateStage4()
    {
        priority *= -1;
        StartCoroutine(SetPriority());
        CinemachineShake.Instance.ShakeCamera(magnitude, duration);
        GameObject stage4 = gameObject.transform.Find("Stage4").gameObject;
        stage4.transform.Find("Flame").gameObject.SetActive(false);

        stage4.transform.parent = null;
        Rigidbody rb = stage4.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(12f * stageSerperationForce * Vector3.right);
        rb.angularVelocity = 15 * stageSeperationAngularVelocity;
        //speed = animator.GetFloat("Speed");
        SpeedUp();
        
        GameObject stage3 = gameObject.transform.Find("Stage3").gameObject;
        stage3.transform.Find("Flame").gameObject.SetActive(true);
        stage3.transform.Find("Trail").gameObject.SetActive(true);
        Destroy(stage4, 2f);
    }

    public void SeperateStage3()
    {
        priority *= -1;
        StartCoroutine(SetPriority());
        CinemachineShake.Instance.ShakeCamera(magnitude, duration);
        GameObject stage3 = gameObject.transform.Find("Stage3").gameObject;
        stage3.transform.Find("Flame").gameObject.SetActive(false);

        stage3.transform.parent = null;
        Rigidbody rb = stage3.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(12f * stageSerperationForce * Vector3.right);
        rb.angularVelocity = 15 * stageSeperationAngularVelocity;
        //speed = animator.GetFloat("Speed");
        SpeedUp();
        
        GameObject stage2 = gameObject.transform.Find("Stage2").gameObject;
        stage2.transform.Find("Flame").gameObject.SetActive(true);
        stage2.transform.Find("Trail").gameObject.SetActive(true);
        Destroy(stage3, 2f);
    }
    
    public void SeperateStage2()
    {
        priority *= -1;
        StartCoroutine(SetPriority());
        CinemachineShake.Instance.ShakeCamera(magnitude, duration);
        GameObject stage2 = gameObject.transform.Find("Stage2").gameObject;
        stage2.transform.Find("Flame").gameObject.SetActive(false);

        stage2.transform.parent = null;
        Rigidbody rb = stage2.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(12f * stageSerperationForce * Vector3.right);
        rb.angularVelocity = 15 * stageSeperationAngularVelocity;
        //speed = animator.GetFloat("Speed");
        SpeedUp();
        
        GameObject stage1 = gameObject.transform.Find("Stage1").gameObject;
        stage1.transform.Find("Flame").gameObject.SetActive(true);
        stage1.transform.Find("Trail").gameObject.SetActive(true);
        Destroy(stage2, 2f);
    }

    
    
}
