namespace OpalStore.DataContexts
{
    /// <summary>
    /// An abstraction for a data layer provider.
    /// </summary>
    internal interface IContext
    {
        #region Public Members
        /// <summary>
        /// Gets the value for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key whose value will be retrieved.</param>
        /// <returns>The value of the given <paramref name="key"/></returns>
        string GetKeyValue(string key);

        /// <summary>
        /// Gets a count of the occurrences of the given <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to count the occurrences of.</param>
        /// <returns>A value representing the number of times the given <paramref name="value"/> occurs.</returns>
        int GetCount(string value);

        /// <summary>
        /// Sets the given <paramref name="value"/> for the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key whose value will be set.</param>
        /// <param name="value">The value for the given key.</param>
        void SetKeyValue(string key, string value);

        /// <summary>
        /// Deletes the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to delete.</param>
        void DeleteKey(string key);

        /// <summary>
        /// Adds a transaction scope.
        /// <seealso cref="CommitTransaction"/> as well as <seealso cref="RollbackTransaction"/>.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits a transaction scope.
        /// <seealso cref="BeginTransaction"/> as well as <seealso cref="RollbackTransaction"/>.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Rolls back a transaction scope.
        /// <seealso cref="BeginTransaction"/> as well as <seealso cref="CommitTransaction"/>.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Gets the current transaction scope level.
        /// </summary>
        /// <returns>A value representing the level of the current transaction scope.</returns>
        int GetTtsLevel();
        #endregion
    }
}
