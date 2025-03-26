using Microsoft.EntityFrameworkCore.Query;

namespace Couchbase.EntityFrameworkCore.Query.Internal;

public class CouchbaseQueryableMethodTranslatingExpressionVisitorFactory : IQueryableMethodTranslatingExpressionVisitorFactory
{
    private readonly QueryableMethodTranslatingExpressionVisitorDependencies _dependencies;

    public CouchbaseQueryableMethodTranslatingExpressionVisitorFactory(
        QueryableMethodTranslatingExpressionVisitorDependencies dependencies)
    {
        _dependencies = dependencies;
    }
    
    public QueryableMethodTranslatingExpressionVisitor Create(QueryCompilationContext queryCompilationContext) =>
        new CouchbaseQueryableMethodTranslatingExpressionVisitor(_dependencies, queryCompilationContext,
            subquery: false);
}

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2025 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/
