using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class Player_controler : MonoBehaviour {

    public Interakcja focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

	}
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())
            return;


        //RUCH (LPM)
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {

                motor.MoveToPoint(hit.point);

                RemoveFocus();
                

            }
               
        }
        //Interakcja (PPM)
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {

              Interakcja interakcja = hit.collider.GetComponent<Interakcja>();
                
                if (interakcja != null)
                {
                    SetFocus(interakcja);
                }
            }

        }
    }
    void SetFocus (Interakcja newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDeFocused();

            motor.FollowTarget(newFocus);
            focus = newFocus;
        }

       
       newFocus.OnFocused(transform);
       
    }

    void RemoveFocus()
    {
        if (focus != null)       
            focus.OnDeFocused();

        focus = null;    
        motor.StopFollowingTarget();
    }
}
