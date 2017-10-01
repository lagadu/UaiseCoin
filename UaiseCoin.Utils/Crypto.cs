using System.Text;

namespace UaiseCoin.Utils
{
    public static class Crypto
    {
        public static string ToHex(byte[] bytes, bool upperCase)
        {
            var result = new StringBuilder(bytes.Length * 2);

            foreach (var t in bytes)
            {
                result.Append(t.ToString(upperCase ? "X2" : "x2"));
            }

            return result.ToString();
        }
    }
}
