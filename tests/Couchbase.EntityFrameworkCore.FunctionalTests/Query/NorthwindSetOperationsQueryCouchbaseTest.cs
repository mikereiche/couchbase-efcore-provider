// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Couchbase.EntityFrameworkCore.FunctionalTests.Query;

public class NorthwindSetOperationsQueryCouchbaseTest : NorthwindSetOperationsQueryRelationalTestBase<
    NorthwindQueryCouchbaseFixture<NoopModelCustomizer>>
{
    public NorthwindSetOperationsQueryCouchbaseTest(
        NorthwindQueryCouchbaseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public override async Task Client_eval_Union_FirstOrDefault(bool async)
        // Client evaluation in projection. Issue #16243.
        => Assert.Equal(
            RelationalStrings.SetOperationsNotAllowedAfterClientEvaluation,
            (await Assert.ThrowsAsync<InvalidOperationException>(
                () => base.Client_eval_Union_FirstOrDefault(async))).Message);
}
