using UnityEngine;
using System.Collections;

public class voxelSystem_Dec : MonoBehaviour
{
    public float pressure = 0.0f;
    public float pressureCH = 0.0f;
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
    {

        if (neighbor_Right != null)
        {
            if (neighbor_Right.GetComponent<voxelSystem>().pressure != pressure)
            {
            neighbor_Right.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
            neighbor_Right.gameObject.GetComponent<voxelSystem>().changeVar();
        }

        }

        if (neighbor_Front != null)
        {
            if (neighbor_Front.GetComponent<voxelSystem>().pressure != pressure)
            {
                neighbor_Front.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Front.gameObject.GetComponent<voxelSystem>().changeVar();
            }

        }

        if (neighbor_Left != null)
        {
            if (neighbor_Left.GetComponent<voxelSystem>().pressure != pressure)
            {
                neighbor_Left.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Left.gameObject.GetComponent<voxelSystem>().changeVar();
            }

            
        }
        if (neighbor_Back != null)
        {
            if (neighbor_Back.GetComponent<voxelSystem>().pressure != pressure)
            {
                neighbor_Back.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                neighbor_Back.gameObject.GetComponent<voxelSystem>().changeVar();
            }
        }


    }

}
