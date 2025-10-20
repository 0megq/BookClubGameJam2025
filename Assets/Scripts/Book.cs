using UnityEngine;

public class Book : Interactable
{
    Animation animation1;
    public ChildInteractable putDownButton;
    public ChildInteractable doorScene;
    public Transform doorSceneCameraStart;
    public Transform playerCamera;
    
    int stage = 0;

    public void Awake()
    {
        animation1 = GetComponent<Animation>();
        putDownButton.InteractExternal = PutDown;
        putDownButton.gameObject.SetActive(false);
        doorScene.InteractExternal = EnterDoorScene;
        doorScene.gameObject.SetActive(false);
    }

    public override void Interact()
    {

        switch (stage)
        {
            case 0:
                animation1.Play("book1");
                stage = 1;
                break;
            case 1:
                Debug.Log("Book opens");
                doorScene.gameObject.SetActive(true);
                break;
        }
    }

    public void EnterDoorScene()
    {
        // send camera to the door scene
        playerCamera.position = doorSceneCameraStart.position;
        playerCamera.rotation = doorSceneCameraStart.rotation;
        // close the book and reset the room scene
    }


    public void PutDown()
    {
        animation1.Play("book2");
        stage = 0;
    }
}
