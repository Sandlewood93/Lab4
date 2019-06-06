using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Rigidbody2D rb;
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    Animator anim;
    public bool isFacingLeft;
    public int holyAmo;
    public GameObject bomb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        


    }
   
    // Update is called once per frame
    private void Update()
    {
        float moveValue = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,
            groundCheckRadius, isGroundLayer);

        if (isGrounded) {
            anim.SetBool("isJump", false);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("isJump", true);
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);
        anim.SetFloat("moveValue", Mathf.Abs(moveValue));

        if((isFacingLeft && moveValue < 0) || (!isFacingLeft && moveValue > 0))
        {
            flip();
        }

        if (Input.GetKey(KeyCode.DownArrow)&& isGrounded)
        {
            anim.SetBool("isDown", true);
        }
        else
        {
            anim.SetBool("isDown", false);
        }

        if (Input.GetButtonDown("Fire1")) 
            {
            anim.SetBool("Attacked", true);
         
        }
        else
        {
            anim.SetBool("Attacked", false);
        }
        
        if (Input.GetButtonDown("Fire2") && holyAmo >= 1)
        {
            HolyWater();
        }


        
    }

    void HolyWater(){

        GameObject temp = Instantiate(bomb, groundCheck.position, groundCheck.rotation);
        holyAmo--;


    }


    void flip()
    {
       isFacingLeft = !isFacingLeft;
      Vector3 scaleFactor = transform.localScale;
       scaleFactor.x *= -1;
        transform.localScale = scaleFactor;


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Holy")
        {
            holyAmo++;
            Destroy(other.gameObject);
        }
    }


}
