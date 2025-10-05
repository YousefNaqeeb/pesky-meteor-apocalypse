from flask import Flask
import requests

app = Flask(__name__)

@app.route("/asteroids/")
def get_asteroids():
    url = "https://ssd-api.jpl.nasa.gov/sentry.api"
    response = requests.get(url)
    response = response.json()
    return response
if __name__ == "__main__":
    app.run()
