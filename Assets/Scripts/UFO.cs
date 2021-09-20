using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UFO : MonoBehaviour
{
    bool gameover = false;
    bool ExplosionPlayed = false;

    public Transform Ufo;

    public Rigidbody leftSoplo;
    public Rigidbody rightSoplo;
    public float force = 15;
    public float rotationForce = 0.8f;

    private SceneLoader sceneLoader;

    public Slider rightEngineSlider;
    public Slider leftEngineSlider;
    public Slider heightSlider;
   
    public Text rightEngineText;
    public Text leftEngineText;
    public Text heightText;

    private AudioSource[] Sounds;
    public float speed, k = 0.1f, c = 1f;
    public float maxHeight;

    public GameObject explosionParticles;
    public GameObject[] UfoDecor;
    public GameObject[] UfoBody;
    public Rigidbody[] UfoBodyRb;

    Vector3 leftForce;
    Vector3 rightForce;

    void Start()
    {
        rightEngineSlider.maxValue = force;
        leftEngineSlider.maxValue = force;
        sceneLoader = FindObjectOfType<SceneLoader>();
        Sounds = GetComponents<AudioSource>();        
        heightSlider.maxValue = maxHeight;
    }

    void FixedUpdate()
    {
        EngineSound();

        if (gameover == true)
            return;

        Vector3 minForce = Vector3.up * force * rotationForce;
        Vector3 maxForce = Vector3.up * force;

        leftForce = Vector3.zero;
        rightForce = Vector3.zero;

        float hMove = Input.GetAxisRaw("Horizontal");

        if (hMove == -1)
        {
            leftForce = minForce;
            rightForce = maxForce;
        }        
        else if (hMove == 1)
        {
            leftForce = maxForce;
            rightForce = minForce;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            leftForce = maxForce;
            rightForce = maxForce;
        }

        UI_Sliders();

        Restart();
    }

    void UI_Sliders()
    {
        leftSoplo.AddRelativeForce(leftForce);
        rightSoplo.AddRelativeForce(rightForce);

        leftEngineSlider.value = leftForce.y;
        rightEngineSlider.value = rightForce.y;

        rightEngineText.text = rightForce.y + "Wt";
        leftEngineText.text = leftForce.y + "Wt";

        heightSlider.value = Ufo.position.y;
        heightText.text = Math.Round(heightSlider.value, 1) + "m";
    }

    void EngineSound()
    {
        if (gameover == true)
        {
            Sounds[1].volume = Mathf.Lerp(speed, 0, 2);            
        }
            
        speed = leftSoplo.velocity.magnitude;
        Sounds[1].pitch = speed * k;
        Sounds[1].volume = speed * c;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayExplosion();
            StartCoroutine(ReloadScene());
        }

        if (collision.gameObject.CompareTag("Friend") && !gameover)
        {
            sceneLoader.NextScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DeathCollider"))
        {
            StartCoroutine(ReloadScene());            
        }
    }

    IEnumerator ReloadScene()
    {
        gameover = true;
        yield return new WaitForSeconds(2);
        sceneLoader.ReloadScene();
    }
    void Restart()
    { 
        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneLoader.ReloadScene();      
        }
    }

    void PlayExplosion()
    {
        if (ExplosionPlayed == false)
        {
            ExplosionPlayed = true;
            MoveUfoCompsUpInHierarchy();
            Explode();
            GameObject explosionP = Instantiate(explosionParticles, Ufo);
            Destroy(explosionP, 3);
        }
        
        Sounds[0].Play();        
    }

    void MoveUfoCompsUpInHierarchy()
    {
        foreach (var i in UfoDecor)
        {            
            i.transform.parent = null;  
            i.AddComponent<Rigidbody>().isKinematic = false;
        }

        foreach (var i in UfoBody)
        {
            i.transform.parent = null;           

            foreach (var j in UfoBodyRb)
            {
                j.isKinematic = false;
                j.AddExplosionForce(100f, transform.position, 5f);
            }
        }       
        Debug.Log("GOT IT!!!");
    }

    private void Explode()
    {       
        gameObject.GetComponent<Rigidbody>().AddExplosionForce(50000f, transform.position, 5f);
        Debug.Log("Explode!!!");
    }

}
