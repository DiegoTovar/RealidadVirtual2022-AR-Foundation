using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour, ITouchPickableObject
{
    [SerializeField]
    private Color onPickedColor;
    private bool isPicked;
    
    private Color originalColor;
    private MeshRenderer myMesh;
    private Touch screenTouch;

    private void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        originalColor = myMesh.sharedMaterial.color;
    }

    public void Pick()
    {
        isPicked = true;
        myMesh.sharedMaterial.color = onPickedColor;
    }

    public void Unpick() 
    {
        isPicked = false;
        myMesh.sharedMaterial.color = originalColor;
    }

    private void Update()
    {
        if (isPicked) 
        {
            if (Input.touchCount > 0)
            {
                screenTouch = Input.GetTouch(0);
                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(0f, -screenTouch.deltaPosition.x, 0f);
                }

                if (screenTouch.phase == TouchPhase.Ended)
                {
                    Unpick();
                }
            }
        }
    }
}
