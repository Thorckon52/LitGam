using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenedorBalasSc : MonoBehaviour
{
    public GameObject [] balas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(balas.Length > 10)
        {
            Destroy(balas[0]);
            for(int i=1;i<balas.Length;i++)
            {
                balas[i-1] = balas[i];
            }
        }
    }
}
