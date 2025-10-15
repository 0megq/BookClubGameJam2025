using TMPro;
using UnityEngine;

public class Arrow : Interactable
{
    public TextMeshPro text;
    public Transform player;

    public void Awake()
    {
        text.enabled = false;
    }
    
    public override void Interact()
    {
        player.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        player.rotation = transform.rotation;
    }

    public override void StartHover()
    {
        base.StartHover();
        text.enabled = true;
    }

    public override void EndHover()
    {
        base.EndHover();
        text.enabled = false;
    }
}
