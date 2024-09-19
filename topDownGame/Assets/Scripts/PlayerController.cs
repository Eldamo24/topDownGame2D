using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D rb;
    private PlayerInput inputs;
    [SerializeField] private float speed;

    [Header("AIM")]
    [SerializeField] private Transform aim;
    private Vector2 rotateVector;
    [SerializeField] private float aimDistance;
    private Vector3 aimPosition;

    [Header("Shoot")]
    [SerializeField] private GameObject bullet;
    private bool isShooting;
    [SerializeField] private float cooldown;
    private float waitTime;

    [Header("Life")]
    [SerializeField] private int life = 100;
    private const int maxLife = 100;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<PlayerInput>();
        aim = GameObject.Find("AIM").GetComponent<Transform>();
        inputs.actions["AIMMovement"].performed += ctx => rotateVector = ctx.ReadValue<Vector2>();
        inputs.actions["Shoot"].performed += StartShoot;
        inputs.actions["Shoot"].canceled += EndShoot;
        aimPosition = Vector3.zero;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        AIMMovement();
        if (isShooting && Time.time > waitTime)
        {
            waitTime = Time.time + cooldown;
            Shoot();
        }
    }

    void Movement()
    {
        Vector2 moveVector = inputs.actions["Movement"].ReadValue<Vector2>();
        Vector2 newPos = rb.position + moveVector * speed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -8f, 8f);
        newPos.y = Mathf.Clamp(newPos.y, -4.5f, 4.5f);
        rb.MovePosition(newPos);
    }

    void AIMMovement()
    {
        if (inputs.currentControlScheme.Equals("Gamepad"))
        {
            Vector2 direction = rotateVector.normalized;
            if (Gamepad.current != null && direction.magnitude > 0.1f)
            {
                aimPosition = transform.position + new Vector3(direction.x, direction.y, 0f) * aimDistance;
            }
        }
        else
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            mouseWorldPosition.z = transform.position.z; 
            Vector3 direction = (mouseWorldPosition - transform.position).normalized;
            aimPosition = transform.position + direction * aimDistance;
        }
        aim.position = aimPosition;
    }

    void Shoot()
    {
        Vector3 direction = aim.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(bullet, aim.position, Quaternion.Euler(0,0, angle - 90f));
    }

    void StartShoot(InputAction.CallbackContext context)
    {
        isShooting = true;
    }

    void EndShoot(InputAction.CallbackContext context)
    {
        isShooting = false;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life < 0)
        {
            life = 0;
        }
    }

    public void AddLife(int extraLife)
    {
        life += extraLife;
        if(life > maxLife)
        {
            life = maxLife;
        }
    }

}
