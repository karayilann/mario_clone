using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class character_controller : MonoBehaviour
{

        // Oyunu en ba��nda android i�in tasarlad���mda yazd���m kodlar.

    Animator anim;
    Rigidbody2D rb;
    public GameObject character;

    public float speed;
    public float jumpPower;
    public bool isRunRight = false;
    bool canJump = false;
    public bool isRunLeft = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    #region Jump 

    /// <summary>
    /// Z�plama animasyonunu yapar
    /// </summary>
    public void Jump()
    {
        anim.SetBool("jump", true);
        StartCoroutine(JumpSetDefault());
        if (canJump)
        {
            Jumper();
        }
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
    #endregion

    #region Run

    /// <summary>
    /// Sa�a do�ru ko�u animasyonunu ba�latacak ve ard�ndan parametre de�erini de�i�tirir
    /// </summary>
    public void RunRight()
    {
        isRunRight = true;
        if (isRunRight)
        {
            anim.SetBool("run", true);    
        }
    }

    public void RunLeft()
    {
        isRunLeft = true;
        if (isRunLeft)
        {
            anim.SetBool("run", true);
        }
    }

    private void FixedUpdate()
    {
        float YatayHareket = Input.GetAxisRaw("Horizontal");
        float DikeyHareket = Input.GetAxisRaw("Vertical");

        if (YatayHareket > 0)
        {
            RunRight();
        }

        if (isRunRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (isRunLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Sa�a do�ru ko�ma parametrelerini false yapar.
    /// </summary>
    public void RightFalse()
    {
        isRunRight = false;
        anim.SetBool("run", false);
    }
    
    /// <summary>
    /// Sola do�ru ko�ma parametrelerini false yapar.
    /// </summary>
    public void LeftFalse()
    {
        isRunLeft = false;
        anim.SetBool("run", false);
    }

    #endregion

}
