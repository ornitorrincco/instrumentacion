import mathutils
import serial


def funcion(data,number2):
    data = str(data)
    number = ''
    for character in data:
        if character.isdigit():
            number += character
    number = int(number)
    if number2 != number:
        if number > 90:
            bpy.data.objects['DOF9'].location = bpy.data.objects["DOF9"].location + mathutils.Vector(
                (0.1 * number, 0, 0))
        else:
            bpy.data.objects['DOF9'].location = bpy.data.objects["DOF9"].location + mathutils.Vector(
                (-0.1 * number, 0, 0))
        number2 = number

    if number == 180:
        break
    bpy.ops.wm.redraw_timer(type='DRAW_WIN_SWAP', iterations=1)
    return number2

arduino = serial.Serial('COM3', 9600)
number2 = 0
contador = 0
while True:
    if contador = 30:
        break
    data_string = arduino.readline()
    try:
        number2 = funcion(data_string)
    except:
        contador = contador + 1
        pass

