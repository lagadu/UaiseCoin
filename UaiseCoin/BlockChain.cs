using System.Collections.Generic;


namespace UaiseCoin
{
    public class BlockChain
    {
        public HashSet<UaiseCoin.> Blocks { get; set; }
        public HashSet<Transaction> Transactions { get; set; }

        public BlockChain()
        {
            Blocks = new HashSet<Block>();
            Transactions = new HashSet<Transaction>();
        }
    }
}
