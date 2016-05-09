using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace V2EX.UWP.Core.Tools
{
    class NetworkManager
    {
        private static NetworkManager _current;
        private int _network;

        public static NetworkManager Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new NetworkManager();
                }
                return _current;
            }
        }

        public string NetworkTitle
        {
            get
            {
                if (_network == 0)
                {
                    return "2G";
                }
                else if (_network == 1)
                {
                    return "3G";
                }
                else if (_network == 2)
                {
                    return "4G";
                }
                else if (_network == 3)
                {
                    return "WIFI";
                }
                else
                {
                    return "无网络连接";
                }
            }
        }

        public int Network
        {
            get
            {
                return _network;
            }
        }

        public event NetworkStatusChangedEventHandler NetworkStatusChanged;

        public NetworkManager()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
            _network = GetConnectionGeneration();
        }

        private void NetworkInformation_NetworkStatusChanged(object sender)
        {
            _network = GetConnectionGeneration();
            if (NetworkStatusChanged != null)
            {
                NetworkStatusChanged(this);
            }
        }

        private int GetConnectionGeneration()
        {
            try
            {
                ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
                if (profile.IsWwanConnectionProfile)
                {
                    WwanDataClass connectionClass = profile.WwanConnectionProfileDetails.GetCurrentDataClass();
                    switch (connectionClass)
                    {
                        case WwanDataClass.None:
                            return 4;
                        case WwanDataClass.Gprs:
                            return 0;
                        case WwanDataClass.Edge:
                            break;
                        case WwanDataClass.Umts:
                            break;
                        case WwanDataClass.Hsdpa:
                            break;
                        case WwanDataClass.Hsupa:
                            return 1;
                        case WwanDataClass.LteAdvanced:
                            return 2;
                        case WwanDataClass.Cdma1xRtt:
                            break;
                        case WwanDataClass.Cdma1xEvdo:
                            break;
                        case WwanDataClass.Cdma1xEvdoRevA:
                            break;
                        case WwanDataClass.Cdma1xEvdv:
                            break;
                        case WwanDataClass.Cdma3xRtt:
                            break;
                        case WwanDataClass.Cdma1xEvdoRevB:
                            break;
                        case WwanDataClass.CdmaUmb:
                            break;
                        case WwanDataClass.Custom:
                            break;
                        default:
                            break;
                    }
                }
                else if (profile.IsWlanConnectionProfile)
                {
                    return 3;
                }
                return 4;
            }
            catch (Exception)
            {
                return 4;   
            }
            //throw new NotImplementedException();
        }
    }
}
