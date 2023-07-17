using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_Movement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public GameObject character;

    public float speed;
    public float jumpPower;
    bool canJump;

    Vector3 leftRotation = new Vector3(0, 180, 0);
    Vector3 rightRotation = new Vector3(0, 0, 0);
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.D)|| (Input.GetKey(KeyCode.RightArrow) ))
        {
            RunRight();
            gameObject.transform.eulerAngles = rightRotation;

            if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
            {
                RightFalse();
            }
        }
        //else
        //{
        //    RightFalse();
        //}
        
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            RunLeft();
            gameObject.transform.eulerAngles = leftRotation;
        
            if(Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
            {
                LeftFalse();
            }       
        }
        //else
        //{
        //    LeftFalse();
        //}

        if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    #region Run
    /// <summary>
    /// Sa�a do�ru ko�u animasyonunu ba�latacak ve ard�ndan parametre de�erini de�i�tirir
    /// </summary>
    public void RunRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        anim.SetBool("run", true);
    }

    /// <summary>
    /// Sola do�ru ko�u animasyonunu ba�latacak ve ard�ndan parametre de�erini de�i�tirir
    /// </summary>
    public void RunLeft()
    {
        transform.Translate(Vector2.left * -speed * Time.deltaTime);
        anim.SetBool("run", true);
    }

    /// <summary>
    /// Sa�a do�ru ko�ma parametrelerini false yapar.
    /// </summary>
    public void RightFalse()
    {
        transform.Translate(Vector2.right * 0);
        anim.SetBool("run", false);
    }
    
    /// <summary>
    /// Sola do�ru ko�ma parametrelerini false yapar.
    /// </summary>
    public void LeftFalse()
    {
        transform.Translate(Vector2.left * 0);
        anim.SetBool("run", false);
    }

    #endregion

    #region Jump
    /// <summary>
    /// Z�plama i�levinin gerekliliklerini yapar
    /// </summary>
    public void Jump()
    {

        if (canJump)
        {
            Jumper();
            anim.SetBool("jump", true);
            StartCoroutine(JumpSetDefault());
        }
    }

    /// <summary>
    /// Z�plama tu�una bas�ld���nda kuvvet uygulamas� i�in.
    /// </summary>
    private void Jumper()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }
    
    /// <summary>
    /// Z�plama animasyonunun parametresini false yapar.
    /// </summary>
    /// <returns></returns>
    IEnumerator JumpSetDefault()
    {
        yield return new WaitForSeconds(1.16f);  // Animasyon bitimi i�in beklemesi gereken s�re
        anim.SetBool("jump", false);
    }
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("terrain"))
        {
            canJump = true;
            Debug.Log("Temas var");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("terrain"))
        {
            canJump = false;
        }
    }

    #endregion


}
