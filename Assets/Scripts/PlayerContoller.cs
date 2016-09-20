using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerContoller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float tilt;
	public Boundary boundary;
	public AudioSource audioSource;

	public GameObject shot;
	public Transform shotSpawn;

	private float nextFrie = 0f;

	public float fireRate = 0.5f;

	void Update(){
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFrie) {
			nextFrie = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
		}
	}

	void Start(){
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		rb.velocity = movement*speed;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0f, 0f, rb.velocity.x * -tilt);
	}
}
