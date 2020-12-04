using System;
using System.Collections.Generic;
using System.Linq;


namespace MM.Util {
    public class MultiMap<TKey, TValue> //: IEnumerable<KeyValuePair<TKey, ValueItem<TKey, TValue>>> where TKey:IComparable<TKey>
    {
        
        public Dictionary<TKey, List<TValue>> dictionary;
        private List<TKey> listForEnumorator;

        public MultiMap()
        {
            try
            {
                Initialize();
            }
            catch (Exception ex)
            {
                throw new MultiMapException(ex, ex.Message);
            }
        }

        private void Initialize()
        {
            dictionary = new Dictionary<TKey, List<TValue>>();
            listForEnumorator = new List<TKey>();
        }

        /// <summary>
        /// Adds a record to the list mapped to the key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {

            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Add(value);
            }
            else
            {
                dictionary[key] = new List<TValue>();
                dictionary[key].Add(value);
            }

        }

        /// <summary>
        /// Returns a list of records with the specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<TValue> GetList(TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return new List<TValue>();
            }
        }

        /// <summary>
        /// Returns the number of records with the specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int countAtKey(TKey key)
        {
            return this.GetList(key).Count;
        }

        /// <summary>
        /// Removes the key and clears the list associated with it
        /// </summary>
        /// <param name="key"></param>
        public void removeKey(TKey key)
        {
            dictionary[key].Clear();
            dictionary.Remove(key);
        }

        /// <summary>
        /// Removes all instances of the value, regardless of key
        /// </summary>
        /// <param name="value"></param>
        public void removeValue(TValue value)
        {
            foreach(var key in dictionary.Keys.ToList())
            {
                this.removeValue(key, value, false);
            }
        }

        /// <summary>
        /// Removes one or all instances of value from the list at MultiMap[key]
        /// If removeOnlyOne, the first occurence will be deleted
        /// If removing the final item from MultiMap[key], the key will be deleted as well
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="removeOnlyOne"></param>
        public void removeValue(TKey key, TValue value, bool removeOnlyOne)
        {
            if (dictionary.ContainsKey(key))
            {
                if (removeOnlyOne)
                {
                    dictionary[key].Remove(value);
                }
                else
                {
                    dictionary[key].RemoveAll(v => EqualityComparer<TValue>.Default.Equals(v, value));
                }

                if(dictionary[key].Count == 0) { this.removeKey(key); }
            }
        }
    }
}

    /*
    public class MultiMapEnum : IEnumerator<KeyValuePair<TKey, ValueItem<TKey, TValue>>>
    {
        private MultiMap<TKey, TValue> multiMap;

        public KeyValuePair<TKey, ValueItem<TKey, TValue>> Current
        {
            get
            {
                return ;
            }
        }

        IEnumerator<KeyValuePair<TKey, ValueItem<TKey, TValue>>>.GetEnumerator(){
            return new MultiMapEnum(this);
        }
        KeyValuePair<TKey, ValueItem<TKey, TValue>> IEnumerator<KeyValuePair<TKey, ValueItem<TKey, TValue>>>.Current
        {
            return this.Current;
        }
    }*/

