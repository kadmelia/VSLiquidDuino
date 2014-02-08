using System.IO.Ports;

namespace VSLiquidDuino
{

    public class Screen
    {

        // Line 1 of screen
        private string line1;

        // Line 2 of screen
        private string line2;

        // COM port
        private SerialPort port;

        // Constructor
        public Screen(string portName)
        {

            port = new SerialPort(portName);

        }

        // Update screen
        public void update()
        {

            port.Open();

            if (port.IsOpen)
            {
                port.Write(line1 + line2 + "\n");
            }

            port.Close();

        }



    }
}