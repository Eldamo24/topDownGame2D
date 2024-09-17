using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public int Health { get  ; set  ; }
    [SerializeField] private GameObject bullet;
    private float coolDown = 3f;
    private float waitTime = 0;
    private bool isAttacking = false;
    private Transform playerPosition;

    private void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }


    void Update()
    {
        if(Time.time > waitTime)
        {
            waitTime = Time.time + coolDown;
            Attack();
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
