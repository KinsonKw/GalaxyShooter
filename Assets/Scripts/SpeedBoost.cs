using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private bool roll = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.LogError("SpeedBoost");
            PathPlaneController plane = other.GetComponentInParent<PathPlaneController>();
            plane.SpeedBoost();
            animator.SetBool("Roll", true);
            roll = false;
            Destroy(gameObject);

        }
    }
}
