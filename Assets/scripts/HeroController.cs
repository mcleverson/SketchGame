using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    public float jumpForce = 30f;

    Animator HeroAnimator;
    Rigidbody HeroRB;
    bool IsOnGround;


    // Start is called before the first frame update
    void Start()
    {
        HeroAnimator = GetComponent<Animator>();
        HeroRB = GetComponent<Rigidbody>();
        IsOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);


        if ( Input.GetKeyDown(KeyCode.Space) && IsOnGround )
        {
            HeroAnimator.SetTrigger("Jump_Trig");
            HeroAnimator.SetBool("Jumping", true);
            HeroRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
        else
        {
            HeroAnimator.SetBool("walking", isWalking && IsOnGround);
            HeroAnimator.SetBool("Jumping", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        IsOnGround = collision.gameObject.CompareTag("Ground");
        HeroAnimator.SetBool("walking", IsOnGround);
    }
}
