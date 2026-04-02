import requests
from bs4 import BeautifulSoup
import csv

url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html"

response = requests.get(url)
soup = BeautifulSoup(response.text, "html.parser")

books = soup.find_all("article", class_="product_pod")

data = []

for book in books:
    name = book.h3.a["title"]
    price = book.find("p", class_="price_color").text.replace("Â", "")
    rating = book.p["class"][1]

    data.append([name, rating, price])

# Save to CSV
with open("books.csv", "w", newline="", encoding="utf-8-sig") as file:
    writer = csv.writer(file)
    writer.writerow(["Book Name", "Rating", "Price"])
    writer.writerows(data)

print("Data saved to books.csv")

# Read CSV and display
print("\nBooks from CSV:\n")

with open("books.csv", "r", encoding="utf-8") as file:
    reader = csv.reader(file)
    for row in reader:
        print(row)