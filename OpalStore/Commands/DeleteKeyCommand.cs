using OpalStore.DataContexts;

namespace OpalStore.Commands
{
    /// <summary>
    /// Represents a command to delete a key from the store.
    /// </summary>
    internal class DeleteKeyCommand : CommandBase, ICommand
    {
        #region Properties
        /// <summary>
        /// Gets the name of the query.
        /// </summary>
        public override string CommandName { get; } = CommandTypes.SET;

        /// <summary>
        /// Gets the number of expected arguments.
        /// </summary>
        public override int ExpectedArgumentCount { get; } = 2;

        /// <summary>
        /// Gets the key whose value will be retrieved from the data store.
        /// </summary>
        public string Key { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Instantates a <see cref="DeleteKeyCommand"/>.
        /// </summary>
        /// <param name="arguments">The query's arguments.</param>
        public DeleteKeyCommand(string[] arguments)
        {
            var argumentCount = arguments == null ? 0 : arguments.Length;
            if (argumentCount != this.ExpectedArgumentCount)
            {
                this.OutputMessage = $"{this.CommandName} expects {this.ExpectedArgumentCount} but received {argumentCount}";
                return;
            }
            this.Key = arguments[1];
        }
        #endregion

        #region IQuery Members
        /// <summary>
        /// Executes this query against the given database context.
        /// </summary>
        /// <param name="context">An abstraction representing the data layer.</param>
        /// <returns>The database value, if present.</returns>
        public void ExecuteCommand(IContext context)
        {
            context.DeleteKey(this.Key);
        }
        #endregion
    }
}
