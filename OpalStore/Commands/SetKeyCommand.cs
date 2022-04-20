using OpalStore.DataContexts;

namespace OpalStore.Commands
{
    /// <summary>
    /// Represents a command to set a key's value in the store.
    /// </summary>
    internal class SetKeyCommand : CommandBase, ICommand
    {
        #region Properties
        /// <summary>
        /// Gets the name of the query.
        /// </summary>
        public override string CommandName { get; } = CommandTypes.SET;

        /// <summary>
        /// Gets the number of expected arguments.
        /// </summary>
        public override int ExpectedArgumentCount { get; } = 3;

        /// <summary>
        /// Gets the key whose value will be retrieved from the data store.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the value for the given key.
        /// </summary>
        public string Value { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Instantates a <see cref="SetKeyCommand"/>.
        /// </summary>
        /// <param name="arguments">The query's arguments.</param>
        public SetKeyCommand(string[] arguments)
        {
            var argumentCount = arguments == null ? 0 : arguments.Length;
            if (argumentCount != this.ExpectedArgumentCount)
            {
                this.OutputMessage = $"{this.CommandName} expects {this.ExpectedArgumentCount} but received {argumentCount}";
                return;
            }
            this.Key = arguments[1];
            this.Value = arguments[2];
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
            context.SetKeyValue(this.Key, this.Value);
        }
        #endregion
    }
}
