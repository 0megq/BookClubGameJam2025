using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Color tintColor = new Color(0, 1, 1, 0.5f);

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
        originalMat.SetColor("_TintColor", tintColor);
    }

    public void DisableOutline()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var originalMat = meshRenderer.material;
        originalMat.SetColor("_TintColor", Color.clear);
    }
}
