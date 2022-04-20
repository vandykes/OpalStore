using OpalStore.DataContexts;

namespace OpalStore.Commands
{
    /// <summary>
    /// Represents a command to commit a transaction scope.
    /// </summary>
    internal class CommitTransactionCommand : CommandBase, ICommand
    {
        #region Properties
        /// <summary>
        /// Gets the name of the query.
        /// </summary>
        public override string CommandName { get; } = CommandTypes.SET;

        /// <summary>
        /// Gets the number of expected arguments.
        /// </summary>
        public override int ExpectedArgumentCount { get; } = 1;
        #endregion

        #region Constructors
        /// <summary>
        /// Instantates a <see cref="CommitTransactionCommand"/>.
        /// </summary>
        /// <param name="arguments">The query's arguments.</param>
        public CommitTransactionCommand(string[] arguments)
        {
            var argumentCount = arguments == null ? 0 : arguments.Length;
            if (argumentCount != this.ExpectedArgumentCount)
            {
                this.OutputMessage = $"{this.CommandName} expects {this.ExpectedArgumentCount} but received {argumentCount}";
                return;
            }
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
            if (context.GetTtsLevel() == 1)
            {
                this.OutputMessage = "There are no pending transactions to commit.";
                return;
            }
            context.CommitTransaction();
        }
        #endregion
    }
}
