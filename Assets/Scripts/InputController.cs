using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public LayerMask mask;
   // private Mouse mouse = null;
    // Start is called before the first frame update
    void Start()
    {
       // mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 50f, mask))
            {

                Destroy(hit.transform.gameObject);
            }
        }
    }
}
