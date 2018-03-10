import socket
import wifimanager
import time

server_name = "http://192.168.43.224/"


def http_post(url):
    _, _, host, path = url.split('/', 3)
    addr = socket.getaddrinfo(host, 5000)[0][-1]
    s = socket.socket()
    print (addr)
    s.connect(addr)
    s.send(bytes("helloWorld"))
    # s.send(bytes('POST /%s HTTP/1.0\r\nHost: %s\r\n\r\n' % (path, host), 'utf8'))
    # data = s.read()
    # print(str(data, 'utf8'), end='')
    s.close()


while True:
    http_post(server_name)
    print ("just sent!")
    time.sleep(5)
