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
    public GameObject pointer;

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
      
        RaycastHit hit;
        ray = new Ray(Camera.main.gameObject.transform.position, Camera.main.gameObject.transform.forward);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000, interactable))
        {
            Collider objectHit = hit.collider;
            Debug.Log(objectHit);


            pointer.SetActive(true);

            if (!carryingObject && Input.GetKey(interactKey))
            {
                if (objectHit != null && objectHit.transform.gameObject.CompareTag("Boat"))
                {
                    if (objectHit.transform.gameObject.CompareTag("Interactable"))
                    {
                        Debug.Log("found objecct");
                        objectHit.gameObject.SetActive(false);

                        objectHit.gameObject.SendMessage("PlayerInteract");
                    }
                    else if (objectHit.transform.gameObject.CompareTag("FishingRod"))
                    {
                        Debug.Log("Rod Interacted");
                    }
                }

            }
        }
        else
        {
            pointer.SetActive(false);
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


