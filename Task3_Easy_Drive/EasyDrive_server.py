import socket
import sqlite3
import threading
import random

# --- Database setup ---
conn = sqlite3.connect("customers.db", check_same_thread=False)
cursor = conn.cursor()

# Create table if it doesn't exist
cursor.execute("""
CREATE TABLE IF NOT EXISTS customers (
    reg_no TEXT PRIMARY KEY,
    name TEXT,
    address TEXT,
    pps_number TEXT,
    driving_license TEXT
)
""")
conn.commit()

# --- Server setup ---
HOST = '127.0.0.1'  # localhost
PORT = 65432        # port to listen on

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((HOST, PORT))
server.listen()

print("Server started. Waiting for connections...")

def handle_client(client_socket, addr):
    print(f"Connected to {addr}")

    # Receive data from client
    data = client_socket.recv(1024).decode()
    # Expected format: Name|Address|PPS|License
    name, address, pps, license_doc = data.split("|")

    # Generate unique registration number
    reg_no = "ED" + str(random.randint(1000, 9999))

    # Store in database
    cursor.execute("INSERT INTO customers VALUES (?, ?, ?, ?, ?)",
                   (reg_no, name, address, pps, license_doc))
    conn.commit()

    # Send registration number back to client
    client_socket.send(reg_no.encode())
    print(f"Customer {name} registered with Reg No: {reg_no}")

    client_socket.close()

while True:
    client_socket, addr = server.accept()
    thread = threading.Thread(target=handle_client, args=(client_socket, addr))
    thread.start()