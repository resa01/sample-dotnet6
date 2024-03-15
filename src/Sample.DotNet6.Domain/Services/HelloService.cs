using System;
using System.Text;

namespace Sample.DotNet6.Domain.Services
{
    public interface IHelloService
    {
        string Hello(bool isHappy);
    }

    public class HelloService : IHelloService
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
        
                return Convert.ToHexString(hashBytes); // .NET 5 +
        
                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
        public string Hello(bool isHappy)
        {
            var hello = $"Hello";
            hello = CreateMD5(hello);

            if (isHappy)
                return $"{hello}, you seem to be happy today";
            return hello;
        }
    }
}
