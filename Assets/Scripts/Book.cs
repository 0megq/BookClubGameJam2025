using UnityEngine;

public class Book : Interactable
{
    Animation animation1;
    public ChildInteractable putDownButton;
    public int stage = 0;
    public void Awake()
    {
        animation1 = GetComponent<Animation>();
        putDownButton.InteractExternal = PutDown;
        putDownButton.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        
        switch (stage)
        {
            case 0:
                animation1.Play("book1");
                stage = 1;
                putDownButton.gameObject.SetActive(true);
                break;
            case 1:
                Debug.Log("Book opens");
                break;
        }
    }

    public void PutDown()
    {
        Debug.Log("Hello");
        animation1.Play("book2");
        stage = 0;
        putDownButton.gameObject.SetActive(false);
    }
}
