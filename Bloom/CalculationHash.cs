using System;
using System.Security.Cryptography;
using System.Text;

namespace Bloom
{
    public class CalculationHash
    {
        public Int32 MD5CalculationValue(String value)
        {
            Byte[] bytes = Encoding.UTF8.GetBytes(value);
            Byte[] hash = MD5Calculation(bytes);
            return CreateStringFromBytes(hash).GetHashCode();
        }
        private Byte[] MD5Calculation(Byte[] bytes)
        {
            var cryptoPrivider = new MD5CryptoServiceProvider();
            return cryptoPrivider.ComputeHash(bytes);
        }


        public Int32 SHA1CalculationValue(String value)
        {
            Byte[] bytes = Encoding.UTF8.GetBytes(value);
            Byte[] hash = SHA1Calculation(bytes);
            return CreateStringFromBytes(hash).GetHashCode();
        }
        private Byte[] SHA1Calculation(Byte[] bytes)
        {
            var cryptoPrivider = new SHA1CryptoServiceProvider();
            return cryptoPrivider.ComputeHash(bytes);
        }


        private String CreateStringFromBytes(Byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();

            for (Int32 i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i]);
            }
            return builder.ToString();
        }


        public Int32 StandartHashCalculationValue(String value)
        {
            return value.GetHashCode();
        }
    }
}
