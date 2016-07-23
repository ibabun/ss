using UnityEngine;
using System.Collections;

public class manageIds : MonoBehaviour {
    public int nextID = 1;
    public int thisID;
	// Use this for initialization
	void Start () {
	thisID = 0;
        nextID = thisID + 1;
        Debug.Log(nextID);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
