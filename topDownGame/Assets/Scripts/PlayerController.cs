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
    [SerializeField] private float stickSensitivity;
    private Vector2 rotateVector;
    [SerializeField] private float aimDistance;

    [Header("Shoot")]
    [SerializeField] private GameObject bullet;
    private bool isShooting;
    [SerializeField] private float cooldown;
    private float waitTime;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<PlayerInput>();
        aim = GameObject.Find("AIM").GetComponent<Transform>();
        inputs.actions["AIMMovement"].performed += ctx => rotateVector = ctx.ReadValue<Vector2>();
        inputs.actions["Shoot"].performed += StartShoot;
        inputs.actions["Shoot"].canceled += EndShoot;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Movement();
        if (isShooting && Time.time > waitTime)
        {
            waitTime = Time.time + cooldown;
            Shoot();
        }
    }

    private void Update()
    {
        AIMMovement();
    }

    void Movement()
    {
        Vector2 moveVector = inputs.actions["Movement"].ReadValue<Vector2>();
        moveVector.Normalize();
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }

    void AIMMovement()
    {
        Vector3 aimPosition;
        if (Gamepad.current != null && rotateVector.magnitude > 0.1f)
        {
            Vector2 direction = rotateVector.normalized;
            aimPosition = transform.position + new Vector3(direction.x, direction.y, 0f) * aimDistance;
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

}
