using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    [SerializeField] private bool isOpened = false;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Opened", true);
            animator.SetBool("Closed", false);
            isOpened = true;
        }
        if(Input.GetKeyDown(KeyCode.R)& isOpened)
        {
            animator.SetBool("Closed", true);
            animator.SetBool("Opened", false);
            isOpened = false;
        }
    }

}
