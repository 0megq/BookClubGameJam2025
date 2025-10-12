using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : Interactable
{
    public TextMeshPro text;
    bool open = false;
    public void Awake()
    {
        text.enabled = false;
    }

    public override void Interact()
    {
        if (open)
        {
            transform.Rotate(-Vector3.up * 80);
            text.transform.Rotate(Vector3.up * 80);
        }
        else {
            transform.Rotate(Vector3.up * 80);
            text.transform.Rotate(-Vector3.up * 80);
        }
        open = !open;
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
