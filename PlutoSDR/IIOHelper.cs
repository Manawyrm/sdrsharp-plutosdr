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
                            attr.write(Value);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool SetAttribute(Device phy, string Channel, string Attribute, string Value)
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
