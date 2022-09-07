namespace Ecommerces_MS
{
    public class User
    {

        public string Username { get; set; } = string.Empty; // username propertys


        public byte[]? PasswordHash { get; set; } // passwordhash
        public byte[]? PasswordSalt { get;  set; } // password salt

      

    }
}
