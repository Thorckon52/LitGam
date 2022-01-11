using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverWeaponSc : MonoBehaviour
{
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0,0.1f,0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(velocity);
    }
}
