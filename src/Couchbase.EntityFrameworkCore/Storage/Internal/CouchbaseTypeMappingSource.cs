using Microsoft.EntityFrameworkCore.Storage;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Couchbase.EntityFrameworkCore.Storage.Internal;

public class CouchbaseTypeMappingSource: TypeMappingSource
{
    private readonly Dictionary<Type, CouchbaseTypeMapping> _clrTypeMappings;
    
    public CouchbaseTypeMappingSource(TypeMappingSourceDependencies dependencies) 
        : base(dependencies)
    {
        _clrTypeMappings
            = new Dictionary<Type, CouchbaseTypeMapping>
            {
                {
                    typeof(JsonObject), new CouchbaseTypeMapping(
                        typeof(JsonObject), jsonValueReaderWriter: dependencies.JsonValueReaderWriterSource.FindReaderWriter(typeof(JsonObject)))
                },
                {
                    typeof(string), new CouchbaseTypeMapping(
                        typeof(string), jsonValueReaderWriter: dependencies.JsonValueReaderWriterSource.FindReaderWriter(typeof(string)))
                },
                {
                    typeof(int), new CouchbaseTypeMapping(
                        typeof(int), jsonValueReaderWriter: dependencies.JsonValueReaderWriterSource.FindReaderWriter(typeof(int)))
                }
                //TODO add the rest of the type mappings
            };
    }

    protected override CoreTypeMapping? FindMapping(in TypeMappingInfo mappingInfo)
    {
        var clrType = mappingInfo.ClrType;
        if (clrType == null)
        {
            throw new InvalidOperationException($"Cannot map type {clrType}");
        }

        return _clrTypeMappings.TryGetValue(clrType, out var mapping) ? mapping : base.FindMapping(in mappingInfo);
    }
}