using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove_Script : MonoBehaviour
{
    //Variables
    public static PlayerMove_Script Instance;

    public Rigidbody myRB;
    public float playerSpeed;
    float basePlayerSpeed = 4f;
    Vector3 moveDirection;

    public Transform orientation;

    KeyCode forwardKey = KeyCode.W;
    KeyCode backKey = KeyCode.S;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;


    private void Awake()
    {
        Instance = this;

        myRB = GetComponent<Rigidbody>();
        //playerSpeed = basePlayerSpeed;
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(forwardKey))
        {
            moveZ += 1f;
        }
        if (Input.GetKey(backKey))
        {
            moveZ -= 1f;
        }
        if (Input.GetKey(leftKey))
        {
            moveX -= 1f;
        }
        if (Input.GetKey(rightKey))
        {
            moveX += 1f;
        }

        moveDirection = orientation.forward * moveZ + orientation.right * moveX;

        moveDirection = moveDirection.normalized;

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 targetVeloctiy = moveDirection * playerSpeed;
        myRB.linearVelocity = new Vector3(targetVeloctiy.x, myRB.linearVelocity.y, targetVeloctiy.z);
    }

}
