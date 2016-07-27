using UnityEngine;
using System.Collections;

public class voxelSystem_ADD : MonoBehaviour
{
    public int thisID;
    public manageIds manageIds;
    public GameObject manager;
    public bool alive = true;
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
        manager.GetComponent<manageIds>().nextID++;
        RaycastHit hitF;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hitF, 1, mask.value))
        {
            neighbor_Front = hitF.collider.gameObject;
            hitF.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitF.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
            hitF.collider.gameObject.GetComponent<voxelSystem>().parentIsalive = true;
        }

        //hitting right
        RaycastHit hitR;
        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, out hitR, 1, mask.value))
        {
            neighbor_Right = hitR.collider.gameObject;
            hitR.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitR.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
            hitR.collider.gameObject.GetComponent<voxelSystem>().parentIsalive = true;
        }

        //hitting back
        RaycastHit hitB;
        Vector3 back = transform.TransformDirection(Vector3.back);
        if (Physics.Raycast(transform.position, back, out hitB, 1, mask.value))
        {
            neighbor_Back = hitB.collider.gameObject;
            hitB.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitB.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
            hitB.collider.gameObject.GetComponent<voxelSystem>().parentIsalive = true;
        }

        //hitting left
        RaycastHit hitL;
        Vector3 left = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, left, out hitL, 1, mask.value))
        {
            neighbor_Left = hitL.collider.gameObject;
            hitL.collider.gameObject.GetComponent<voxelSystem>().parentID = thisID;
            hitL.collider.gameObject.GetComponent<voxelSystem>().weight = weight + 1;
            hitL.collider.gameObject.GetComponent<voxelSystem>().parentIsalive = true;
        }

    }

    void Update()
    //public void changeVar()
    {
        //pressure = pressureCH;

        //Front_CV
        if (neighbor_Right != null && neighbor_Right.GetComponent<voxelSystem>().pressure != pressure)
        {
            if (alive)
            {
                neighbor_Right.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Right.gameObject.GetComponent<voxelSystem>().changeVar();
                //neighbor_Right.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            }


            //Destroy(neighbor_Right);

        }


        //Right_CV
        if (neighbor_Front != null && neighbor_Front.GetComponent<voxelSystem>().pressure != pressure)
        {
            if (alive)
            {
                neighbor_Front.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Front.gameObject.GetComponent<voxelSystem>().changeVar();
                //neighbor_Front.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            }

            //Destroy(neighbor_Front);

        }


        //Back_CV
        if (neighbor_Left != null && neighbor_Left.GetComponent<voxelSystem>().pressure != pressure)
        {
            if (alive)
            {
                neighbor_Left.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Left.gameObject.GetComponent<voxelSystem>().changeVar();
                //neighbor_Left.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            }

            //Destroy(neighbor_Left);

        }


        //Left_CV
        if (neighbor_Back != null && neighbor_Back.GetComponent<voxelSystem>().pressure != pressure)
        {
            if (alive)
            {
                neighbor_Back.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Back.gameObject.GetComponent<voxelSystem>().changeVar();
                // neighbor_Back.GetComponent<Renderer>().material.color = new Color(pressure, pressure, pressure);  

            }
        }


        if (neighbor_Right != null)
        {
            if (alive == false)
            {
                neighbor_Right.gameObject.GetComponent<voxelSystem>().weight = 99999;
                neighbor_Right.gameObject.GetComponent<voxelSystem>().changeVar();
                neighbor_Right.gameObject.GetComponent<voxelSystem>().parentIsalive = false;
            }

        }
        if (neighbor_Front != null)
        {
            if (alive == false)
            {
                neighbor_Front.gameObject.GetComponent<voxelSystem>().weight = 99999;
                neighbor_Front.gameObject.GetComponent<voxelSystem>().changeVar();
                 neighbor_Front.gameObject.GetComponent<voxelSystem>().parentIsalive = false;
            }
        }
        if (neighbor_Left != null)
        {
            if (alive == false)
            {
                neighbor_Left.gameObject.GetComponent<voxelSystem>().weight = 99999;
                neighbor_Left.gameObject.GetComponent<voxelSystem>().changeVar();
                neighbor_Left.gameObject.GetComponent<voxelSystem>().parentIsalive = false;
            }
        }
        if (neighbor_Back != null)
        {
            if (alive == false)
            {
                neighbor_Back.gameObject.GetComponent<voxelSystem>().weight = 99999;
                neighbor_Back.gameObject.GetComponent<voxelSystem>().changeVar();
                neighbor_Back.gameObject.GetComponent<voxelSystem>().parentIsalive = false;
            }

        }
    }
}

