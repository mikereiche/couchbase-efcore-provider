using System.Text;

namespace Couchbase.EntityFrameworkCore.Metadata;

[AttributeUsage(AttributeTargets.Class)]
public class CouchbaseAttribute : Attribute
{
    private string _contextId;
    
    public CouchbaseAttribute(string bucket)
    {
        Bucket = bucket ?? throw new NullReferenceException(nameof(bucket));
    }
    
    public CouchbaseAttribute(string bucket, string scope) : this(bucket)
    {
        Scope = scope?? throw new NullReferenceException(nameof(scope));
    }
    
    public CouchbaseAttribute(string bucket, string scope, string collection) : this(bucket, scope)
    {
        Collection = collection ?? throw new NullReferenceException(nameof(collection));
    }
    
    public string Bucket { get; }

    public string Scope { get; } = "_default";

    public string Collection { get; } = "_default";

    public string GetContextId()
    {
        if (_contextId == null)
        {
            var contextBuilder = new StringBuilder();
            contextBuilder.Append(Bucket);
            contextBuilder.Append('.');
            contextBuilder.Append(Scope);
            contextBuilder.Append('.');
            contextBuilder.Append(Collection);
            _contextId = contextBuilder.ToString();
        }

        return _contextId;
    }
}