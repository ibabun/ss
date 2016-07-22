using UnityEngine;
using System.Collections;

public class voxelSystem : MonoBehaviour
{
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



        //hitting front
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

   public void changeVar()
    {
        Destroy(neighbor_Right);
        Destroy(neighbor_Front);
        Destroy(neighbor_Left);
        Destroy(neighbor_Back);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
