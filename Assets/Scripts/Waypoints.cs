using UnityEngine;

public class Waypoints : MonoBehaviour
{
	public static Transform[] waypoints;

	// Find all child objects and load into 'waypoints'
	void Awake()
	{
		waypoints = new Transform[transform.childCount];

		for (int i = 0; i < waypoints.Length; i++)
		{
			waypoints[i] = transform.GetChild(i);
		}
	}
}
