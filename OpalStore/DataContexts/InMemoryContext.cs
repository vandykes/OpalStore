using System.Collections.Generic;
using System.Linq;

namespace OpalStore.DataContexts
{
    /// <summary>
    /// Represents an in-memory data layer.
    /// </summary>
    internal class InMemoryContext : IContext
    {
        #region Properties
        private Stack<Dictionary<string, string>> ValueSets { get; } = new Stack<Dictionary<string, string>>();
        #endregion

        #region Constructors
        /// <summary>
        /// Instantiates a <see cref="InMemoryContext"/>.
        /// </summary>
        public InMemoryContext()
        {
            this.ValueSets.Push(new Dictionary<string, string>());
        }
        #endregion

        #region IContext Implementation        
        /// <summary>
        /// Gets the value for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key whose value will be retrieved.</param>
        /// <returns>The value of the given <paramref name="key"/></returns>
        public string GetKeyValue(string key)
        {
            foreach (var valueSet in this.ValueSets)
            {
                if (valueSet.TryGetValue(key, out var value))
                    return value;
            }
            return $"Key {key} not found.";
        }

        /// <summary>
        /// Sets the given <paramref name="value"/> for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key whose value will be set.</param>
        /// <param name="value">The value for the given key.</param>
        public void SetKeyValue(string key, string value)
        {
            // TODO: Handle TTS. Use separate add stack?

            this.ValueSets.Peek()[key] = value;
        }

        /// <summary>
        /// Gets a count of the occurrences of the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to count the occurrences of.</param>
        /// <returns>A value representing the number of times the given <paramref name="value"/> occurs.</returns>
        public int GetCount(string value)
        {
            int count = 0;
            foreach (var valueSet in this.ValueSets)
            {
                count += valueSet.Values.Count(c => c == value);
            }
            return count;
        }

        /// <summary>
        /// Deletes the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to delete.</param>
        public void DeleteKey(string key)
        {
            // TODO: Delete is assuming you're deleting from the current TTS scope.
            // TODO: Use separate delete stack?

            if (this.ValueSets.Peek().ContainsKey(key))
                this.ValueSets.Peek().Remove(key);
        }

        /// <summary>
        /// Adds a transaction scope.
        /// <seealso cref="CommitTransaction"/> as well as <seealso cref="RollbackTransaction"/>.
        /// </summary>
        public void BeginTransaction()
        {
            this.ValueSets.Push(new Dictionary<string, string>());
        }

        /// <summary>
        /// Commits a transaction scope.
        /// <seealso cref="BeginTransaction"/> as well as <seealso cref="RollbackTransaction"/>.
        /// </summary>
        public void CommitTransaction()
        {
            var latest = this.ValueSets.Pop();
            var older = this.ValueSets.Pop();

            latest.Concat(older.Where(kvp => !latest.ContainsKey(kvp.Key))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            this.ValueSets.Push(latest);
        }

        /// <summary>
        /// Rolls back a transaction scope.
        /// <seealso cref="BeginTransaction"/> as well as <seealso cref="CommitTransaction"/>.
        /// </summary>
        public void RollbackTransaction()
        {
            this.ValueSets.Pop();
        }

        /// <summary>
        /// Gets the current transaction scope level.
        /// </summary>
        /// <returns>A value representing the level of the current transaction scope.</returns>
        public int GetTtsLevel()
        {
            return this.ValueSets.Count;
        }
        #endregion

    }
}
