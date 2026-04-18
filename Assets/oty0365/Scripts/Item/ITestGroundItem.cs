using UnityEngine;

public class ITestGroundItem : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        Debug.Log("Ground Item Interacted");
    }
}
