using System;
using System.ComponentModel;
using System.Configuration;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UserPhotoByPath.Properties;

namespace UserPhotoByPath
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The LDAP provider string used to build the LDAP path
        /// </summary>
        public const string LDAPProvider = "LDAP://";

        private static string _domainName;
        private static string _userName;
        private static string _password;
        byte[] _photo;

        public MainForm()
        {
            InitializeComponent();

            // Retrieve values from app.config
            _domainName = ConfigurationManager.AppSettings["DomainName"];
            _userName = ConfigurationManager.AppSettings["Username"];
            _password = ConfigurationManager.AppSettings["Password"];
        }

        private void btnRetrieveDetail_Click(object sender, EventArgs e)
        {
            txtLdapPath.Enabled = picUser.Enabled = btnRetrieveDetail.Enabled = false;
            lblStatus.Text = "Please wait! Retrieving photo as per path...";
            bgwPhoto.RunWorkerAsync(txtLdapPath.Text.Trim());
        }

        private void bgwPhoto_DoWork(object sender, DoWorkEventArgs e)
        {
            var ldapPath = (string) e.Argument;
            _photo = GetUserPhotoByPath(ldapPath);
        }

        private void bgwPhoto_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtLdapPath.Enabled = picUser.Enabled = btnRetrieveDetail.Enabled = true;

            if (e.Error == null)
            {
                if (_photo != null)
                {
                    var ms = new MemoryStream(_photo);
                    picUser.Image = Image.FromStream(ms);
                    lblStatus.Text = "Photo retrieved from AD successfully!";
                }
                else
                {
                    lblStatus.Text = "Photo not found in AD.";
                    picUser.Image = Resources.no_photo;
                }
            }
            else
            {
                lblStatus.Text = "Error occured";
                MessageBox.Show(e.Error.ToString());
            }
        }

        #region Helpers
        
        /// <summary>
        /// Returns the user photo from AD
        /// </summary>
        /// <param name="sAMAccountName">The user sAMAccountName</param>
        /// <param name="imagePropertyName">The name of the property that hold the image</param>
        /// <returns>The photo bytes</returns>
        public static byte[] GetUserPhoto(string sAMAccountName, string imagePropertyName = "thumbnailPhoto")
        {
            // Init return value
            byte[] userPhoto = null;

            using (
                var entry = new DirectoryEntry(_domainName, _userName, _password,
                    AuthenticationTypes.FastBind | AuthenticationTypes.Secure))
            {
                // Search for username
                using (DirectorySearcher searcher = new DirectorySearcher(entry))
                {
                    // Filter results by SAMAccountName
                    searcher.Filter = string.Format("(SAMAccountName={0})", sAMAccountName);
                    searcher.PropertiesToLoad.Add(imagePropertyName);

                    // Search and return only one result
                    SearchResult result = searcher.FindOne();

                    // Check if the user exists
                    if (result == null)
                        throw new Exception(string.Format("User \"{0}\" not found", sAMAccountName));

                    // Check if the property exists and set it
                    if (result.Properties[imagePropertyName].Count != 0)
                        userPhoto = (byte[]) result.Properties[imagePropertyName][0];
                }
            }

            // Return user photo
            return userPhoto;
        }

        /// <summary>
        /// Returns the user photo from AD given the user LDAP path
        /// </summary>
        /// <param name="ldapPath">The user LDAP path</param>
        /// <param name="imagePropertyName">The name of the property that hold the image</param>
        /// <returns>The photo bytes</returns>
        public static byte[] GetUserPhotoByPath(string ldapPath, string imagePropertyName = "thumbnailPhoto")
        {
            // Init return value
            byte[] userPhoto = null;
            using (
                var entry = new DirectoryEntry(ldapPath, _userName, _password,
                    AuthenticationTypes.FastBind | AuthenticationTypes.Secure))
            {
                // Check if the property exists and set it
                if (entry.Properties[imagePropertyName].Count != 0)
                    userPhoto = (byte[]) entry.Properties[imagePropertyName][0];
            }

            // Return user photo
            return userPhoto;
        }

        #endregion
       
    }
}
