namespace RestApi.Configuration
{
    public class BasicAuthenticationSection
    {
        /// <summary>
        /// Gets the username for the basic authentication
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets the password for the basic authentication
        /// </summary>
        public string Password { get; set; }
    }
}
