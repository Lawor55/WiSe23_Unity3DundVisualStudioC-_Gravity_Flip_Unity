using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float gravity = -9.81f;
    //[SerializeField] private float maxVelocity;
    private bool flipped;
    private new Rigidbody rigidbody;
    private Transform carTransform;
    private Animator animator;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        carTransform = transform.GetChild(0).transform;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(0, gravity * Time.deltaTime, 0);
        //float maxYVelocity = Mathf.Clamp(velocity.y, -maxVelocity, maxVelocity);
        //velocity.y = maxYVelocity;

        if (flipped)
        {
            rigidbody.velocity -= velocity;
        }
        else
        {
            rigidbody.velocity += velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            flipped = !flipped;
            animator.SetBool("isFlipped", flipped);
            velocity = new Vector3(0, rigidbody.velocity.y / 3, 0);
            rigidbody.velocity = velocity;
        }
    }
}
