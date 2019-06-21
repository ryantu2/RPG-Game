
using UnityEngine;

[AddComponentMenu("Village/First Person/Mouse  Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationalAxis
    {
        MouseX, 
        MouseY
    }
    [Header("Rotaion")]
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Range(0, 120)]
    public float sensitivity = 15f;
    public float minY = -60, maxY = 60;
    private float rotY;

    void Start () {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
	}
	
	
	void Update () {

        if (Movement.canMove)
        {
            if (Input.GetMouseButton(1))
            {
                if (axis == RotationalAxis.MouseX)
                {
                    this.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
                }
                else
                {
                    rotY += Input.GetAxis("Mouse Y") * sensitivity;
                    rotY = Mathf.Clamp(rotY, minY, maxY);
                    this.transform.localEulerAngles = new Vector3(-rotY, 0, 0);
                }
            }
        }

       
        
	}
}
