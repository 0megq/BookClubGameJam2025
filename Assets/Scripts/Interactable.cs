using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Color tintColor = new Color(0, 1, 1, 0.75f);
    public float interactDistance = 20;

    public abstract void Interact();
    public virtual void StartHover()
    {
        EnableOutline();
    }

    public virtual void EndHover()
    {
        DisableOutline();
    }

    public void EnableOutline()
    {
        foreach (MeshRenderer ren in GetComponentsInChildren<MeshRenderer>())
        {
            ren.material.SetColor("_TintColor", tintColor);
            if (ren.materials.Length > 1)
                ren.materials[1].SetFloat("_OutlineWidth", 4);
        }
        foreach (SkinnedMeshRenderer ren in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            ren.material.SetColor("_TintColor", tintColor);
            if (ren.materials.Length > 1)
            ren.materials[1].SetFloat("_OutlineWidth", 4);
        }
    }

    public void DisableOutline()
    {
        foreach (MeshRenderer ren in GetComponentsInChildren<MeshRenderer>())
        {
            ren.material.SetColor("_TintColor", Color.clear);
            if (ren.materials.Length > 1)
                ren.materials[1].SetFloat("_OutlineWidth", 0);
        }
        foreach (SkinnedMeshRenderer ren in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            ren.material.SetColor("_TintColor", Color.clear);
            if (ren.materials.Length > 1)
                ren.materials[1].SetFloat("_OutlineWidth", 0);
        }
    }
}
