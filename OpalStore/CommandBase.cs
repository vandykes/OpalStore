namespace OpalStore
{
    /// <summary>
    /// Encapsulates a base class representation for the available commands.
    /// </summary>
    internal abstract class CommandBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets an output message.
        /// </summary>
        public string OutputMessage { get; set; }

        /// <summary>
        /// Gets the number of expected arguments.
        /// </summary>
        public abstract int ExpectedArgumentCount { get; }

        /// <summary>
        /// Gets the name of this command.
        /// </summary>
        public abstract string CommandName { get; }
        #endregion
    }

    public class CommandTypes
    {
        public const string GET = nameof(GET);
        public const string SET = nameof(SET);
        public const string COUNT = nameof(COUNT);
        public const string DELETE = nameof(DELETE);
        public const string BEGIN = nameof(BEGIN);
        public const string COMMIT = nameof(COMMIT);
        public const string ROLLBACK = nameof(ROLLBACK);
    }
}
