from flask import Flask
import requests
from waitress import serve

app = Flask(__name__)

@app.route("/asteroids/")
def get_asteroids():
    url = "https://ssd-api.jpl.nasa.gov/sentry.api"
    response = requests.get(url)
    return response.json()

if __name__ == "__main__":
    print("Starting Meteor Server on http://127.0.0.1:5000")
    serve(app, host="127.0.0.1", port=5000)
