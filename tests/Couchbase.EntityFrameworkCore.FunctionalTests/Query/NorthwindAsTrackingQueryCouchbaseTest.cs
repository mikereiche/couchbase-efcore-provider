// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Couchbase.EntityFrameworkCore.FunctionalTests.Query;

public class NorthwindAsTrackingQueryCouchbaseTest : CouchbaseNorthwindAsNoTrackingQueryTestBase<NorthwindQueryCouchbaseFixture<NoopModelCustomizer>>
{
    public NorthwindAsTrackingQueryCouchbaseTest(NorthwindQueryCouchbaseFixture<NoopModelCustomizer> fixture)
        : base(fixture)
    {
    }
}
