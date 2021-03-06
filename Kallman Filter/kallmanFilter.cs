using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kallmanFilter : MonoBehaviour {


	// Use this for initialization
	void Start () {
		double dt = Time.deltaTime;

		//Modelo de transicion-estado
	//	Matrix A = Matrix (4,4);
	
		Matrix A = new Matrix([1,0,dt,0],
							[0,1,0,dt],
							[0,0,1,0],
							[0,0,0,1]);

		//modelo de Observacion
		Matrix H = new double[[1,0,0,0],[0,1,0,0]];
		 	
		//TODO(ornitorrincco):Jugar con las matrices de ruido
		//ruido Processo/estado 
		double vel_noise_std = 0.005;
		double pos_noise_std = 0.005;

		Matrix Q = new Matrix[[pos_noise_std*pos_noise_std,0,0,0],
								[0,pos_noise_std*pos_noise_std,0,0],
								[0,0, vel_noise_std*vel_noise_std,0],
								[0,0,0,vel_noise_std*vel_noise_std]];

		//Ruido Sensor/Medicion
		double measurement_noise_std = 0.5;
		double[] R = new double[measurement_noise_std* measurement_noise_std * Matrix.IdentityMatrix(2,2)];

		double[] x = new double(Matrix.ZeroMatrix(4,1));
		double[] sigma = new double[Matrix.IdentityMatrix(4,4)];

	}

	// Update is called once per frame
	void Update () {
		
	}
		
	Matrix predictState(Matrix A,Matrix x){
		Matrix x_p = Matrix.ZeroMatrix (4, 1);
		return x_p = A * x;
	}

	Matrix predictCovariance(Matrix A, Matrix sigma, Matrix Q){
		Matrix sigma_p = ((A*sigma)*(Matrix.Transpose(A))) + Q;
		return sigma_p;
	}
	Matrix calculateKalmanGain(Matrix sigma_p, Matrix H,Matrix R){
		Matrix firstElement = (sigma_p * (Matrix.Transpose (H)));
		Matrix secondElement = H * ((sigma_p * (Matrix.Transpose (H))) + R);
		Matrix k = firstElement * secondElement.Invert ();     
		return k;
	}

	Matrix correctState(Matrix z, Matrix x_p, Matrix k, Matrix H){
		/*z: Vector Medida
		 * x_p: Vector de estado Predicho
		 * k: Ganancia de kallman
		 * H: Modelo de Observacion
		 * return X:Vector estado Corregido como una matriz 4x1 
		 */
		Matrix x = Matrix.ZeroMatrix (4, 1);
		x = x_p + (z - H * x_p);
		return x;
	}
	Matrix correctCovariance(Matrix sigma_p, Matrix k, Matrix H){
		Matrix sigma = (Matrix.IdentityMatrix (4, 4) - k * H) * sigma_p;
		return sigma;
	}


}
