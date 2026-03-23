import sqlite3
conn = sqlite3.connect("customers.db")
cursor = conn.cursor()
cursor.execute("SELECT * FROM customers")
print(cursor.fetchall())