using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_slide : MonoBehaviour
{
    public List<GameObject> backgrounds;
    public int countOfBacks;
    float backLastPos;

    void Start()
    {
        for (int i = 0; i < countOfBacks; i++)
        {
            int newid = 1;
            int RandomBack = Random.Range(0, backgrounds.Count);
            GameObject newBackground = Instantiate(backgrounds[RandomBack]);

            if(newid == 0)
            {
                newBackground.transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                newBackground.transform.position = new Vector3(backLastPos + 20.98f, 0, 0);
            }

            backLastPos = newBackground.transform.position.x;
        }
        

    }

}
