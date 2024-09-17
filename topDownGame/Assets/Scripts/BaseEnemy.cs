using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public int Health { get  ; set  ; }

    [SerializeField] private GameObject bullet;
    private Transform playerPosition;

    [Header("Attack")]
    [SerializeField] private int bulletAmount; //Cantidad de balas que disparara por oleada
    private float coolDownBetweenShoots = 0.5f; //Cooldown entre disparos
    private int bulletCount; //Contador de balas.
    private bool canAttack;
    private float waitTime = 0;
    [SerializeField] private float coolDownBetweenWaves; //Cooldown entre oleadas de disparos

    private void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        canAttack = false;
        Health = 100;
    }

    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
        if(canAttack)
        {
            WavesAttack();
        }
        else
        {
            CoolDownAttack();
        }
    }

    private void WavesAttack()
    {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + coolDownBetweenShoots;
            bulletCount++;
            if (bulletCount == bulletAmount)
            {
                canAttack = false;
                waitTime = Time.time + coolDownBetweenWaves;
            }
            Attack();
        }
    }

    private void CoolDownAttack()
    {
        if (Time.time > waitTime)
        {
            canAttack = true;
            bulletCount = 0;
        }
    }


    public void Attack()
    {
        Vector3 direction = playerPosition.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Instantiate(bullet, transform.position, Quaternion.Euler(0,0,angle));
    }

    public void Movement()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health < 0)
        {
            Health = 0;
        }
    }
    
}
