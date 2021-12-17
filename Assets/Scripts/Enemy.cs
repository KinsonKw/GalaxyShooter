using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float _target;
    [SerializeField] private float speed;

    [SerializeField] private float range;

    [SerializeField] private  AudioSource death;

    public MeshRenderer mesh = null;
    public Collider collider;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == false && Vector3.Distance(transform.position, target.position) < range)
        {
            transform.LookAt(target);
            Vector3 a = transform.position;
            Vector3 b = target.position;

            transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a,b, _target), speed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GalaxyShooter");
        }
    }
    public void Kill()
    {
        dead = true;
        mesh.enabled = false;
        collider.enabled = false;
        death.Play();
    }
}
