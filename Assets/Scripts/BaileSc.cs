using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaileSc : MonoBehaviour
{
    /*Music (AudioClips):
        0 -> Ambiental
        1 -> HipHop
        2 -> House
        3 -> Macarena
    */
    [SerializeField] AudioClip [] musicaAC;
    Animator animatorController;
    AudioSource musicaAS;
    void Start()
    {
        animatorController = GetComponent<Animator>();
        musicaAS = GetComponent<AudioSource>();

        musicaAS.clip = musicaAC[0];
        musicaAS.Play();
    }
    
    public void GoHipHop()
    {
        animatorController.SetTrigger("HipHopDancing");
        musicaAS.clip = musicaAC[1];
        musicaAS.Play();
    }
    public void GoHouse()
    {
        animatorController.SetTrigger("HouseDancing");
        musicaAS.clip = musicaAC[2];
        musicaAS.Play();
    }
    public void GoMacarena()
    {
        animatorController.SetTrigger("MacarenaDancing");
        musicaAS.clip = musicaAC[3];
        musicaAS.Play();
    }
    
    public void CambiarEscena()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }
}
