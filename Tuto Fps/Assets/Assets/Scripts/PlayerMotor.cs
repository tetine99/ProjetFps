using UnityEngine;

// composant requis au bon fonctionnement du script
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    public Camera cam;

    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 cameraRotation;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // update pour la physique ( a un temp precis a chaque frame ) 
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    // on recois la velocité du controller
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;

    }
    // on recois la rotation du controller
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    // pour effectuer le mouvement
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            // pour effectuer le mouvement


        }
    }
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-cameraRotation);
    }
}
