using System;
using UnityEngine;

public class ChildInteractable : Interactable
{
    public delegate void ChildInteractableDelegate();

    public ChildInteractableDelegate InteractExternal;
    public override void Interact()
    {
        InteractExternal?.Invoke();
    }
}
