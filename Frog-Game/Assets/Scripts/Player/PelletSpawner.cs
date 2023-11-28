using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PelletSpawner : MonoBehaviour
{
    [SerializeField] GameObject pellet;
    [SerializeField] Transform shootPoint;
    private Animator frogAnimation;
    
    void Update()
    {
        frogAnimation = GetComponent<Animator>();

        if (Input.GetButtonDown("Fire1"))
        {
            frogAnimation.SetBool("IsShooting", true);
            Spawn();
        } else {
            frogAnimation.SetBool("IsShooting", false);
        }
    }
    void Spawn()
    {
        Instantiate(pellet, shootPoint.position, shootPoint.rotation);
    }
}