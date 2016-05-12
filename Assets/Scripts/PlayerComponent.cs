using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour {
	private int count;
	public int speed;
	private Rigidbody2D rb2d;
	public Text countText;
	public Text winText;
	// Use this for initialization
	void Start () 
	{	count = 0;
		rb2d = GetComponent<Rigidbody2D> ();
		winText.text = "";
		setCountText ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);

		

	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText ();
			if (count >= 8)
			{
				winText.text = "You Win !";

			}
		}
	}
	void setCountText(){

		countText.text = "Count :" + count; 
	}
}
