using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RocketController : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] Animator rocketStandAnimator;

    [SerializeField] GameObject boosterFlame;

    [SerializeField] GameObject boosterFlame1;
    [SerializeField] float duration = 0.1f;
    [SerializeField] float magnitude = 5f;
    [SerializeField] float timeAfterCameZoomsOut = 1f;

    [SerializeField] CinemachineVirtualCamera zoomCamera;
    [SerializeField] CinemachineVirtualCamera teslaCam;
    //public CameraShake cameraShake;

    [SerializeField] float boostSpeed = 0.1f;

    [SerializeField] float stageSerperationForce =20f;
    [SerializeField] Vector3 stageSeperationAngularVelocity = new Vector3(4f, -3f, 2.4f);
    [SerializeField] float finalStageSeperatioforce = 10f;

    [SerializeField] float teslaForce = 5f;

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
            rocketStandAnimator.SetBool("Detach", true);

            StartCoroutine(LaunchRocket());
           
            
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

    private IEnumerator LaunchRocket()
    {
            yield return new WaitForSeconds(0.6f);

            hasLaunched = true;
            animator.SetBool("Start", true);
            
            transform.Find("Stage5").gameObject.transform.Find("Flame").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail1").gameObject.SetActive(true);

            boosterFlame.SetActive(true);
            boosterFlame1.SetActive(true);
           // transform.Find("Stage5").gameObject.transform.Find("Trail2").gameObject.SetActive(true);
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

    public void ActivateTeslaProtocol()
    {
        Debug.Log("Tesla Protocol Started");

       /* GameObject stage1 = gameObject.transform.Find("Stage1").gameObject;
        stage1.transform.parent = null;
        Rigidbody rb = stage1.GetComponent<Rigidbody>();
        rb.isKinematic = false;*/


        GameObject head1 = gameObject.transform.Find("Stage1").gameObject.
        transform.Find("Head1").gameObject;

        GameObject head2 = gameObject.transform.Find("Stage1").gameObject.
        transform.Find("Head2").gameObject;

        GameObject tesla = gameObject.transform.Find("Stage1").gameObject.
            transform.Find("Tesla").gameObject;

        GameObject baase = gameObject.transform.Find("Stage1").gameObject.
        transform.Find("Base").gameObject;

        baase.GetComponent<Rigidbody>().isKinematic = false;

        Destroy(gameObject.transform.Find("Stage1").gameObject.
        transform.Find("Flame").gameObject);

        baase.transform.parent = null;
        baase.GetComponent<Rigidbody>().isKinematic = false;



        Rigidbody head1Rigidbody = head1.GetComponent<Rigidbody>();
        Rigidbody head2Rigidbody = head2.GetComponent<Rigidbody>();
        Rigidbody teslaRigidbody = tesla.GetComponent<Rigidbody>();

        head1.transform.parent = null;
        head2.transform.parent = null;
        tesla.transform.parent = null;

        head1Rigidbody.isKinematic = false;
        head2Rigidbody.isKinematic = false;
        teslaRigidbody.isKinematic = false;


        head1Rigidbody.AddRelativeForce(finalStageSeperatioforce * transform.right);
        head2Rigidbody.AddRelativeForce(-finalStageSeperatioforce * transform.right);
        teslaRigidbody.AddRelativeForce(teslaForce * Vector3.forward);

        ChangeToTeslaCam();

        StartCoroutine(StopTeslaCameraFollow());
        //head1Rigidbody.AddForce(finalStageSeperatioforce * -transform.right);


        //StartCoroutine(LaunchTesla(tesla));

        Debug.Log("Tesla Protocol End");
    }

    private IEnumerator StopTeslaCameraFollow()
    {
        yield return new WaitForSeconds(3f);
        teslaCam.Follow = null;
    }

    private void ChangeToTeslaCam()
    {

        teslaCam.Priority = 100;
    }

    /*private IEnumerator LaunchTesla(GameObject tesla)
    {
        yield return new WaitForSeconds(1.5f);
        
       
        

        
    }*/

    public void SeperateBoosters()
    {
       
        CinemachineShake.Instance.ShakeCamera(magnitude, duration);
        GameObject booster = gameObject.transform.Find("Booster").gameObject;
        boosterFlame.SetActive(false);

        GameObject booster1 = gameObject.transform.Find("Booster1").gameObject;
        boosterFlame1.SetActive(false);

        booster.transform.parent = null;
        Rigidbody rb = booster.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(5 * stageSerperationForce * Vector3.right);
        rb.angularVelocity = stageSeperationAngularVelocity;

        booster1.transform.parent = null;
        Rigidbody rb1 = booster.GetComponent<Rigidbody>();
        rb1.isKinematic = false;
        rb1.AddForce(-5 * stageSerperationForce * Vector3.right);
        rb1.angularVelocity = stageSeperationAngularVelocity;
        //speed = animator.GetFloat("Speed");
       // SpeedUp();
        
        
        Destroy(booster, 2f);
       Destroy(booster1, 2f); 
    }
    
    
}
