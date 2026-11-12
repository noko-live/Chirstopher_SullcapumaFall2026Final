using Unity.VisualScripting;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    bool isInteractable = true;


    enum ObjectType
    {
        Fishing_Rod,
        Bucket,
        TackleBox,
        Misc
    }

    public Transform[] placeableLocations;



    void OnInteract()
    {
        if(isInteractable)
        {
        }
    }

    void HideObject() { gameObject.SetActive(false); }
    void RevealObject() { gameObject.SetActive(true); }


}
