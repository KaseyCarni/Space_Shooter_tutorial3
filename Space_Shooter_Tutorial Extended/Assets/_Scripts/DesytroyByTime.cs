using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesytroyByTime : MonoBehaviour {

    public float lifetime;

    void Start () {

        Destroy(gameObject, lifetime);

    }
	
	
	void Update () {
		
	}
}
