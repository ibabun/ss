using UnityEngine;
using System.Collections;

public class voxelSystem : MonoBehaviour
{
    public float pressure = 1;
    public float pressureCH = 1;
    public float pressureMax = 1.0f;
    public float pressureMin = -1.0f;
    public LayerMask mask = (1 << 29);
    public GameObject neighbor_Front;
    public GameObject neighbor_Right;
    public GameObject neighbor_Back;
    public GameObject neighbor_Left;
    //stitics for fininshing transfer
    public bool fFininsh = true;
    public bool rFininsh = true;
    public bool bFininsh = true;
    public bool lFininsh = true;
    public bool readyToChange = true;
    public float countdown = 1.0f;
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

    public void changeVar()
    {
        pressure = pressureCH;
        readyToChange = false;
        Invoke("changeVarGO", 0.3f);
        Invoke("changeVarGOChange", 2f);
    }

    public void changeVarGO()
    {

        this.GetComponent<Renderer>().materials[0].color = new Color(pressure, pressure, pressure);
        //Front_CV
        if (neighbor_Right != null && neighbor_Right.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Right.GetComponent<voxelSystem>().readyToChange)
            {
                if (neighbor_Right.GetComponent<voxelSystem>().pressure != pressureCH)
                {
                    rFininsh = false;
                    if (neighbor_Right.GetComponent<voxelSystem>().pressure < pressure)
                    {


                        neighbor_Right.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                        neighbor_Right.gameObject.GetComponent<voxelSystem>().changeVar();
                    }
                    if (neighbor_Right.GetComponent<voxelSystem>().pressure > pressure)
                    {
                        pressureCH = neighbor_Right.gameObject.GetComponent<voxelSystem>().pressure;
                        neighbor_Right.gameObject.GetComponent<voxelSystem>().changeVar();
                    }

                }

                if (neighbor_Right.GetComponent<voxelSystem>().pressureCH == pressure)
                {
                    rFininsh = true;
                }
            }
        }

        //Right_CV
        if (neighbor_Front != null && neighbor_Front.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Front.GetComponent<voxelSystem>().readyToChange)
            {
                if (neighbor_Front.GetComponent<voxelSystem>().pressure != pressureCH)
                {
                    fFininsh = false;
                    if (neighbor_Front.GetComponent<voxelSystem>().pressure < pressure)
                    {

                        neighbor_Front.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                        neighbor_Front.gameObject.GetComponent<voxelSystem>().changeVar();
                    }
                    if (neighbor_Front.GetComponent<voxelSystem>().pressure > pressure)
                    {
                        pressureCH = neighbor_Front.gameObject.GetComponent<voxelSystem>().pressure;
                        neighbor_Front.gameObject.GetComponent<voxelSystem>().changeVar();
                    }
                }

                if (neighbor_Front.GetComponent<voxelSystem>().pressureCH == pressure)
                {
                    fFininsh = true;
                }
            }
        }


        //Back_CV
        if (neighbor_Left != null && neighbor_Left.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Left.GetComponent<voxelSystem>().readyToChange) {
                if (neighbor_Left.GetComponent<voxelSystem>().pressure != pressureCH)
                {
                    lFininsh = false;
                    if (neighbor_Left.GetComponent<voxelSystem>().pressure < pressure)
                    {
                        neighbor_Left.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                        neighbor_Left.gameObject.GetComponent<voxelSystem>().changeVar();
                    }
                    if (neighbor_Left.GetComponent<voxelSystem>().pressure > pressure)
                    {
                        pressureCH = neighbor_Left.gameObject.GetComponent<voxelSystem>().pressure;
                        neighbor_Left.gameObject.GetComponent<voxelSystem>().changeVar();
                    }
                }
            }

            if (neighbor_Left.GetComponent<voxelSystem>().pressureCH == pressure)
            {
                lFininsh = true;
            }
        }


        //Left_CV
        if (neighbor_Back != null && neighbor_Back.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Back.GetComponent<voxelSystem>().readyToChange)
            {
                if (neighbor_Back.GetComponent<voxelSystem>().pressure != pressureCH)
                {
                    bFininsh = false;
                    if (neighbor_Back.GetComponent<voxelSystem>().pressure < pressure)
                    {
                        neighbor_Back.gameObject.GetComponent<voxelSystem>().pressureCH = pressure;
                        neighbor_Back.gameObject.GetComponent<voxelSystem>().changeVar();
                    }
                    if (neighbor_Back.GetComponent<voxelSystem>().pressure > pressure)
                    {
                        pressureCH = neighbor_Back.gameObject.GetComponent<voxelSystem>().pressure;
                        neighbor_Back.gameObject.GetComponent<voxelSystem>().changeVar();
                    }
                }
                if (neighbor_Back.GetComponent<voxelSystem>().pressureCH == pressure)
                {
                    bFininsh = true;
                }
            }
        }
        //if (fFininsh && rFininsh && bFininsh && lFininsh && readyToChange)
        //{
        //    CancelInvoke();
        //    Debug.Log(this.name + "invoked");
        //}
    }
    public void changeVarGOChange()
    {
        readyToChange = true;
        CancelInvoke();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
