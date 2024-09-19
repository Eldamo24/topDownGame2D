using UnityEngine;

public class Exploder : MonoBehaviour, IEnemy
{
    public int Health { get ; set ; }
    public EnemySpawnManager spawn { get; set; }

    [Header("Movement")]
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private float distanceToPlayer = 1f;

    [Header("Attack")]
    public bool canAttack;
    private float coolDown = 3f;
    private float waitTime = 0f;
    [SerializeField] private GameObject areaHit;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        Health = 100;
        canAttack = false;
    }

    void Update()
    {
        if (canAttack && Time.time > waitTime)
        {
            waitTime = Time.time + coolDown;
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (CheckDistanceToPlayer() && !canAttack)
        {
            Movement();
        }
        else
        {
            canAttack = true;
        }
    }

    public void Attack()
    {
        AreaHit hit = Instantiate(areaHit, transform.position, Quaternion.identity).GetComponent<AreaHit>();
        hit.exploder = this;
    }

    public void Movement()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private bool CheckDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.position) > distanceToPlayer;
    }

    private void OnDestroy()
    {
        spawn.SubstractEnemy();
    }
}
