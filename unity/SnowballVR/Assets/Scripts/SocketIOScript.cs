using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json;

public class ChatData {
	public string id;
	public string msg;
};

public class SocketIOScript : MonoBehaviour {
	public string serverURL = "http://192.148.43.34:5000";

	protected Socket socket = null;
	protected List<string> chatLog = new List<string> (); 

	void Destroy() {
		DoClose ();
	}

	// Use this for initialization
	void Start () {
		DoOpen ();
//		if (socket != null) {
//			SendMessage ( "HelloWorld" );
//		}
//		socket.Emit ("message", "Hello there!");
		if (socket != null) {
			Debug.Log ("Socket exists.");
		} else {
			Debug.Log ("Socket DOESNT exist!");
		}

	}
	
	// Update is called once per frame
	void Update () {
//		lock (chatLog) {
//			if (chatLog.Count > 0) {
//				foreach (var s in chatLog) {
//					str = str + "\n" + s;
//				}
//				chatLog.Clear ();
//			}
//		}
//		socket.Emit ("message", "Hello there!");
//		Debug.Log("Debug printed!");
	}

	void DoOpen() {
		if (socket == null) {
			socket = IO.Socket (serverURL);
			socket.On (Socket.EVENT_CONNECT, () => {
				lock(chatLog) {
					// Access to Unity UI is not allowed in a background thread, so let's put into a shared variable
					chatLog.Add("Socket.IO connected.");
				}
			});
//			socket.On ("chat", (data) => {
//				string str = data.ToString();
//
//				ChatData chat = JsonConvert.DeserializeObject<ChatData> (str);
//				string strChatLog = "user#" + chat.id + ": " + chat.msg;
//
//				// Access to Unity UI is not allowed in a background thread, so let's put into a shared variable
//				lock(chatLog) {
//					chatLog.Add(strChatLog);
//				}
//			});
		}
	}

	void DoClose() {
		if (socket != null) {
			socket.Disconnect ();
			socket = null;
		}
	}

	void SendChat(string str) {
		if (socket != null) {
			socket.Emit ("chat", str);
		}
	}

	void SendMessage(string str) {
		if (socket != null) {
			socket.Emit ("message", str);
		}
	}
}
