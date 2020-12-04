//https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-client-socket-example
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading; 
using System.Collections;

// State object for receiving data from remote device.  
public class StateObject {  
    // Client socket.  
    public Socket workSocket = null;  
    // Size of receive buffer.  
    public const int BufferSize = 256;  
    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];  
    // Received data string.  
    public StringBuilder sb = new StringBuilder();  
}  
  
public class AsynchronousClient {  
    // The port number for the remote device.  
    private const int port = 8800;  
  
    // ManualResetEvent instances signal completion.  
    private static ManualResetEvent connectDone =
        new ManualResetEvent(false);  
    private static ManualResetEvent sendDone =
        new ManualResetEvent(false);  
    private static ManualResetEvent receiveDone =
        new ManualResetEvent(false);  
  
    // The response from the remote device.  
    private static String response = String.Empty;  
  
    private static void StartClient() {  
        // Connect to a remote device.  
        try {  
            // Establish the local endpoint for the socket.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
            IPAddress ipAddress = ipHostInfo.AddressList[0];  
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8800);
  
            // Create a TCP/IP socket.  
            Socket client = new Socket(ipAddress.AddressFamily,  
                SocketType.Stream, ProtocolType.Tcp);  
  
            // Connect to the remote endpoint.  
            client.BeginConnect( remoteEP,
                new AsyncCallback(ConnectCallback), client);  
            connectDone.WaitOne();  
  
            // Send test data to the remote device.  
            Send(client,"Hello world from socket client<EOF>");  
            sendDone.WaitOne();  
  
            // Receive the response from the remote device.  
            Receive(client);  
            receiveDone.WaitOne();  
  
            // Write the response to the console.  
            Console.WriteLine("Response received : {0}", response);  
  
            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);  
            client.Close();  
  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private static void ConnectCallback(IAsyncResult ar) {  
        try {  
            // Retrieve the socket from the state object.  
            Socket client = (Socket) ar.AsyncState;  
  
            // Complete the connection.  
            client.EndConnect(ar);  
  
            Console.WriteLine("Socket connected to {0}",  
                client.RemoteEndPoint.ToString());  
  
            // Signal that the connection has been made.  
            connectDone.Set();  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private static void Receive(Socket client) {  
        try {  
            // Create the state object.  
            StateObject state = new StateObject();  
            state.workSocket = client;  
  
            // Begin receiving the data from the remote device.  
            client.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,  
                new AsyncCallback(ReceiveCallback), state);  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private static void ReceiveCallback( IAsyncResult ar ) {  
        try {  
            // Retrieve the state object and the client socket
            // from the asynchronous state object.  
            StateObject state = (StateObject) ar.AsyncState;  
            Socket client = state.workSocket;  
  
            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);  
  
            if (bytesRead > 0) {  
                // There might be more data, so store the data received so far.  
            state.sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead));  
  
                // Get the rest of the data.  
                client.BeginReceive(state.buffer,0,StateObject.BufferSize,0,  
                    new AsyncCallback(ReceiveCallback), state);  
            } else {  
                // All the data has arrived; put it in response.  
                if (state.sb.Length > 1) {  
                    response = state.sb.ToString();  
                }  
                // Signal that all bytes have been received.  
                receiveDone.Set();  
            }  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  
  
    private static void Send(Socket client, String data) {  
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);  
  
        // Begin sending the data to the remote device.  
        client.BeginSend(byteData, 0, byteData.Length, 0,  
            new AsyncCallback(SendCallback), client);  
    }  
  
    private static void SendCallback(IAsyncResult ar) {  
        try {  
            // Retrieve the socket from the state object.  
            Socket client = (Socket) ar.AsyncState;  
  
            // Complete sending the data to the remote device.  
            int bytesSent = client.EndSend(ar);  
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);  
  
            // Signal that all bytes have been sent.  
            sendDone.Set();  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    } 

    public class DA11Model {
        static int MSG_IN_TOTAL_LENGTH_SIZE = 5;
        static int MSG_IN_FILLER_SIZE = 10;
        public BitArray MSG_IN_TOTAL_LENGTH = new BitArray(MSG_IN_TOTAL_LENGTH_SIZE);
        public BitArray MSG_IN_FILLER = new BitArray(MSG_IN_FILLER_SIZE);
        public BitArray MSG_IN_HEADER = new BitArray(MSG_IN_TOTAL_LENGTH_SIZE + MSG_IN_FILLER_SIZE);
        public BitArray MSG_IN_BODY = new BitArray(600);
        public BitArray MSG_PACKAGE = new BitArray(4096);
        public BitArray Append(BitArray current, BitArray after) 
        {
            var bools = new bool[current.Count + after.Count];
            current.CopyTo(bools, 0);
            after.CopyTo(bools, current.Count);
            return new BitArray(bools);
        }
        public void FromIntToBitArray(int numeral, ref BitArray bt) 
        {
            BitArray nbt = ToBinary(numeral);
            for (int i = 0; i < bt.Length; i++){
                bt.Set(i, nbt[i]);
            }
        }
        public BitArray ToBinary(int numeral)
        {
            return new BitArray(new[] { numeral });
        }

        public int ToNumeral(BitArray binary)
        {
            if (binary == null)
                throw new ArgumentNullException("binary");
            if (binary.Length > 32)
                throw new ArgumentException("must be at most 32 bits long");

            var result = new int[1];
            binary.CopyTo(result, 0);
            return result[0];
        }
        public byte ToByte(BitArray binary){
            if (binary == null)
                throw new ArgumentNullException("binary");
            if (binary.Length > 8)
                throw new ArgumentException("must be at most 8 bits long");

            var result = new byte[1];
            binary.CopyTo(result, 0);
            return result[0];
        }
        public void UsingBitArray()
        {
            DA11Model da11 = new DA11Model();
        
            da11.FromIntToBitArray(3, ref da11.MSG_IN_TOTAL_LENGTH);

            for (int i = 0; i < da11.MSG_IN_TOTAL_LENGTH.Count; i++) {
                Console.Write("{0, -6} ", da11.MSG_IN_TOTAL_LENGTH[i]);
            }

            Console.WriteLine();
            Console.WriteLine(da11.ToNumeral(da11.MSG_IN_TOTAL_LENGTH));

            da11.FromIntToBitArray(5, ref da11.MSG_IN_FILLER);

            for (int i = 0; i < da11.MSG_IN_FILLER.Count; i++) {
                Console.Write("{0, -6} ", da11.MSG_IN_FILLER[i]);
            }

            Console.WriteLine();

            da11.MSG_IN_HEADER = da11.Append(da11.MSG_IN_TOTAL_LENGTH, da11.MSG_IN_FILLER);
            for (int i = da11.MSG_IN_HEADER.Count - 1; i >= 0; i--) {
                Console.Write("{0, -6} ", da11.MSG_IN_HEADER[i]);
            }

            Console.WriteLine();
            Console.WriteLine(da11.ToNumeral(da11.MSG_IN_HEADER));

            da11.MSG_PACKAGE = da11.Append(da11.MSG_IN_HEADER, da11.MSG_IN_BODY);

            byte[] package = new byte[128];
            int k = 0;
            for (int i = 0; i < package.Length; i++) {
                BitArray pk = new BitArray(8);
                for (int j = 0; j < 8; j++){
                    try {
                        pk[j] = da11.MSG_PACKAGE[k + j];
                    } catch (ArgumentOutOfRangeException e) {
                        pk[j] = false;
                    }
                }
                k += 8;
                package[i] = da11.ToByte(pk);
            }

            Console.WriteLine();
            for (int l = 0; l < package.Length; l++)
            {
                Console.Write("{0:X} ",package[l]);    
            }
            Console.WriteLine();
            
        }
    }
  
    public static int Main(String[] args) { 
        DA11Model da11 = new DA11Model();
        da11.UsingBitArray();
//        StartClient();  
        return 0;  
    }  
}  