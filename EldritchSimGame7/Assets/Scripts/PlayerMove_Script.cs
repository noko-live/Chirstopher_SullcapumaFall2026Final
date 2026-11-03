using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove_Script : MonoBehaviour
{
    //Variables
    public static PlayerMove_Script Instance;

    public Rigidbody myRB;
    public float playerSpeed;
    float basePlayerSpeed = 12f;
    Vector3 moveDirection;
    public InputActionReference move;


    Rigidbody playerRB;
    private void Awake()
    {
        Instance = this;

        myRB = GetComponent<Rigidbody>();
        playerSpeed = basePlayerSpeed;
        playerRB = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        moveDirection = move.action.ReadValue<Vector3>();

    }

    private void FixedUpdate()
    {
        playerRB.linearVelocity = new Vector3(moveDirection.x * playerSpeed, moveDirection.y, moveDirection.z * playerSpeed);
    }

}
