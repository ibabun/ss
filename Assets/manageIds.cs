using UnityEngine;
using System.Collections;

public class manageIds : MonoBehaviour {
    public int nextID = 1;
    public int thisID;
	// Use this for initialization
	void Awake () {
	thisID = 0;
        nextID = thisID + 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
