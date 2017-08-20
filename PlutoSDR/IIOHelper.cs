using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iio;
using System.Windows.Forms;

namespace SDRSharp.PlutoSDR
{
    class IIOHelper
    {
        public static bool SetAttribute(Device phy, string Channel, string Attribute, long Value)
        {
            /*MessageBox.Show("Channel: " + Channel + " - ");
            MessageBox.Show("Attr: " + Attribute);
            MessageBox.Show("Val: " + Value);*/

            foreach (Channel chn in phy.channels)
            {
                if (chn.attrs.Count == 0)
                    continue;

                //if (!chn.output)
                //    continue; 
                
                if (chn.id.Equals(Channel))
                {
                    foreach (Attr attr in chn.attrs)
                    {
                        //MessageBox.Show("1: " + attr.name + " - 2:" + Attribute);
                        if (attr.name.CompareTo(Attribute) == 0)
                        {
                            attr.write(Value);
                            return true;
                        }
                    }
                }
            }
            /*MessageBox.Show("not found Channel: " + Channel + " - ");
            MessageBox.Show("not found Attr: " + Attribute);
            MessageBox.Show("not found Val: " + Value);*/

            return false;
        }
        public static bool SetAttribute(Device phy, string Channel, string Attribute, string Value)
        {
            foreach (Channel chn in phy.channels)
            {
                if (chn.attrs.Count == 0)
                    continue;

                //if (!chn.output)
                //    continue;

                if (chn.id.Equals(Channel))
                {
                    foreach (Attr attr in chn.attrs)
                    {
                        if (attr.name.CompareTo(Attribute) == 0)
                        {
                            attr.write(Value);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static long GetAttribute(Device phy, string Channel, string Attribute)
        {
            foreach (Channel chn in phy.channels)
            {
                if (chn.attrs.Count == 0)
                    continue;

                if (chn.id.Equals(Channel))
                {
                    foreach (Attr attr in chn.attrs)
                    {
                        if (attr.name.CompareTo(Attribute) == 0)
                        {
                            return attr.read_long();
                        }
                    }
                }
            }
            return -1;
        }
        public static string GetAttributeString(Device phy, string Channel, string Attribute)
        {
            foreach (Channel chn in phy.channels)
            {
                if (chn.attrs.Count == 0)
                    continue;

                if (chn.id.Equals(Channel))
                {
                    foreach (Attr attr in chn.attrs)
                    {
                        if (attr.name.CompareTo(Attribute) == 0)
                        {
                            return attr.read();
                        }
                    }
                }
            }
            return null;
        }
        public static Channel FindChannel(Device phy, string Channel)
        {
            foreach (Channel chn in phy.channels)
            {
                if (chn.id.Equals(Channel))
                {
                    return chn;
                }
            }
            return null;
        }
    }
}
