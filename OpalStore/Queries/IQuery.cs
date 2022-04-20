using OpalStore.DataContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpalStore.Queries
{
    /// <summary>
    /// An abstraction for a database query which returns a scalar value.
    /// </summary>
    internal interface IQuery
    {
        #region Public Methods
        /// <summary>
        /// Executes this query against the given database context.
        /// </summary>
        /// <param name="context">An abstraction representing the data layer.</param>
        /// <returns>The database value, if present.</returns>
        object ExecuteQuery(IContext context);
        #endregion
    }
}
