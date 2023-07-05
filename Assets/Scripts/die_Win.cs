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
            SceneManager.LoadScene(0);  // Kazan�rsa �imdilik baa�taan ba�layacak.
        }

        if (collision.gameObject.CompareTag("traps"))
        {
            // Tuzaklara �arpmas� durumunda sahne tekrar ba�layacak.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

}
