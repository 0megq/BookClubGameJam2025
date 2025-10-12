using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Material outlineMaterial;

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
        var meshRenderer = GetComponent<MeshRenderer>();
        var originalMat = meshRenderer.material;
        Material[] materials = new Material[2];
        materials[0] = originalMat;
        materials[1] = outlineMaterial;
        meshRenderer.materials = materials;
    }

    public void DisableOutline()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var originalMat = meshRenderer.material;
        Material[] materials = new Material[1];
        materials[0] = originalMat;
        meshRenderer.materials = materials;
    }
}
