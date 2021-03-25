import cv2
import pytesseract
import sys

pytesseract.pytesseract.tesseract_cmd = r"C:\\Program Files\\Tesseract-OCR\\tesseract.exe"

try:
    img = cv2.imread(sys.argv[1])
    text = pytesseract.image_to_string(img)
    if text is not "":
        print(text)
    else:
        print("No text !-!")
except IndexError:
    print("No file dropped !-!")
