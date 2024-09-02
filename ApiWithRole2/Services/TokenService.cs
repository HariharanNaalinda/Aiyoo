using System.IO;
using System.Threading.Tasks;

namespace ApiWithRole2.Services
{
    public class TokenService
    {
        private readonly string _tokenFolderPath;

        public TokenService(string tokenFolderPath)
        {
            _tokenFolderPath = tokenFolderPath;
            if (!Directory.Exists(_tokenFolderPath))
            {
                Directory.CreateDirectory(_tokenFolderPath);
            }
        }

        public async Task SaveTokenAsync(string username, string token)
        {
            var filePath = Path.Combine(_tokenFolderPath, $"{username}.txt");
            await File.WriteAllTextAsync(filePath, token);
        }

        public async Task<string> GetTokenAsync(string username)
        {
            var filePath = Path.Combine(_tokenFolderPath, $"{username}.txt");
            if (File.Exists(filePath))
            {
                return await File.ReadAllTextAsync(filePath);
            }
            return null;
        }
    }
}
