using UnityEngine;
using System.Collections;

public class cameraRaycast : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown("space") && Physics.Raycast(ray, out hit, 100)) {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("asd" + hit.collider.gameObject.name);
            var targett = hit.collider.gameObject;
            targett.gameObject.GetComponent<voxelSystem>().changeVar();
            //targett.<voxelSystem>.cahngeVar ();



        }
        
    }
}