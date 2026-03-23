import socket

HOST = '127.0.0.1'  # server IP
PORT = 65432        # server port

# Collect user information
print("Welcome to EasyDrive Registration!")
name = input("Name: ")
address = input("Address: ")
pps = input("PPS Number: ")
license_doc = input("Driving License Document: ")

# Connect to server
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect((HOST, PORT))

# Send data in format Name|Address|PPS|License
client.send(f"{name}|{address}|{pps}|{license_doc}".encode())

# Receive registration number from server
reg_no = client.recv(1024).decode()
print(f"\nRegistration successful! Your Registration Number is: {reg_no}")

client.close()