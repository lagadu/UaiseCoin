using System;
using System.Collections.Generic;
using System.Text;
using UaiseCoin.Utils;

namespace UaiseCoin.Model
{
    public class Block
    {
        public long Index { get; }
        public DateTime Timestamp { get; set; }
        public List<Transaction> Transactions { get; set; }
        public string ParentHash { get; }
        public int Proof { get; }

        public Block(long index, string parentHash, int proof)
        {
            Index = index;
            ParentHash = parentHash;
            Proof = proof;
            Transactions = new List<Transaction>();
        }

        public string GetHash()
        {
            var sha512 = new System.Security.Cryptography.HMACSHA512();
            var encoding = new UTF8Encoding();
            return Crypto.ToHex(sha512.ComputeHash(encoding.GetBytes(this.ToString())), true);
        }

        public override string ToString()
        {
            Transactions.Sort();
            var sb = new StringBuilder();
            sb.Append(Index);
            sb.Append(ParentHash);
            sb.Append(Proof);
            Transactions.ForEach(x =>
            {
                sb.Append(x.Amount);
                sb.Append(x.Receiver);
                sb.Append(x.Sender);
            });
            return sb.ToString();
        }
    }
}
