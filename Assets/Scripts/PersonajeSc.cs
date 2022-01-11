using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeSc : MonoBehaviour
{
    //Generales
    [SerializeField] private Transform cam;
    public LayerMask QueDisparamos;
    [SerializeField] private GameObject [] armasGO;
    [SerializeField] private GameObject [] armasEscogerGO;
    [SerializeField] private AudioClip sonidoCargarArmaAC;
    [SerializeField] private AudioClip [] sonidoArmaAC;
    public ArmaSc miArmaSc;
    private AudioSource sonidoAS;
    private int i = 0;
    private int numArma = -1;
    
    //DisparoParabolico
    [SerializeField] private GameObject balaPf;
    [SerializeField] private GameObject contenedorBalasGO;
    [SerializeField] private Transform posDisparoTf;
    int contadorBalas = 0;

    //Campo de fuerza
    [SerializeField] private GameObject objetoAtrayenteGO;
    bool campoActivo;
   
    //DisparoEmpuje
    void Start()
    {
        campoActivo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(numArma == 0)
            {
                DisparoParabolico();
            }
            else if(numArma == 1)
            {
                campoActivo = true;
                DisparoCampoFuerza();
            }
            else if(numArma == 2)
            {
                DisparoEmpuje();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(numArma == 1)
            {
                campoActivo = false;
                DisparoCampoFuerza();
            }
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Weapon")
        {
            if(other.gameObject.name == armasEscogerGO[0].name)
            {
                numArma = 0;
            }
            else if(other.gameObject.name == armasEscogerGO[1].name)
            {
                numArma = 1;
            }
            else if(other.gameObject.name == armasEscogerGO[2].name)
            {
                numArma = 2;
            }
            MostrarArmas(numArma);
        }
    }
    void MostrarArmas(int num)
    {
        for(i=0;i<armasGO.Length;i++)
        {
            if(i == num)
            {
                armasGO[i].SetActive(true);
                armasEscogerGO[i].SetActive(false);
                miArmaSc = GetComponent<ArmaSc>();
                miArmaSc.datosArmas = armasGO[i].GetComponent<ArmaSc>().datosArmas;
            }
            else
            {
                armasGO[i].SetActive(false);
                armasEscogerGO[i].SetActive(true);
            }
        }
        sonidoAS = armasGO[num].GetComponent<AudioSource>();
        sonidoAS.clip = sonidoCargarArmaAC;
        sonidoAS.Play();
    }
    void DisparoParabolico()
    {
        GameObject bala = Instantiate(balaPf,posDisparoTf);
        bala.name = "Bala_"+ contadorBalas;
        bala.GetComponent<Rigidbody>().AddForce(cam.transform.forward * miArmaSc.datosArmas.Fuerza);
        bala.transform.parent = contenedorBalasGO.transform;
        contadorBalas++;
        if(contadorBalas>10)
        {
            Destroy(GameObject.Find("Bala_"+(contadorBalas-11)));
        }

        sonidoAS.clip = sonidoArmaAC[0];
        sonidoAS.Play();
    }
    void DisparoCampoFuerza()
    {
        sonidoAS.clip = sonidoArmaAC[1];
        if(campoActivo)
        {
            objetoAtrayenteGO.SetActive(true);
            sonidoAS.Play();
        }
        else
        {
            objetoAtrayenteGO.SetActive(false);
            sonidoAS.Stop();
        }
    }
    void DisparoEmpuje()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, Mathf.Infinity, QueDisparamos))
        {
            if(hit.collider.tag == "Objeto")
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(cam.transform.forward * miArmaSc.datosArmas.Fuerza);
            }
        }
        sonidoAS.clip = sonidoArmaAC[2];
        sonidoAS.Play();
    }
}
