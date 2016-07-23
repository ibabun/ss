using UnityEngine;
using System.Collections;

public class voxelSystem_ADD : MonoBehaviour
{
    public int thisID;
    public manageIds manageIds;
    public GameObject manager;
    public bool kill = false;
    public int weight = 0;
    public float pressure = 1f;
    public float pressureCH = 1f;
    public LayerMask mask = (1 << 29);
    public GameObject neighbor_Front;
    public GameObject neighbor_Right;
    public GameObject neighbor_Back;
    public GameObject neighbor_Left;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("manager");
        //thisID = nextID;
        //nextID = +1;
        //init neighbor
        //hitting front
        thisID = manager.GetComponent<manageIds>().nextID;
        manager.GetComponent<manageIds>().nextID = thisID + 1;

        RaycastHit hitF;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hitF, 1, mask.value))
        {
            neighbor_Front = hitF.collider.gameObject;
            hitF.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitF.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
        }  
        
        //hitting right
        RaycastHit hitR;
        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, out hitR, 1, mask.value))
        {
            neighbor_Right = hitR.collider.gameObject;
            hitR.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitR.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
        }

        //hitting back
        RaycastHit hitB;
        Vector3 back = transform.TransformDirection(Vector3.back);
        if (Physics.Raycast(transform.position, back, out hitB, 1, mask.value))
        {
            neighbor_Back = hitB.collider.gameObject;
            hitB.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitB.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
        }

        //hitting left
        RaycastHit hitL;
        Vector3 left = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, left, out hitL, 1, mask.value))
        {
            neighbor_Left = hitL.collider.gameObject;
            hitL.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitL.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
        }

    }

    void Update()
    //public void changeVar()
    {
        //pressure = pressureCH;

        //Front_CV
        if (neighbor_Right != null && neighbor_Right.GetComponent<voxelSystem>().pressure != pressure)
        {
            neighbor_Right.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
            neighbor_Right.gameObject.GetComponent<voxelSystem>().changeVar();
            //neighbor_Right.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            //Destroy(neighbor_Right);

        }


        //Right_CV
        if (neighbor_Front != null && neighbor_Front.GetComponent<voxelSystem>().pressure != pressure)
        {
            neighbor_Front.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
            neighbor_Front.gameObject.GetComponent<voxelSystem>().changeVar();
            //neighbor_Front.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            //Destroy(neighbor_Front);

        }


        //Back_CV
        if (neighbor_Left != null && neighbor_Left.GetComponent<voxelSystem>().pressure != pressure)
        {
            neighbor_Left.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
            neighbor_Left.gameObject.GetComponent<voxelSystem>().changeVar();
            //neighbor_Left.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            //Destroy(neighbor_Left);

        }


        //Left_CV
        if (neighbor_Back != null && neighbor_Back.GetComponent<voxelSystem>().pressure != pressure)
        {
            neighbor_Back.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
            neighbor_Back.gameObject.GetComponent<voxelSystem>().changeVar();
           // neighbor_Back.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            //Destroy(neighbor_Back);

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
