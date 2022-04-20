using OpalStore.DataContexts;

namespace OpalStore.Commands
{
    /// <summary>
    /// Represents a command to begin a transaction scope.
    /// </summary>
    internal class BeginTransactionCommand : CommandBase, ICommand
    {
        #region Properties
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public override string CommandName { get; } = CommandTypes.SET;

        /// <summary>
        /// Gets the number of expected arguments.
        /// </summary>
        public override int ExpectedArgumentCount { get; } = 1;
        #endregion

        #region Constructors
        /// <summary>
        /// Instantates a <see cref="BeginTransactionCommand"/>.
        /// </summary>
        /// <param name="arguments">The command's arguments.</param>
        public BeginTransactionCommand(string[] arguments)
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
        public void ExecuteCommand(IContext context)
        {
            context.BeginTransaction();
        }
        #endregion
    }
}
