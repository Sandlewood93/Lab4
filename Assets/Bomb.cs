using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine (Die());
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public IEnumerator Die()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
