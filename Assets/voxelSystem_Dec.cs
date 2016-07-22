using UnityEngine;
using System.Collections;

public class voxelSystem_Dec : MonoBehaviour
{
    public float pressure = 0.1f;
    public float pressureCH = 0.1f;
    public LayerMask mask = (1 << 29);
    public GameObject neighbor_Front;
    public GameObject neighbor_Right;
    public GameObject neighbor_Back;
    public GameObject neighbor_Left;
    // Use this for initialization
    void Start()
    {
        //init neighbor
        //hitting front
        RaycastHit hitF;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hitF, 1, mask.value))
        {
            neighbor_Front = hitF.collider.gameObject;
            // Debug.Log(this.name + "hit_" + hitF.collider.gameObject);
        }

        //hitting right
        RaycastHit hitR;
        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, out hitR, 1, mask.value))
        {
            neighbor_Right = hitR.collider.gameObject;
        }

        //hitting back
        RaycastHit hitB;
        Vector3 back = transform.TransformDirection(Vector3.back);
        if (Physics.Raycast(transform.position, back, out hitB, 1, mask.value))
        {
            neighbor_Back = hitB.collider.gameObject;
        }

        //hitting left
        RaycastHit hitL;
        Vector3 left = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, left, out hitL, 1, mask.value))
        {
            neighbor_Left = hitL.collider.gameObject;
        }

    }
    void Update()
   //public void changeVar()
    {
        //pressure = pressureCH;

       //Front_CV
        if (neighbor_Right != null)
        {
            if (neighbor_Right.GetComponent<voxelSystem>().pressure != pressure)
            {
            neighbor_Right.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
            neighbor_Right.gameObject.GetComponent<voxelSystem>().changeVar();
            //neighbor_Right.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  
        }
            //Destroy(neighbor_Right);
            
        }


       //Right_CV
        if (neighbor_Front != null)
        {
            if (neighbor_Front.GetComponent<voxelSystem>().pressure != pressure)
            {
                neighbor_Front.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Front.gameObject.GetComponent<voxelSystem>().changeVar();
                //neighbor_Front.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);
            }
           //Destroy(neighbor_Front);
            
        }


       //Back_CV
        if (neighbor_Left != null)
        {
            if (neighbor_Left.GetComponent<voxelSystem>().pressure != pressure)
            {
                neighbor_Left.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Left.gameObject.GetComponent<voxelSystem>().changeVar();
                //neighbor_Left.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);
            }
            //Destroy(neighbor_Left);
            
        }


       //Left_CV
        if (neighbor_Back != null)
        {
            if (neighbor_Back.GetComponent<voxelSystem>().pressure != pressure)
            {
                neighbor_Back.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Back.gameObject.GetComponent<voxelSystem>().changeVar();
               // neighbor_Back.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);

                //Destroy(neighbor_Back);
            }
        }

        //if (pressure != pressureCH) 
        //{
        //    this.GetComponent<Renderer>().material.color = new Color(pressure, 0.3f, 0.3f);
        //}
       
        //
        //
        //
        //
    }

    // Update is called once per frame
  //  void Update()
   // {

    //}
}
