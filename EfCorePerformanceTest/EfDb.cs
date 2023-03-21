using Microsoft.EntityFrameworkCore;

namespace Persons;

public static class EfDb
{
    public static readonly Func<Context, IAsyncEnumerable<Person>> Read
        = EF.CompileAsyncQuery((Context context) => context.Persons);
}