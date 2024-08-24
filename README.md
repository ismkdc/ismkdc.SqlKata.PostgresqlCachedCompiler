# PostgresqlCachedCompiler for SQLKata

`PostgresqlCachedCompiler` is a caching solution for SQLKata queries when working with PostgreSQL. This library caches queries after creating them, allowing for faster subsequent query executions by reusing the cached versions.

## Features

- **Query Caching:** Automatically caches generated SQL queries.
- **Improved Performance:** Reduces the overhead of generating SQL queries multiple times.
- **Seamless Integration:** Integrates directly with `QueryFactory` from SQLKata.

## Installation

Install the package via NuGet:

```bash
dotnet add package ismkdc.SqlKata.PostgresqlCachedCompiler
```

## Usage Example

To use the `PostgresqlCachedCompiler` with SQLKata and PostgreSQL, follow these simple steps:

```csharp
using SqlKata.Compilers;
using SqlKata.Execution;
using ismkdc.SqlKata.PostgresqlCachedCompiler;

// Create a new instance of the cached compiler
var compiler = new PostgresqlCachedCompiler();

// Use the cached compiler with QueryFactory
return new QueryFactory(connection, compiler);
