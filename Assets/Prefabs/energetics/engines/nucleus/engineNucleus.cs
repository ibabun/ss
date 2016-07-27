using UnityEngine;
using System.Collections;

public class engineNucleus : MonoBehaviour {

    public float Mass;
    public float FuelE;
    public float qubicRadius;
    public float test;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Vapor = Mass/(Time.deltaTime/100);
        qubicRadius = (FuelE / FuelE / FuelE);
        Mass = (qubicRadius*qubicRadius*qubicRadius)*FuelE;
        test = (Mathf.Pow(9f, (1f/3f)));
        Debug.Log(test);
    }
}



//myCollider.radius = 10f;
