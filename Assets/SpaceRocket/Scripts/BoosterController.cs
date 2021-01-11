using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BoosterController : MonoBehaviour
{
    [SerializeField] Animator animator;

     Animator[] panelAnimators;

     Animator[] standAnimators;


    [SerializeField] float duration = 0.1f;
    [SerializeField] float magnitude = 5f;
    [SerializeField] float timeAfterCameZoomsOut = 1f;

    [SerializeField] CinemachineVirtualCamera zoomCamera;
    //public CameraShake cameraShake;

     [SerializeField] float boostSpeed = 0.1f;

    [SerializeField] float stageSerperationForce =20f;
     [SerializeField] Vector3 stageSeperationAngularVelocity = new Vector3(4f, -3f, 2.4f);

    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject leftButton;

    bool hasLaunched = false;
    bool speedUp = false;

   

    float speed = 1.0f;
    
    int priority = -1;

    ParticleSystem rightNitrogenDischarge;

    ParticleSystem leftNitrogenDischarge;

    ParticleSystem flames;

    PushButton right;
    PushButton left;
    // Start is called before the first frame update
    void Start()
    {
        //panelAnimators = new Animator[4];
        panelAnimators = transform.Find("Stage2").
        gameObject.transform.Find("Solar Panels").
        gameObject.GetComponentsInChildren<Animator>();

        standAnimators = transform.Find("Stands").
        gameObject.GetComponentsInChildren<Animator>();

        rightNitrogenDischarge = transform.Find("Stage2").
        gameObject.transform.Find("SmokeR").
        gameObject.GetComponent<ParticleSystem>();

        leftNitrogenDischarge = transform.Find("Stage2").
        gameObject.transform.Find("SmokeL").
        gameObject.GetComponent<ParticleSystem>();

        flames = transform.Find("Stage2").
        gameObject.transform.Find("Flame2").
        gameObject.GetComponent<ParticleSystem>();

        right = rightButton.GetComponent<PushButton>();
        left = leftButton.GetComponent<PushButton>();
      //speed = animator.GetFloat("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("s"))
        {
            hasLaunched = true;
            animator.SetBool("Start", true);
            
            /*transform.Find("Stage5").gameObject.transform.Find("Flame").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail1").gameObject.SetActive(true);
            transform.Find("Stage5").gameObject.transform.Find("Trail2").gameObject.SetActive(true);
            */
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

    public void SpeedUp()
    {
        speed -= boostSpeed;
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

   
    
    public void SeperateStage1()
    {
        priority *= -1;
        StartCoroutine(SetPriority());
        CinemachineShake.Instance.ShakeCamera(magnitude, duration);
        GameObject stage1 = transform.Find("Stage1").gameObject;
//        stage1.transform.Find("Flame").gameObject.SetActive(false);

        stage1.transform.parent = null;
        Rigidbody rb = stage1.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(12f * stageSerperationForce * Vector3.right);
        rb.angularVelocity = 15 * stageSeperationAngularVelocity;
        //speed = animator.GetFloat("Speed");
        SpeedUp();
        
        /*GameObject stage1 = gameObject.transform.Find("Stage1").gameObject;
        stage1.transform.Find("Flame").gameObject.SetActive(true);
        stage1.transform.Find("Trail").gameObject.SetActive(true);*/
        Destroy(stage1, 2f);
    }

    public void OpenPanels()
    {
       // panelAnimator.SetBool("UnFold", true);
       foreach(Animator animator in panelAnimators)
       {
           animator.SetBool("UnFold", true);
       }
    }

    public void OpenStands()
    {
        foreach(Animator animator in standAnimators)
       {
           animator.SetBool("UnFold", true);
       }
    }

    public void RightNitrogenDischarge()
    {
        right.Push();

        rightNitrogenDischarge.gameObject.SetActive(true);
        rightNitrogenDischarge.Clear();
        rightNitrogenDischarge.Play();

        
    }

    public void LefttNitrogenDischarge()
    {
        left.Push();
        leftNitrogenDischarge.gameObject.SetActive(true);
        leftNitrogenDischarge.Clear();
        leftNitrogenDischarge.Play();

        
    }

    public void FlameOn()
    {
        flames.gameObject.SetActive(true);
        flames.Clear();
        flames.Play();
    }

    public void GravFlamesOn()
    {
        transform.Find("Stage2").
        gameObject.transform.Find("Grav Flames").
        gameObject.SetActive(true);
    }

    public void GravFlamesOff()
    {
        transform.Find("Stage2").
        gameObject.transform.Find("Grav Flames").
        gameObject.SetActive(false);
    }

    public void GravFlamesSlowDown()
    {
        ParticleSystem flame1 = transform.Find("Stage2").
        gameObject.transform.Find("Grav Flames").
        gameObject.transform.Find("Flame1").
        gameObject.GetComponent<ParticleSystem>();

        flame1.enableEmission = false;   /// directly turns off emission in the particle editor
        var yourParticleEmission1 = flame1.emission;
        

        ParticleSystem flame = transform.Find("Stage2").
        gameObject.transform.Find("Grav Flames").
        gameObject.transform.Find("Flame").
        gameObject.GetComponent<ParticleSystem>();

        flame.enableEmission = false;
        var yourParticleEmission = flame.emission;

        yourParticleEmission1.enabled = true;
        yourParticleEmission1.rateOverTime = 20;

        yourParticleEmission.enabled = true;
        yourParticleEmission.rateOverTime = 20;
    }

    public  void ActivateSmoke()
    {
        transform.Find("Stage2").
        gameObject.transform.Find("Trail").
        gameObject.SetActive(true);
    }
}
