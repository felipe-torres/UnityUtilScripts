using UnityEngine;
using System.Collections;

/// <summary>
/// Utility script to control time scale
/// </summary>
public class PlaySpeedControl : MonoBehaviour
{	
	public float MaxTimeScale = 10f;
	public KeyCode SpeedUpKey = KeyCode.PageDown;
	public KeyCode SpeedDownKey = KeyCode.PageUp;
	public KeyCode SpeedResetKey = KeyCode.End;

	void Update ()
	{
		if (!Debug.isDebugBuild) 
		{
			return;
		}

		if (Input.GetKeyDown(SpeedUpKey))
		{
			// Increase speed
			AlterTimeIncrementally(1);
		}
		if (Input.GetKeyDown(SpeedDownKey))
		{
			// Decrease speed
			AlterTimeIncrementally(-1);
		}
		if (Input.GetKeyDown(SpeedResetKey))
		{
			// Reset speed
			AlterTime(1);
		}
	}

	/// <summary>
	/// Alters time scale to a given value
	/// </summary>
	private void AlterTime(float target)
	{
		Time.timeScale = target;
	}

	/// <summary>
	/// Alters time scale by a given increment (can be + or -). Clamp values so timescale can never be < 0 or > maxTimeScale. 
	/// </summary>
	private void AlterTimeIncrementally(float increment)
	{
		float target;
		if (Time.timeScale <= 1 && increment < 0) // Slow mo
			target = Time.timeScale * 0.5f;
		else if (Time.timeScale < 1 && increment > 0) // Fast
			target = Time.timeScale * 2f;
		else
			target = Mathf.Clamp(Time.timeScale + increment, 0, MaxTimeScale);
		Time.timeScale = target;
	}
}
