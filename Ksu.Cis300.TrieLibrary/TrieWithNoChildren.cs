using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// stores if the trie is the end of the word
        /// </summary>
        private bool _isEmpty = false;

        /// <summary>
        /// adds a word
        /// </summary>
        /// <param name="s">the woprd to be added</param>
        /// <returns>the new trie</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isEmpty = true;
            }
            else
            {
                return new TrieWithOneChild(s, _isEmpty);
            }
            return this;
        }
        /// <summary>
        /// searches for a word
        /// </summary>
        /// <param name="s">the word to be found</param>
        /// <returns>if the word was found</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isEmpty;
            }
            else
            {
                return false;
            }
        }
    }
}
