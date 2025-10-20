using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform start;
    Camera cam;
    Vector2 mousePos;
    Interactable hoveredObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = start.position;
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

            // is object close enough
            if (newObject && newObject.interactDistance < hit.distance)
            {
                newObject = null;
            }

            if (hoveredObject != newObject) // previously hovered was deselected
            {
                if (hoveredObject != null)
                    hoveredObject.EndHover();
                hoveredObject = newObject;
                if (hoveredObject != null)
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
