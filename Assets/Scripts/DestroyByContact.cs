using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, Quaternion.identity);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, Quaternion.identity);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
