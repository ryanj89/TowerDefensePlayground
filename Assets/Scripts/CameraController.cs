using UnityEngine;

public class CameraController : MonoBehaviour 
{
	private bool cameraEnabled = true; // Camera toggle

    [Header("Pan Attributes")]

    public float panSpeed = 30f;
    public float panCameraThreshold = 10f;  // Distance from edge to activate camera panning


    [Header("Scroll Attributes")]

    public float scrollSpeed = 5f;
    public float scrollSmoothness = 0.8f;
    public float minY = 10f;
    public float maxY = 80f;



	void Update ()
    {
        // Toggle camera-panning with "esc" key
        if (Input.GetKeyDown(KeyCode.Escape))
            cameraEnabled = !cameraEnabled;

        if (!cameraEnabled)     // Early return
            return;

        // Camera Up
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panCameraThreshold)
		{
            if (transform.position.z >= 30f)
                return;
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}

		// Camera Down
		if (Input.GetKey("s") || Input.mousePosition.y <= panCameraThreshold)
		{
            if (transform.position.z <= -45f)
                return;
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}

		// Camera Left
		if (Input.GetKey("a") || Input.mousePosition.x <= panCameraThreshold)
		{
            if (transform.position.x <= 0)
                return;
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		// Camera Right
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panCameraThreshold)
		{
            if (transform.position.x >= 75f)
                return;
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

		//
		// Camera Zoom
		//
		// Get Scroll Input
		// Get Current Camera Position
		// Get New Camera Position
        // Is New Position Valid?
		// Update Position
		//
		float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;

        position.y -= scroll * 100 * scrollSpeed * Time.deltaTime;

        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = Vector3.Lerp(position, transform.position, scrollSmoothness); // Smooth Movement
	}
}
