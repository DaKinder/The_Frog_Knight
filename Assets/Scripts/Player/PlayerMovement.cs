using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float angularSpeed = 100f;
    [SerializeField] private float jumpForce = 130f;
    
    private Rigidbody playerRb;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string Running = "Running";
    private const string MouseX = "Mouse X";

    private Vector3 direction;
    private Vector3 directionOfRotation;
    
    private bool isRunning;
    private bool isOnGround;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        direction.x = Input.GetAxis(horizontal);
        direction.z = Input.GetAxis(vertical);
        //isRunning = Input.GetButton(Running);

        directionOfRotation.y = Input.GetAxis(MouseX) * angularSpeed * Time.deltaTime;

        transform.Rotate(directionOfRotation);
        // transform.position += transform.rotation * direction * ((isRunning ? runSpeed : speed) * Time.deltaTime);

        playerRb.AddForce(transform.forward * speed * direction.z, ForceMode.Impulse);
        playerRb.AddForce(transform.right * speed * direction.x, ForceMode.Impulse);

        //playerRb.velocity = transform.right * speed * direction.x;
        //playerRb.velocity = transform.forward * speed * direction.z;
        Debug.Log(playerRb.velocity);

        //if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        //{
        //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //    //playerRb.velocity = Vector3.up * 4;
        //    isOnGround = false;
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
