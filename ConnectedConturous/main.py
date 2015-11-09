import cv2
import numpy as np

def main():
    np_img = cv2.imread('8.bmp', 0)
    
    blur = cv2.GaussianBlur(np_img,(5,5),0)
    ret3, th3 = cv2.threshold(blur, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)
    kernel = np.ones((3, 3), np.uint8)
    closing = cv2.morphologyEx(th3, cv2.MORPH_CLOSE, kernel, iterations=4)
    
    cont_img = closing.copy()
    contours, hierarchy = cv2.findContours(cont_img, cv2.RETR_EXTERNAL,
    cv2.CHAIN_APPROX_SIMPLE)
    
    for cnt in contours:
        area = cv2.contourArea(cnt)
        if area < 200 or area > 8000:
            continue

        if len(cnt) < 5:
            continue

        ellipse = cv2.fitEllipse(cnt)
        cv2.ellipse(np_img, ellipse, (155,155,0), 2)    
    
    while True:
        cv2.imshow('final result', np_img)    
        if cv2.waitKey(1) & 0xFF == ord('q'):
            break
    
if __name__ == '__main__':
    main()
