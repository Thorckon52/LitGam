using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosSc : MonoBehaviour
{
    [SerializeField] GameObject objetoAtraccionGO;
    public ArmaSc datosSc;
    float distancia;
    public bool activo;

    void Update()
    {
        activo = objetoAtraccionGO.activeSelf;
        if(activo)
        {
            distancia = Vector3.Distance(objetoAtraccionGO.transform.position,transform.position);
            if(distancia < datosSc.datosArmas.Area)
            {
                gameObject.GetComponent<Rigidbody>().AddForce((objetoAtraccionGO.transform.position-transform.position)*datosSc.datosArmas.Fuerza);
            }
        }
    }
}
