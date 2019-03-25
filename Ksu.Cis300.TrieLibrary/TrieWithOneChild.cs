using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// stores if the trie is the end of the word
        /// </summary>
        private bool _isEmpty;

        /// <summary>
        /// the child of the trie
        /// </summary>
        private ITrie _child;
        
        /// <summary>
        /// The child's label
        /// </summary>
        private char _label;
        /// <summary>
        /// constructs a new trie with one child
        /// </summary>
        /// <param name="s">the given word</param>
        /// <param name="isEmpty">if the trie is the end of the word</param>
        public TrieWithOneChild(string s, bool isEmpty)
        {
            if (s[0] < 'a' || s[0] > 'z' || s.Equals(""))
            {
                throw new ArgumentException();
            }
            _isEmpty = isEmpty;
            _label = s[0];
            _child = new TrieWithNoChildren();
            _child = _child.Add(s.Substring(1));
        }

        /// <summary>
        /// Adds a word
        /// </summary>
        /// <param name="s">String to be added</param>
        /// <returns>the new trie</returns>
        public ITrie Add(string s)
        {

            if (s == "")
            {
                _isEmpty = true;
            }
            else if (_label == s[0])
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else if (_label != s[0])
            {
                return new TrieWithManyChildren(s, _isEmpty, _label, _child);
            }
            return this;
        }
        /// <summary>
        /// looks for a given word
        /// </summary>
        /// <param name="s">the word to be found</param>
        /// <returns>if the word was found</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isEmpty;
            }
            else if (s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
