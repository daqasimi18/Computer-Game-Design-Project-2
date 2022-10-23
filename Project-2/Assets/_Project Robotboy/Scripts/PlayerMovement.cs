using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//borrowed from Roll-a-Ball tutorial
using TMPro;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;
	public float jumpSpeed;
	private float originalStepOffset;

	private CharacterController characterController;
	private float ySpeed;
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
        originalStepOffset = characterController.stepOffset;
		
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
		
		ySpeed += Physics.gravity.y * Time.deltaTime;

		if (characterController.isGrounded)
		{
			characterController.stepOffset = originalStepOffset;
			ySpeed = -0.5f;

			if (Input.GetButtonDown("Jump"))
		{
			ySpeed = jumpSpeed;
		}
		}
		else
		{
			characterController.stepOffset = 0;
		}

		

		Vector3 velocity = movementDirection * magnitude;
		velocity.y = ySpeed;



		characterController.Move(velocity * Time.deltaTime);
		
		if(movementDirection != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
			
			transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
		}
    }
	
	void SetCountText()
	{
		if (count<10)
		{
			countText.text = "Count:  " + count.ToString() + "/" + collectCount.ToString();
			//adds extra space to compensate for missing digit
		}
		else //if count is greater than or equal to 10
		{
			countText.text = "Count: " + count.ToString() + "/" + collectCount.ToString();
		}
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
