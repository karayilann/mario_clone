using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class die_Win : MonoBehaviour
{
    public GameObject character;
    public GameObject canvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene(0);  // Kazanýrsa þimdilik baaþtaan baþlayacak.
        }

        if (collision.gameObject.CompareTag("traps"))
        {
            // Tuzaklara çarpmasý durumunda sahne tekrar baþlayacak.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

}
