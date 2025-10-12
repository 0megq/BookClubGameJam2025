using UnityEngine;

public class Arrow : Interactable
{
    public Transform player;
    public override void Interact()
    {
        player.position = transform.position + Vector3.up * 1;
    }
}
