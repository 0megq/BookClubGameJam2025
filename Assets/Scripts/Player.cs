using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Material outlineMaterial;
    Camera cam;
    Vector2 mousePos;
    Interactable hoveredObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(mousePos);
        // send raycast every frame to show outline
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Interactable newObject = hit.transform.GetComponent<Interactable>();

            if (hoveredObject != null && hoveredObject != newObject) // previously hovered was deselected
            {
                hoveredObject.EndHover();
            }

            hoveredObject = newObject;
            if (hoveredObject)
            {
                hoveredObject.StartHover();
            }
        } else if (hoveredObject != null)
        {
            hoveredObject.EndHover();
            hoveredObject = null;
        }
    }

    void OnPoint(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }

    void OnClick()
    {
        if (hoveredObject)
        {
            hoveredObject.Interact();
            // interact with the object.
            // this interaction includes camera move, global game state changes, dialogue or other things
        }
    }
}
