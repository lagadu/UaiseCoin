using System;
using System.Collections.Generic;
using UaiseCoin.Model;

namespace UaiseCoin.BlockChain
{
    public class BlockChain
    {
        public List<Block> Blocks { get; set; }
        public List<Transaction> Transactions { get; set; }
        public long LastBlock { get; set; }

        public BlockChain()
        {
            Blocks = new List<Block>();
            Transactions = new List<Transaction>();

            // create first block
            Blocks.Add(CreateBlock(string.Empty, 100));
        }

        private Block CreateBlock(string previousHash, int proof)
        {
            var newBlock = new Block(Blocks.Count + 1, previousHash, proof);
            newBlock.Transactions.AddRange(Transactions);
            Transactions.Clear();
            return newBlock;
        }

        private long CreateTransaction(Guid sender, Guid receiver, decimal amount)
        {
            Transactions.Add(new Transaction(sender, receiver, amount));
            return LastBlock++;
        }

        private static int Hash(Block block)
        {
            return block.GetHashCode();
        }
    }
}
