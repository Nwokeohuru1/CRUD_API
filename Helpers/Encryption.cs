using Microsoft.AspNetCore.DataProtection;
namespace UserAPI.Helpers
{
    public class Encryption
    {
        private readonly IDataProtector _dataProtector;
        private readonly IConfiguration _config;
        public Encryption(IDataProtectionProvider dataProtector, IConfiguration config)
        {
            _config = config;
            _dataProtector = dataProtector.CreateProtector(_config.GetSection("EncryptKey:Key").Value);
        }

        public string Encrypt(string password)
        {
           var data = _dataProtector.Protect(password);
            return data;
        }
        public string Decrypt(string password)
        {
            var data = _dataProtector.Unprotect(password);
            return data;
        }
    }
}
