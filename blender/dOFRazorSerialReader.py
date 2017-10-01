import serial
from time import sleep


def cleanInput(data_string):
    # if is not a string
    dataParsed = str(data_string)
    number = ''
    # get all the number of the string an concatenate them
    for character in dataParsed:
        if character.isdigit():
            number += character

    # return a string
    return number


arduino = serial.Serial('COM3', 9600)
accelerometer = []
giroscope = []
magnetoscope = []
while True:
    data = arduino.readline()
    data_DOF = str(data)
    giroscope = data_DOF.split(',')[0:3]
    eaccelerometer = data_DOF.split(',')[3:6]
    magnetoscope = data_DOF.split(',')[6:9]

    #data_clean = cleanInput(data)
    #outputString = "acelerometer = " + accelerometer + ' giroscope = ' + giroscope + ' magnetoscope = ' + magnetoscope
    print(giroscope)
