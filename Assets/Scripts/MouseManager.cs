using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private int Area;

    private void Awake()
    {
        Area = LayerMask.NameToLayer("Area");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.transform.gameObject.layer == Area)
                {
                    hit.transform.TryGetComponent<Area>(out Area area);
                    area.OnClick.Invoke();
                }
            }
        }
    }
}
