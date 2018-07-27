
using UnityEngine;


// composant requis au bon fonctionnement du script
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    // vitesse de deplacement
    [SerializeField]
    private float speed = 3f;

    // vitesse de rotation 
    [SerializeField]
    private float lookSensitivity = 6f;

    private PlayerMotor motor;


    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }


    private void Update()
    {
        calculMovement();
        calculRotation();
    }


    // on va calculer la velocité du mouvement du joueur dans un vecteur 3d
    void calculMovement()
    {
        /**
         * si x = -1 alors left
         * si x = 0 alors bouge pas 
         * si x = 1 alors droite
         * 
         * si y = -1 recule
         * si y = 0 bouge pas 
         * si y = 1 avance
         * 
         **/
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);


    }

    // pour calculer la rotation de la camera
    void calculRotation()
    {
        float _yRot = Input.GetAxisRaw("Mouse X");
        float _xRot = Input.GetAxisRaw("Mouse Y");


        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;
        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * lookSensitivity;

        motor.Rotate(_rotation);
        motor.RotateCamera(_cameraRotation);
    }


}
