using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

namespace album
{
    internal class AuthenticationEncryptionConfiguration
    {
        public AuthenticationEncryptionConfiguration()
        {
        }

        public EncryptionAlgorithm EncryptionAlgorithm { get; set; }
        public ValidationAlgorithm ValidationAlgorithm { get; set; }
    }
}