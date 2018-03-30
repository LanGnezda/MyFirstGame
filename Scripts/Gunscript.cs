using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunscript : MonoBehaviour
{
    private Animator anim;

    public float range = 1000f;
    public int BulletsPerMag = 7;
    public int CurrentBullets;
    public Transform Exitpoint;
    public float FireRate = 1f;
    public float FireTimer;
    public AudioSource Audioclip;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        CurrentBullets = BulletsPerMag;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

        if (FireTimer < FireRate)
            FireTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.IsName("Idlefixed"))
        {

            anim.SetBool("Fire", false);

        }
   
    }

    private void Fire()
    {
        if (FireTimer < FireRate) return;

        RaycastHit hit;

        if (Physics.Raycast(Exitpoint.position, Exitpoint.transform.right, out hit, range))
        {
            Debug.Log(hit.transform.name + "found!");
            CurrentBullets--;
            anim.SetBool("Fire", true);
            anim.SetBool("Idle", false);
        }
        Audioclip.Play();
        anim.SetBool("Fire", true);
        anim.SetBool("Idle", false);



        FireTimer = 0.0f;

        if (CurrentBullets == 0)
        {
            FireRate = 3f;
            CurrentBullets = BulletsPerMag;
        }

        else
        {
            FireRate = 1f;
        }
    }

        

}

