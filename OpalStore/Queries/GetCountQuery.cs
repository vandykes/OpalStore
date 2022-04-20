using OpalStore.DataContexts;

namespace OpalStore.Queries
{
    /// <summary>
    /// Represents a query to count the occurrences of a given value.
    /// </summary>
    internal class GetCountQuery : CommandBase, IQuery
    {
        #region Properties
        /// <summary>
        /// Gets the name of the query.
        /// </summary>
        public override string CommandName { get; } = CommandTypes.COUNT;

        /// <summary>
        /// Gets the number of expected arguments.
        /// </summary>
        public override int ExpectedArgumentCount { get; } = 2;

        /// <summary>
        /// Gets the key whose value will be retrieved from the data store.
        /// </summary>
        public string Value { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Instantates a <see cref="GetCountQuery"/>.
        /// </summary>
        /// <param name="arguments">The query's arguments.</param>
        public GetCountQuery(string[] arguments)
        {
            var argumentCount = arguments == null ? 0 : arguments.Length;
            if (argumentCount != this.ExpectedArgumentCount)
            {
                this.OutputMessage = $"{this.CommandName} expects {this.ExpectedArgumentCount} but received {argumentCount}";
                return;
            }
            this.Value = arguments[1];
        }
        #endregion

        #region IQuery Members
        /// <summary>
        /// Executes this query against the given database context.
        /// </summary>
        /// <param name="context">An abstraction representing the data layer.</param>
        /// <returns>The database value, if present.</returns>
        public object ExecuteQuery(IContext context)
        {
            return context.GetCount(this.Value);
        }
        #endregion
    }
}
