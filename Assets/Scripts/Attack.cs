using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Melee;
    bool isAttacking = false;
    float attackDuration = 0.3f;
    float attackTimer = 0f;
    
    public Transform Aim;
    public GameObject bullet;
    public float fireForce = 10f;
    float shootCooldown = 0.25f;
    float shootTimer = 0.5f;
    // Update is called once per frame
    
    void Update()
    {
        CheckMeleeTimer();
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) // e and click button
        {
            OnAttack();
        }
        // if(Input.GetKeyDown(KeyCode.H))
        // {
        //     OnShoot();
        // }
    }

    void OnAttack()
    {
        if (!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
        }
    }

    void OnShoot()
    {
        if(shootTimer > shootCooldown)
        {
            Debug.Log("shooting...");
            shootTimer = 0.26f;
            GameObject intBullet = Instantiate(bullet, Aim.position, Aim.rotation);
            intBullet.GetComponent<Rigidbody2D>().AddForce(-Aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(intBullet, 2f);
        }
    }

    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                attackTimer = 0;
                isAttacking = false;
                Melee.SetActive(false);
            }
        }
    }
}
