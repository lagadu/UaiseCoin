using System.Text;
using UaiseCoin.Utils;

namespace UaiseCoin.BlockChain
{
    public class ProofOfWork
    {
        public int Prove(int lastProof)
        {
            var proof = 0;
            while (!Validate(proof, lastProof))
            {
                proof++;
            }
            return proof;
        }

        private bool Validate(int proof, int lastProof)
        {
            // we'll check for 3 leading zeros
            var guess = $"{lastProof}{proof}";
            var sha512 = new System.Security.Cryptography.HMACSHA512();
            var encoding = new UTF8Encoding();
            return Crypto.ToHex(sha512.ComputeHash(encoding.GetBytes(guess)), true).Substring(0, 3) == "000";
        }

        //private static IEnumerable<bool> IterateUntilFalse(Func<bool> condition)
        //{
        //    while (condition()) yield return true;
        //}

        //private static void While(Func<bool> condition, Action body)
        //{
        //    Parallel.ForEach(IterateUntilFalse(condition), ignored => body());
        //}
    }
}