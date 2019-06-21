using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Village/First Person/Movement")]
public class Movement : MonoBehaviour {

    enum movestyle
    {
        R,
        C

    }

    movestyle style;


    [Header("PLayer Speed")]
    public float movespeed = 10f, walkSpeed = 10f, runSpeed = 25f, crouchSpeed = 4f, jumpForce = 8f;

    public static bool canMove;
    private float _gravity = 20f;
    private Vector3 _moveDir;
    private CharacterController _charController;

    // Use this for initialization
	void Start () {
        _charController = this.GetComponent<CharacterController>();
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (canMove)
        {
            if (Input.GetButton("Run"))
            {
                movespeed = runSpeed;
            }
            else if (Input.GetButton("Crouch"))
            {
                movespeed = crouchSpeed;
            }
            else
            {
                movespeed = walkSpeed;
            }

            if (_charController.isGrounded)
            {
                _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                _moveDir = this.transform.TransformDirection(_moveDir);
                _moveDir *= movespeed;
                //note the obove 3 line can be done in one like
                // _moveDir = this.transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpForce;
                }
            }
            _moveDir.y -= _gravity * Time.deltaTime;
            _charController.Move(_moveDir * Time.deltaTime);
        }

        
    }
}
