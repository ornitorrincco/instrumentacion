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
while True:
    data = arduino.readline()
    data_DOF = str(data)
    data_DOF = data_DOF.split(',')[0]
    #data_clean = cleanInput(data)
    print(data_DOF)
