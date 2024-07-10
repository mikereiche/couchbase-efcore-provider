using Couchbase.EntityFrameworkCore.Infrastructure;
using Couchbase.EntityFrameworkCore.Infrastructure.Internal;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Couchbase.EntityFrameworkCore.Extensions;

public static class CouchbaseDbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder UseCouchbaseProvider<TNamedBucketProvider>(
        this DbContextOptionsBuilder optionsBuilder,
        ClusterOptions clusterOptions,
        Action<CouchbaseDbContextOptionsBuilder>? couchbaseOptionsAction = null) where TNamedBucketProvider : class, INamedBucketProvider
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);

        var extension = GetOrCreateExtension<TNamedBucketProvider>(optionsBuilder, clusterOptions);
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
        ConfigureWarnings(optionsBuilder);
        couchbaseOptionsAction?.Invoke(new CouchbaseDbContextOptionsBuilder(optionsBuilder, clusterOptions));

        return optionsBuilder;
    }

    internal static CouchbaseOptionsExtension<TNamedBucketProvider> GetOrCreateExtension<TNamedBucketProvider>(DbContextOptionsBuilder optionsBuilder,
        ClusterOptions clusterOptions) where TNamedBucketProvider : class, INamedBucketProvider
        => optionsBuilder.Options.FindExtension<CouchbaseOptionsExtension<TNamedBucketProvider>>()
            is CouchbaseOptionsExtension<TNamedBucketProvider> existing
            ? new CouchbaseOptionsExtension<TNamedBucketProvider>(existing)
            : new CouchbaseOptionsExtension<TNamedBucketProvider>(clusterOptions);

    internal static void ConfigureWarnings(DbContextOptionsBuilder optionsBuilder)
    {
        var coreOptionsExtension = optionsBuilder.Options.FindExtension<CoreOptionsExtension>()
                                    ?? new CoreOptionsExtension();

        coreOptionsExtension = coreOptionsExtension.WithWarningsConfiguration(
            coreOptionsExtension.WarningsConfiguration.TryWithExplicit(
                RelationalEventId.AmbientTransactionWarning, WarningBehavior.Throw));

        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(coreOptionsExtension);
    }
}