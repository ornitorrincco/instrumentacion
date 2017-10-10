using UnityEngine;
using System.Collections;

public class SerialReader : MonoBehaviour {

	void OnSerialLine(string line) {
		float smooth = 2.0F;
		string[] IMUData = line.Split(new char[]{','});
		//clean $ simbol from the first element
		string[] tempIMUData = IMUData[0].Split(new char[]{'$'});
		IMUData [0] = tempIMUData [1];
		//clean # simbol from the first element
		tempIMUData = IMUData[8].Split(new char[]{'#'});
		IMUData [8] = tempIMUData [0];

		Vector3 giroscopio = new Vector3(float.Parse(IMUData[0]),float.Parse(IMUData[1]),float.Parse(IMUData[2]));
		Vector3 acelerometer = new Vector3(float.Parse(IMUData[3]),float.Parse(IMUData[4]),float.Parse(IMUData[5]));
		Vector3 magnetoscope = new Vector3(float.Parse(IMUData[6]),float.Parse(IMUData[7]),float.Parse(IMUData[8]));

		Quaternion target = Quaternion.Euler(giroscopio);
		transform.rotation = target;// Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		print(giroscopio);

		/*  
		//FOR DEBUG
		print ("Giroscopio: " + IMUData[0] + " " + IMUData[1] + " " + IMUData[2] + "\\\n" +
			"Acelerometer: "  + IMUData[3] + " " + IMUData[4] + " " + IMUData[5] + "\\n " + 
			"Magnetoscope: "  + IMUData[6] + " " + IMUData[7] + " " + IMUData[8]);

		*/
	}

}