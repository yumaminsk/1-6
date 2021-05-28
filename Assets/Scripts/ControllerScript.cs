using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float rotationSpeed = 0.2f;
    public float animationBlendSpeed= 0.2f;
    public float sprintSpeed = 7.0f;
    public float jumpSpeed = 7.0f;

    CharacterController controller;
    Camera characterCamera;
    Animator animator;
    private float rotationAngle = 0.0f;
    private bool isSpirit = false;
    private float targetAnimationSpeed = 0.0f;
    private int switchNum = 0;
    private float speedY = 0.0f;
    private float gravity = -9.81f;
    private bool isJumping = false;
    private bool isSpawn = true;
    private bool isDeath = false;
    private bool isDamage = false;

    public GameObject bulletposition;


    public CharacterController Controller
    {
        get { return controller = controller ?? GetComponent<CharacterController>(); }
    }
    public Camera CharacterCamera
    {
        get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); }
    }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }
    void Start()
    {
        spawnStart();
    }
    void Update()
    {
        
        if (isSpawn == false && isDeath == false && isDamage == false)
        {
            //Damage();
            Death();
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            isSpirit = Input.GetKey(KeyCode.LeftShift);
            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
            Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;
            Jump();
            float currentSpeed = isSpirit ? sprintSpeed : movementSpeed;
            Controller.Move((verticalMovement + rotatedMovement * currentSpeed) * Time.deltaTime);

            if (rotatedMovement.sqrMagnitude > 0.0f)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSpirit ? 1.0f : 0.5f;
            }
            else
            {
                targetAnimationSpeed = 0.0f;
            }
            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Fire();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                BulletManager.Instance.SwitchType();
            }
        }
    }

    private void Death()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("Death", true);
        }
    }
    void DeathBegin()
    {
        isDeath = true;
        print(isDeath);
    }
    void DeathEnd()
    {
        isDeath = false;
        print(isDeath);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            CharacterAnimator.SetTrigger("Jump");
            speedY += jumpSpeed;
        }
        if (!Controller.isGrounded)
        {
            speedY += gravity * Time.deltaTime;
        }
        else if (speedY < 0.0f)
        {
            speedY = 0.0f;
        }
        CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
        if (isJumping && speedY < 0.0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Default")))
            {
                isJumping = false;
                CharacterAnimator.SetTrigger("Land");
            }
        }
    }
    void spawnStart()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        CharacterAnimator.SetTrigger("Spawn");
        yield return new WaitForSeconds(2);
        isSpawn = false; 
    }
    void Fire()
    {
        GameObject bullet = BulletManager.Instance.GetBullet();
        Rigidbody b_rigidbody = bullet.GetComponent<Rigidbody>();
        Debug.Log(bullet.name);
        bullet.SetActive(true);
        b_rigidbody.velocity = new Vector3(0, 0, 0);
        bullet.transform.position = bulletposition.transform.position;
        bullet.transform.rotation = bulletposition.transform.rotation;
        b_rigidbody.AddForce(bullet.transform.forward * 100f);
    }


  /*  void Damage()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            animator.SetTrigger("Dam");
            animator.SetInteger("Damage", UnityEngine.Random.Range(1, 4));
        }
    }
    void DamageBegin()
    {
        isDamage = true;
        print(isDamage);
    }
    void DamageEnd()
    {
        isDamage = false;
        print(isDamage);
    }*/
}

