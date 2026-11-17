using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Scripting;

public class PlayerHandling_Script : MonoBehaviour
{
    public static PlayerHandling_Script Instance;

    bool carryingObject = false;
    public Camera playerCam;
    KeyCode interactKey = KeyCode.E;
    public LayerMask interactable;
    public Ray ray;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    private void Update()
    {

    }


    void FixedUpdate()
    {
        if (!carryingObject && Input.GetKey(interactKey))
        {
            RaycastHit hit;
            ray = playerCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000, interactable))
            {
                Debug.Log("test");
                Collider objectHit = hit.collider;
                Debug.Log(objectHit);


                if (objectHit != null && objectHit.transform.gameObject.CompareTag("Boat"))
                {
                    GameObject hitObject = objectHit.transform.root.gameObject;

                    if  (objectHit.transform.gameObject.CompareTag("Interactable"))
                    {
                        Debug.Log("found objecct");
                        objectHit.gameObject.SetActive(false);
                    }
                }
            }

        }

        DrawLinePOV();
    }

    void DrawLinePOV()
    {
        float q = 0.0f;
        Color color = new Color(q, q, 1.0f);
        Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 1000f), color);
        q = q + 0.01f;

        if (q > 1.0f)
        {
            q = 0.0f;
        }
    }

}


