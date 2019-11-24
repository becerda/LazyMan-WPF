using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LazyManWPF.Util
{
    class Props
    {

        public static string VLCLoc
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["VLCLocation"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["VLCLocation"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static int ProxyPort
        {
            get
            {
                try
                {
                    return Int32.Parse(Properties.Settings.Default["ProxyPory"].ToString());
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return 8050;
                }
            }

            set
            {
                Properties.Settings.Default["ProxyPort"] = string.Empty + value;
                Properties.Settings.Default.Save();
            }
        }

        public static string Password
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["Pass"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["Pass"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string BitRate
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["Bitrate"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["Bitrate"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string CDN
        {
            get
            {

                try
                {
                    return Properties.Settings.Default["CDN"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["CDN"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string FavNHLTeam
        {
            get
            {

                try
                {
                    return Properties.Settings.Default["NHLTeam"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["NHLTeam"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string FavMLBTeam
        {
            get
            {

                try
                {
                    return Properties.Settings.Default["MLBTeam"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["MLBTeam"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool PreferFrench
        {
            get
            {

                try
                {
                    return Boolean.Parse(Properties.Settings.Default["French"].ToString());
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return false;
                }
            }

            set
            {
                Properties.Settings.Default["French"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string SaveStreamLocation
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["SaveStreamLoc"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar;
                }
            }

            set
            {
                Properties.Settings.Default["SaveStreamLoc"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string StreamLinkArgs
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["StreamlinkArgs"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {

                }

                try
                {
                    string s = Properties.Settings.Default["LivestreamerArgs"].ToString();
                    Properties.Settings.Default["StreamlinkArgs"] = s;
                    return Properties.Settings.Default["StreamlinkArgs"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["StreamlinkArgs"] = value;
                try
                {
                    Properties.Settings.Default["LivestreamerArgs"] = null;
                }
                catch (SettingsPropertyNotFoundException ex)
                {

                }
            }
        }

        public static string[] StreamLinkArgsArray
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["StreamlinkArgs"].ToString().Split("[ ]+(?=([^\"]*\"[^\"]*\")*[^\"]*$)".ToCharArray());
                } catch(SettingsPropertyNotFoundException ex)
                {
                    return null;
                }
            }
        }

        public static string MediaPlayerArgs
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["MediaPlayerArgs"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["MediaPlayerArgs"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string[] MediaPlayerArgsArray
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["MediaPlayerArgs"].ToString().Split("[ ]+(?=([^\"]*\"[^\"]*\")*[^\"]*$)".ToCharArray());
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return null;
                }
            }
        }

        public static int RefreshRate
        {
            get
            {
                try
                {
                    return Int32.Parse(Properties.Settings.Default["RefreshRate"].ToString());
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return 0;
                }
            }

            set
            {
                Properties.Settings.Default["RefreshRate"] = string.Empty + value;
                Properties.Settings.Default.Save();
            }
        }

        public static string IP
        {
            get
            {
                try
                {
                    return Properties.Settings.Default["IP"].ToString();
                }
                catch (SettingsPropertyNotFoundException ex)
                {
                    return string.Empty;
                }
            }

            set
            {
                Properties.Settings.Default["IP"] = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
