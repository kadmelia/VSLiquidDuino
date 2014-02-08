using System;
using System.Management;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSLiquidDuino
{
    // Manage 16x2 LCD Screen connected to an Arduino UNO
    public class Screen
    {

        // Line 1 of screen
        public string[] lines
        {
            get; set;
        }

        // COM port
        private SerialPort port;

        // Constructor
        public Screen()
        {

            // Detect port in wich arduino is plugged on
            string portName = this.autodetectArduinoPort();
           
            // Instance corresponding SerialPort
            if (portName != "")
                port = new SerialPort(portName);
            
            // Create lines array
            lines = new string[2];

        }


        // Update screen
        public void update()
        {

            // Check Arduino had been found
            if (port == null)
                return;

            port.Open();

            if (port.IsOpen)
                port.Write((string)lines.GetValue(0) + (string) lines.GetValue(1) + "\n");

            port.Close();

        }

        // Set given LCD line
        public void setLine(int index, string text) {

            // Set text at exactly 16 char
            text = text + "                ";
            text = text.Substring(0, 16);
            
            lines.SetValue(text, index);

        }

        // Detect arduino com port
        private string autodetectArduinoPort() {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }

            return null;
        }

    }

}
