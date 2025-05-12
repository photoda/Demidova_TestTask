using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSpeed = 10;
    public float speed = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(-v, 0, h);

        if (directionVector.sqrMagnitude > 0.0025f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionVector);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        rigidbody.linearVelocity = directionVector * speed; 
    }
}