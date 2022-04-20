using OpalStore.DataContexts;

namespace OpalStore.Commands
{
    internal interface ICommand
    {
        #region Public Methods
        /// <summary>
        /// Executes this command against the given database context.
        /// </summary>
        /// <param name="context">An abstraction representing the data layer.</param>
        void ExecuteCommand(IContext context);
        #endregion
    }
}
