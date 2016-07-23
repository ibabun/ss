using UnityEngine;
using System.Collections;

public class voxelSystem : MonoBehaviour
{
    public float pressure = 1;
    public float pressureCH = 1;
    public float pressureMax = 1.0f;
    public float pressureMin = -1.0f;
    public LayerMask mask = (1 << 29);
    public voxelSystem neighbor_Front;
    public voxelSystem neighbor_Right;
    public voxelSystem neighbor_Back;
    public voxelSystem neighbor_Left;
    //stitics for fininshing transfer
    public bool fFininsh = true;
    public bool rFininsh = true;
    public bool bFininsh = true;
    public bool lFininsh = true;
    //stitics for remembering accsesing neighbor 
    public bool fAccses = true;
    public bool rAccses = true;
    public bool bAccses = true;
    public bool lAccses = true;

    public bool readyToChange = true;
    //timer for allow change/accses
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
            neighbor_Front = hitF.collider.gameObject.GetComponent<voxelSystem>();
            // Debug.Log(this.name + "hit_" + hitF.collider.gameObject);
        }

        //hitting right
        RaycastHit hitR;
        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, out hitR, 1, mask.value))
        {
            neighbor_Right = hitR.collider.gameObject.GetComponent<voxelSystem>();
        }

        //hitting back
        RaycastHit hitB;
        Vector3 back = transform.TransformDirection(Vector3.back);
        if (Physics.Raycast(transform.position, back, out hitB, 1, mask.value))
        {
            neighbor_Back = hitB.collider.gameObject.GetComponent<voxelSystem>();
        }

        //hitting left
        RaycastHit hitL;
        Vector3 left = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, left, out hitL, 1, mask.value))
        {
            neighbor_Left = hitL.collider.gameObject.GetComponent<voxelSystem>();
        }

    }

    public void changeVar()
    {
        pressure = pressureCH;
        readyToChange = false;
        Invoke("changeVarGO", 0.2f);
        Invoke("changeVarGOChange", 2f);
    }

    public void changeVarGO()
    {
        //get Accses to neighbor's (this how we understand with neighbor is accsesing)
        this.GetComponent<Renderer>().materials[0].color = new Color(pressure, pressure, pressure);
        //Front_CV
        if (neighbor_Right != null && neighbor_Right.readyToChange) //&& neighbor_Right.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Right.pressure != pressureCH && neighbor_Right.rAccses)
            {
                rFininsh = false;
                if (neighbor_Right.pressure < pressure)
                {

                    neighbor_Right.pressureCH = pressure;
                    neighbor_Right.changeVar();
                }
                if (neighbor_Right.pressure > pressure)
                {
                    neighbor_Right.pressureCH = pressure;
                    neighbor_Right.changeVar();
                }
                neighbor_Right.lAccses = false;
            }

            if (neighbor_Right.pressureCH == pressure)
            {

                rFininsh = true;
            }

        }

        //Right_CV
        if (neighbor_Front != null && neighbor_Front.readyToChange)//&& neighbor_Front.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Front.pressure != pressureCH && neighbor_Front.fAccses)
            {
                fFininsh = false;
                if (neighbor_Front.pressure < pressure)
                {

                    neighbor_Front.pressureCH = pressure;
                    neighbor_Front.changeVar();
                }
                if (neighbor_Front.pressure > pressure)
                {
                    neighbor_Front.pressureCH = pressure;
                    neighbor_Front.changeVar();
                }

                neighbor_Front.bAccses = false;
            }

            if (neighbor_Front.pressureCH == pressure)
            {
                fFininsh = true;
            }

        }


        //Back_CV
        if (neighbor_Left != null && neighbor_Left.readyToChange)//&& neighbor_Left.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Left.pressure != pressureCH && neighbor_Left.lAccses)
            {
                lFininsh = false;
                if (neighbor_Left.pressure < pressure)
                {
                    neighbor_Left.pressureCH = pressure;
                    neighbor_Left.changeVar();
                }
                if (neighbor_Left.pressure > pressure)
                {
                    neighbor_Left.pressureCH = pressure;
                    neighbor_Left.changeVar();
                }
            }

            neighbor_Left.rAccses = false;

            if (neighbor_Left.pressureCH == pressure)
            {
                lFininsh = true;
            }
        }


        //Left_CV
        if (neighbor_Back != null && neighbor_Back.readyToChange)//&& neighbor_Back.GetComponent<voxelSystem>() != null)
        {
            if (neighbor_Back.pressure != pressureCH && neighbor_Back.bAccses)
            {
                bFininsh = false;
                if (neighbor_Back.pressure < pressure)
                {
                    neighbor_Back.pressureCH = pressure;
                    neighbor_Back.changeVar();
                }
                if (neighbor_Back.pressure > pressure)
                {
                    neighbor_Back.pressureCH = pressure;
                    neighbor_Back.changeVar();
                }
            }

            neighbor_Back.fAccses = false;

            if (neighbor_Back.pressureCH == pressure)
            {
                bFininsh = true;
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
        fAccses = true;
        rAccses = true;
        bAccses = true;
        lAccses = true;
        readyToChange = true;
        CancelInvoke();
    }

}
