using UnityEngine;
using System.Collections;

public class voxelStatus : MonoBehaviour {
    public voxelSystem VoxSys;
    //public voxelSystem VoxSys;
    //public voxelSystem VoxSys;
    // Use this for initialization
    void Start () {
        VoxSys = this.GetComponent<voxelSystem>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
