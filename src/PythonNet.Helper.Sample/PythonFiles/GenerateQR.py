#pip install qrcode
import qrcode
img = qrcode.make(data)
img.save(fileName)