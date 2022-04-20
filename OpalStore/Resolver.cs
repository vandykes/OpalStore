using OpalStore.Commands;
using OpalStore.Queries;
using System;

namespace OpalStore
{
    /// <summary>
    /// Encapsulates the ability to generate known commands from input text.
    /// </summary>
    internal class Resolver
    {
        /// <summary>
        /// Parses the given <paramref name="command"/> into a known command.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static CommandBase Parse(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return null;

            var parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (parts[0])
            {
                case CommandTypes.GET:
                    return new GetKeyQuery(parts);
                case CommandTypes.SET:
                    return new SetKeyCommand(parts);
                case CommandTypes.COUNT:
                    return new GetCountQuery(parts);
                case CommandTypes.DELETE:
                    return new DeleteKeyCommand(parts);
                case CommandTypes.BEGIN:
                    return new BeginTransactionCommand(parts);
                case CommandTypes.COMMIT:
                    return new CommitTransactionCommand(parts);
                case CommandTypes.ROLLBACK:
                    return new RollbackTransactionCommand(parts);
                default:
                    return null;
            }
        }
    }
}
