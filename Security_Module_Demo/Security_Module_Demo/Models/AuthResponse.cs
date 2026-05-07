namespace Security_Module_Demo.Models
{
    public class AuthResponse
    {
        public string Message { get; set; }
        public bool IsAuthintcated { get; set; }
        public string Username { get; set; }
        public string Eamil { get; set; }

        public List<string> Roles { get; set; }

        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
