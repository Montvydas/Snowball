# Snowball
This is an interactive VR / Google Cardboard based game of snowball fight. One of the main features it has is the ability to walk inside the game without additional hardware - it's all based on your phone! For throwing a snowball an additional controller is used (later move to a smartwatch).

Ignore the next steps:

# Server

## Setup

Create a Python environment for the project and install the dependencies to it.
```
virtualenv -p /usr/bin/python3 env
source env/bin/activate
pip install -r requirements.txt

# And deactive the environment when you're done
deactivate
```

When you want to run the server:
```
source env/bin/activate
FLASK_APP=server.py flask run
```

