using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandling_Script : MonoBehaviour
{
    public static PlayerHandling_Script Instance;

    bool carryingObject = false;


    private void Awake()
    {
        Instance = this;
    }


    void PickupItem()



    public bool isCarryingObject() { return carryingObject; }

}
