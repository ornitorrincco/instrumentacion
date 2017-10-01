import serial
from time import sleep

arduino = serial.Serial('COM3', 9600)
accelerometer = []
giroscope = []
magnetoscope = []
data_array = []


def dOF9Razor(data):
    data_DOF = str(data).split(',')
    if len(data_DOF) == 9:
        giroscope = data_DOF[0:3]
        giroscope[0] = giroscope[0].split('$')[1]
        accelerometer = data_DOF[3:6]
        magnetoscope = data_DOF[6:9]
        magnetoscope[2] = magnetoscope[2].split("#")[0]
        # outputString = "acelerometer = " + accelerometer + ' giroscope = ' + giroscope + ' magnetoscope = ' + magnetoscope
        return accelerometer, giroscope, magnetoscope

while True:
    data_string = arduino.readline()
    try:
        acceleration, degree, magnetoscope = dOF9Razor(data_string)
    except:
        pass
