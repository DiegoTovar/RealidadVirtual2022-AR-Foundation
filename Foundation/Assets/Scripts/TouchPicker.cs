using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPicker : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.GetComponent<ITouchPickableObject>()?.Pick();
            }
        }
    }
}
