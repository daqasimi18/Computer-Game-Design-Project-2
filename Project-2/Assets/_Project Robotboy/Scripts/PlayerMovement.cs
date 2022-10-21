using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//borrowed from Roll-a-Ball tutorial
using TMPro;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;

	private CharacterController characterController;
	//lines borrowed from Roll-a-Ball tutorial
	private int count;
	public GameObject CollectParent;
	private int collectCount;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
		
		//lines borrowed from Roll-a-Ball tutorial
		count = 0;
		collectCount = CollectParent.transform.childCount;
		SetCountText();
		winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		
		Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
		float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
		movementDirection.Normalize();
		
		characterController.SimpleMove(movementDirection * magnitude);
		
		if(movementDirection != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
			
			transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
		}
    }
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString() + "/" + collectCount.ToString();
		if (count>=collectCount)
		{
			winTextObject.SetActive(true);
			//restartButton.SetActive(true);
		}
	}
	
	//from Roll-a-Ball tutorial
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Collect"))
		{
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
		}
	}
}
