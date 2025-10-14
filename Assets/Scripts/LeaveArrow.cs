using TMPro;
using UnityEngine;

public class LeaveArrow : Interactable
{
    public TextMeshPro text;

    public void Awake()
    {
        text.enabled = false;
    }

    public override void Interact()
    {
        if (Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else 
            Application.Quit();
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
