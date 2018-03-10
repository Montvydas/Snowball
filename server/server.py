from flask import Flask, render_template
from flask_socketio import SocketIO

app = Flask(__name__)
app.config['SECRET_KEY'] = 'secret!'
socketio = SocketIO(app)

@socketio.on('message')
def handle_message(message):
   print('received message: ' + message)


@socketio.on('client_connected')
def handle_client_connect_event(json):
   print('received json: {0}'.format(str(json)))


@socketio.on('connect')
def test_connect():
    print("connected")
   #socketio.emit('my response', {'data': 'Connected'})


@socketio.on('disconnect')
def test_disconnect():
   print('Client disconnected')

if __name__ == '__main__':
   socketio.run(app, ip="0.0.0.0", port="5000", debug=True)