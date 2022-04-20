## Roadmap For If I Had Two More Hours

> 0. Unit tests

I believe I've written this in a way that allows for mocks and I feel a sense of shame that I'm handing this over without unit tests.

> 1. Add support for data types other than strings

Generics of ``<T>`` seem like a go-to candidate for solving the issue of how everything is typed as a ``string``

> 2. Implement IoC/dependency injection

It would be nice to inject a database context into a constructor instead of having to pass the database context around.

> 3. Implement support for more durable data providers

Entity Framework is nice as it even provides an in-memory context, but beyond that it would be nice to support a data provider which could persist the data to disk.

> 4. Consider different data structure than a stack of dictionaries

I'm not certain what some good candidates would be and I'm going to need to give this some thought. An initial thought exercise on it has me considering a linked list for each key, as you could conceptually move backwards from the ``head`` node with respect to handling transaction scopes, but is it better? Is this a backtracking problem?

> 5. Settle on a better design

In a Web API, I think something like the CQRS pattern would lend itself well.

> 6.  Give some thought to how the concept of a transaction scope would work within a Web API

If this was a Web API and not a console app, the idea of a transaction scope is a fun design consideration. The thing that immediately comes to mind is that the object would have some ever-incrementing version identifier in the database, which fits the spirit of the requirement but it isn't a transaction scope per se.

> 7.  Quality of life changes

This is a console app, so we could pass command line arguments to avoid having to go into the full REPL. Additionally, a HELP command would be nice, as well as a proper QUIT command.