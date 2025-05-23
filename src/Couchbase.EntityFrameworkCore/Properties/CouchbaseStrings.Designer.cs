// <auto-generated />

using System;
using System.Reflection;
using System.Resources;
using System.Threading;
using Couchbase.EntityFrameworkCore.Diagnostics;
using Couchbase.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Couchbase.EntityFrameworkCore.Utils;
using Couchbase.EntityFrameworkCore.Internal;

#nullable enable

namespace Couchbase.EntityFrameworkCore.Properties
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static class CouchbaseStrings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Couchbase.EntityFrameworkCore.Properties.CouchbaseStrings", typeof(CouchbaseStrings).Assembly);

        /// <summary>
        ///     Couchbase cannot apply aggregate operator '{aggregateOperator}' on expressions of type '{type}'. Convert the values to a supported type, or use LINQ to Objects to aggregate the results on the client side.
        /// </summary>
        public static string AggregateOperationNotSupported(object? aggregateOperator, object? type)
            => string.Format(
                GetString("AggregateOperationNotSupported", nameof(aggregateOperator), nameof(type)),
                aggregateOperator, type);

        /// <summary>
        ///     Translating this query requires the SQL APPLY operation, which is not supported on Couchbase.
        /// </summary>
        public static string ApplyNotSupported
            => GetString("ApplyNotSupported");

        /// <summary>
        ///     Translating this operation requires the 'DEFAULT', which is not supported on Couchbase.
        /// </summary>
        public static string DefaultNotSupported
            => GetString("DefaultNotSupported");

        /// <summary>
        ///     '{entityType1}.{property1}' and '{entityType2}.{property2}' are both mapped to column '{columnName}' in '{table}', but are configured with different SRIDs.
        /// </summary>
        public static string DuplicateColumnNameSridMismatch(object? entityType1, object? property1, object? entityType2, object? property2, object? columnName, object? table)
            => string.Format(
                GetString("DuplicateColumnNameSridMismatch", nameof(entityType1), nameof(property1), nameof(entityType2), nameof(property2), nameof(columnName), nameof(table)),
                entityType1, property1, entityType2, property2, columnName, table);

        /// <summary>
        ///     Cannot use table '{table}' for entity type '{entityType}' since it is being used for entity type '{otherEntityType}' and entity type '{entityTypeWithSqlReturningClause}' is configured to use the SQL RETURNING clause, but entity type '{entityTypeWithoutSqlReturningClause}' is not.
        /// </summary>
        public static string IncompatibleSqlReturningClauseMismatch(object? table, object? entityType, object? otherEntityType, object? entityTypeWithSqlReturningClause, object? entityTypeWithoutSqlReturningClause)
            => string.Format(
                GetString("IncompatibleSqlReturningClauseMismatch", nameof(table), nameof(entityType), nameof(otherEntityType), nameof(entityTypeWithSqlReturningClause), nameof(entityTypeWithoutSqlReturningClause)),
                table, entityType, otherEntityType, entityTypeWithSqlReturningClause, entityTypeWithoutSqlReturningClause);

        /// <summary>
        ///     Couchbase does not support this migration operation ('{operation}'). See https://go.microsoft.com/fwlink/?LinkId=723262 for more information and examples.
        /// </summary>
        public static string InvalidMigrationOperation(object? operation)
            => string.Format(
                GetString("InvalidMigrationOperation", nameof(operation)),
                operation);

        /// <summary>
        ///     Couchbase version {CouchbaseVersion} is being used, but version 3.38.0 or higher is required for querying into JSON collections.
        /// </summary>
        public static string QueryingIntoJsonCollectionsNotSupported(object? CouchbaseVersion)
            => string.Format(
                GetString("QueryingIntoJsonCollectionsNotSupported", nameof(CouchbaseVersion)),
                CouchbaseVersion);

        /// <summary>
        ///     Generating idempotent scripts for migrations is not currently supported for Couchbase. See https://go.microsoft.com/fwlink/?LinkId=723262 for more information and examples.
        /// </summary>
        public static string MigrationScriptGenerationNotSupported
            => GetString("MigrationScriptGenerationNotSupported");

        /// <summary>
        ///     Couchbase does not support expressions of type '{type}' in ORDER BY clauses. Convert the values to a supported type, or use LINQ to Objects to order the results on the client side.
        /// </summary>
        public static string OrderByNotSupported(object? type)
            => string.Format(
                GetString("OrderByNotSupported", nameof(type)),
                type);

        /// <summary>
        ///     Couchbase does not support sequences. See https://go.microsoft.com/fwlink/?LinkId=723262 for more information and examples.
        /// </summary>
        public static string SequencesNotSupported
            => GetString("SequencesNotSupported");

        /// <summary>
        ///     Couchbase does not support stored procedures, but one has been configured on entity type '{entityType}'. See https://go.microsoft.com/fwlink/?LinkId=723262 for more information and examples.
        /// </summary>
        public static string StoredProceduresNotSupported(object? entityType)
            => string.Format(
                GetString("StoredProceduresNotSupported", nameof(entityType)),
                entityType);

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name)!;
            for (var i = 0; i < formatterNames.Length; i++)
            {
                value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
            }

            return value;
        }
    }
}

namespace Microsoft.EntityFrameworkCore.Couchbase.Internal
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public static class CouchbaseResources
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.EntityFrameworkCore.Couchbase.Properties.CouchbaseStrings", typeof(CouchbaseResources).Assembly);

        /// <summary>
        ///     The entity type '{entityType}' has composite key '{key}' which is configured to use generated values. Couchbase does not support generated values on composite keys.
        /// </summary>
        public static EventDefinition<string?, string?> LogCompositeKeyWithValueGeneration(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogCompositeKeyWithValueGeneration;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogCompositeKeyWithValueGeneration,
                    logger,
                    static logger => new EventDefinition<string?, string?>(
                        logger.Options,
                        CouchbaseEventId.CompositeKeyWithValueGeneration,
                        LogLevel.Warning,
                        "CouchbaseEventId.CompositeKeyWithValueGeneration",
                        level => LoggerMessage.Define<string?, string?>(
                            level,
                            CouchbaseEventId.CompositeKeyWithValueGeneration,
                            _resourceManager.GetString("LogCompositeKeyWithValueGeneration")!)));
            }

            return (EventDefinition<string?, string?>)definition;
        }

        /// <summary>
        ///     Skipping foreign key with identity '{id}' on table '{tableName}' since principal table '{principalTableName}' was not found in the model. This usually happens when the principal table was not included in the selection set.
        /// </summary>
        public static EventDefinition<string?, string?, string?> LogForeignKeyScaffoldErrorPrincipalTableNotFound(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogForeignKeyScaffoldErrorPrincipalTableNotFound;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogForeignKeyScaffoldErrorPrincipalTableNotFound,
                    logger,
                    static logger => new EventDefinition<string?, string?, string?>(
                        logger.Options,
                        CouchbaseEventId.ForeignKeyReferencesMissingTableWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.ForeignKeyReferencesMissingTableWarning",
                        level => LoggerMessage.Define<string?, string?, string?>(
                            level,
                            CouchbaseEventId.ForeignKeyReferencesMissingTableWarning,
                            _resourceManager.GetString("LogForeignKeyScaffoldErrorPrincipalTableNotFound")!)));
            }

            return (EventDefinition<string?, string?, string?>)definition;
        }

        /// <summary>
        ///     The column '{columnName}' on table '{tableName}' should map to a property of type '{type}', but its values are in an incompatible format. Using a different type.
        /// </summary>
        public static EventDefinition<string?, string?, string?> LogFormatWarning(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogFormatWarning;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogFormatWarning,
                    logger,
                    static logger => new EventDefinition<string?, string?, string?>(
                        logger.Options,
                        CouchbaseEventId.FormatWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.FormatWarning",
                        level => LoggerMessage.Define<string?, string?, string?>(
                            level,
                            CouchbaseEventId.FormatWarning,
                            _resourceManager.GetString("LogFormatWarning")!)));
            }

            return (EventDefinition<string?, string?, string?>)definition;
        }

        /// <summary>
        ///     Found column on table '{tableName}' with name: '{columnName}', data type: {dataType}, not nullable: {notNullable}, default value: {defaultValue}.
        /// </summary>
        public static EventDefinition<string?, string?, string?, bool, string?> LogFoundColumn(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundColumn;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundColumn,
                    logger,
                    static logger => new EventDefinition<string?, string?, string?, bool, string?>(
                        logger.Options,
                        CouchbaseEventId.ColumnFound,
                        LogLevel.Debug,
                        "CouchbaseEventId.ColumnFound",
                        level => LoggerMessage.Define<string?, string?, string?, bool, string?>(
                            level,
                            CouchbaseEventId.ColumnFound,
                            _resourceManager.GetString("LogFoundColumn")!)));
            }

            return (EventDefinition<string?, string?, string?, bool, string?>)definition;
        }

        /// <summary>
        ///     Found foreign key on table '{tableName}', id: {id}, principal table: {principalTableName}, delete action: {deleteAction}.
        /// </summary>
        public static EventDefinition<string?, long, string?, string?> LogFoundForeignKey(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundForeignKey;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundForeignKey,
                    logger,
                    static logger => new EventDefinition<string?, long, string?, string?>(
                        logger.Options,
                        CouchbaseEventId.ForeignKeyFound,
                        LogLevel.Debug,
                        "CouchbaseEventId.ForeignKeyFound",
                        level => LoggerMessage.Define<string?, long, string?, string?>(
                            level,
                            CouchbaseEventId.ForeignKeyFound,
                            _resourceManager.GetString("LogFoundForeignKey")!)));
            }

            return (EventDefinition<string?, long, string?, string?>)definition;
        }

        /// <summary>
        ///     Found index on table '{tableName}' with name '{indexName}', is unique: {isUnique}.
        /// </summary>
        public static EventDefinition<string?, string?, bool?> LogFoundIndex(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundIndex;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundIndex,
                    logger,
                    static logger => new EventDefinition<string?, string?, bool?>(
                        logger.Options,
                        CouchbaseEventId.IndexFound,
                        LogLevel.Debug,
                        "CouchbaseEventId.IndexFound",
                        level => LoggerMessage.Define<string?, string?, bool?>(
                            level,
                            CouchbaseEventId.IndexFound,
                            _resourceManager.GetString("LogFoundIndex")!)));
            }

            return (EventDefinition<string?, string?, bool?>)definition;
        }

        /// <summary>
        ///     Found primary key on table '{tableName}' with name {primaryKeyName}.
        /// </summary>
        public static EventDefinition<string?, string?> LogFoundPrimaryKey(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundPrimaryKey;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundPrimaryKey,
                    logger,
                    static logger => new EventDefinition<string?, string?>(
                        logger.Options,
                        CouchbaseEventId.PrimaryKeyFound,
                        LogLevel.Debug,
                        "CouchbaseEventId.PrimaryKeyFound",
                        level => LoggerMessage.Define<string?, string?>(
                            level,
                            CouchbaseEventId.PrimaryKeyFound,
                            _resourceManager.GetString("LogFoundPrimaryKey")!)));
            }

            return (EventDefinition<string?, string?>)definition;
        }

        /// <summary>
        ///     Found table with name: '{name}'.
        /// </summary>
        public static EventDefinition<string?> LogFoundTable(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundTable;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundTable,
                    logger,
                    static logger => new EventDefinition<string?>(
                        logger.Options,
                        CouchbaseEventId.TableFound,
                        LogLevel.Debug,
                        "CouchbaseEventId.TableFound",
                        level => LoggerMessage.Define<string?>(
                            level,
                            CouchbaseEventId.TableFound,
                            _resourceManager.GetString("LogFoundTable")!)));
            }

            return (EventDefinition<string?>)definition;
        }

        /// <summary>
        ///     Found unique constraint on table '{tableName}' with name: {uniqueConstraintName}.
        /// </summary>
        public static EventDefinition<string?, string?> LogFoundUniqueConstraint(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundUniqueConstraint;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogFoundUniqueConstraint,
                    logger,
                    static logger => new EventDefinition<string?, string?>(
                        logger.Options,
                        CouchbaseEventId.UniqueConstraintFound,
                        LogLevel.Debug,
                        "CouchbaseEventId.UniqueConstraintFound",
                        level => LoggerMessage.Define<string?, string?>(
                            level,
                            CouchbaseEventId.UniqueConstraintFound,
                            _resourceManager.GetString("LogFoundUniqueConstraint")!)));
            }

            return (EventDefinition<string?, string?>)definition;
        }

        /// <summary>
        ///     Querying table '{tableName}' to determine an appropriate CLR type for each column.
        /// </summary>
        public static EventDefinition<string?> LogInferringTypes(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogInferringTypes;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogInferringTypes,
                    logger,
                    static logger => new EventDefinition<string?>(
                        logger.Options,
                        CouchbaseEventId.InferringTypes,
                        LogLevel.Debug,
                        "CouchbaseEventId.InferringTypes",
                        level => LoggerMessage.Define<string?>(
                            level,
                            CouchbaseEventId.InferringTypes,
                            _resourceManager.GetString("LogInferringTypes")!)));
            }

            return (EventDefinition<string?>)definition;
        }

        /// <summary>
        ///     Unable to find a table in the database matching the selected table '{table}'.
        /// </summary>
        public static EventDefinition<string?> LogMissingTable(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogMissingTable;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogMissingTable,
                    logger,
                    static logger => new EventDefinition<string?>(
                        logger.Options,
                        CouchbaseEventId.MissingTableWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.MissingTableWarning",
                        level => LoggerMessage.Define<string?>(
                            level,
                            CouchbaseEventId.MissingTableWarning,
                            _resourceManager.GetString("LogMissingTable")!)));
            }

            return (EventDefinition<string?>)definition;
        }

        /// <summary>
        ///     The column '{columnName}' on table '{tableName}' should map to a property of type '{type}', but its values are out of range. Using a different type.
        /// </summary>
        public static EventDefinition<string?, string?, string?> LogOutOfRangeWarning(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogOutOfRangeWarning;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogOutOfRangeWarning,
                    logger,
                    static logger => new EventDefinition<string?, string?, string?>(
                        logger.Options,
                        CouchbaseEventId.OutOfRangeWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.OutOfRangeWarning",
                        level => LoggerMessage.Define<string?, string?, string?>(
                            level,
                            CouchbaseEventId.OutOfRangeWarning,
                            _resourceManager.GetString("LogOutOfRangeWarning")!)));
            }

            return (EventDefinition<string?, string?, string?>)definition;
        }

        /// <summary>
        ///     Skipping foreign key with identity '{id}' on table '{tableName}', since the principal column '{principalColumnName}' on the foreign key's principal table, '{principalTableName}', was not found in the model.
        /// </summary>
        public static EventDefinition<string?, string?, string?, string?> LogPrincipalColumnNotFound(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogPrincipalColumnNotFound;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogPrincipalColumnNotFound,
                    logger,
                    static logger => new EventDefinition<string?, string?, string?, string?>(
                        logger.Options,
                        CouchbaseEventId.ForeignKeyPrincipalColumnMissingWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.ForeignKeyPrincipalColumnMissingWarning",
                        level => LoggerMessage.Define<string?, string?, string?, string?>(
                            level,
                            CouchbaseEventId.ForeignKeyPrincipalColumnMissingWarning,
                            _resourceManager.GetString("LogPrincipalColumnNotFound")!)));
            }

            return (EventDefinition<string?, string?, string?, string?>)definition;
        }

        /// <summary>
        ///     The entity type '{entityType}' is configured to use schema '{schema}', but Couchbase does not support schemas. This configuration will be ignored by the Couchbase provider.
        /// </summary>
        public static EventDefinition<string, string> LogSchemaConfigured(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogSchemaConfigured;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogSchemaConfigured,
                    logger,
                    static logger => new EventDefinition<string, string>(
                        logger.Options,
                        CouchbaseEventId.SchemaConfiguredWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.SchemaConfiguredWarning",
                        level => LoggerMessage.Define<string, string>(
                            level,
                            CouchbaseEventId.SchemaConfiguredWarning,
                            _resourceManager.GetString("LogSchemaConfigured")!)));
            }

            return (EventDefinition<string, string>)definition;
        }

        /// <summary>
        ///     The model was configured with the database sequence '{sequence}'. Couchbase does not support sequences.
        /// </summary>
        public static EventDefinition<string> LogSequenceConfigured(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogSequenceConfigured;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogSequenceConfigured,
                    logger,
                    static logger => new EventDefinition<string>(
                        logger.Options,
                        CouchbaseEventId.SequenceConfiguredWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.SequenceConfiguredWarning",
                        level => LoggerMessage.Define<string>(
                            level,
                            CouchbaseEventId.SequenceConfiguredWarning,
                            _resourceManager.GetString("LogSequenceConfigured")!)));
            }

            return (EventDefinition<string>)definition;
        }

        /// <summary>
        ///     An operation of type '{operationType}' will be attempted while a rebuild of table '{tableName}' is pending. The database may not be in an expected state. Review the SQL generated by this migration to help diagnose any failures. Consider moving these operations to a subsequent migration.
        /// </summary>
        public static EventDefinition<string, string> LogTableRebuildPendingWarning(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogTableRebuildPendingWarning;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogTableRebuildPendingWarning,
                    logger,
                    static logger => new EventDefinition<string, string>(
                        logger.Options,
                        CouchbaseEventId.TableRebuildPendingWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.TableRebuildPendingWarning",
                        level => LoggerMessage.Define<string, string>(
                            level,
                            CouchbaseEventId.TableRebuildPendingWarning,
                            _resourceManager.GetString("LogTableRebuildPendingWarning")!)));
            }

            return (EventDefinition<string, string>)definition;
        }

        /// <summary>
        ///     A connection of an unexpected type ({type}) is being used. The SQL functions prefixed with 'ef_' could not be created automatically. Manually define them if you encounter errors while querying.
        /// </summary>
        public static EventDefinition<string> LogUnexpectedConnectionType(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogUnexpectedConnectionType;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogUnexpectedConnectionType,
                    logger,
                    static logger => new EventDefinition<string>(
                        logger.Options,
                        CouchbaseEventId.UnexpectedConnectionTypeWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.UnexpectedConnectionTypeWarning",
                        level => LoggerMessage.Define<string>(
                            level,
                            CouchbaseEventId.UnexpectedConnectionTypeWarning,
                            _resourceManager.GetString("LogUnexpectedConnectionType")!)));
            }

            return (EventDefinition<string>)definition;
        }

        /// <summary>
        ///     Couchbase doesn't support schemas. The specified schema selection arguments will be ignored.
        /// </summary>
        public static EventDefinition LogUsingSchemaSelectionsWarning(IDiagnosticsLogger logger)
        {
            var definition = ((CouchbaseLoggingDefinitions)logger.Definitions).LogUsingSchemaSelectionsWarning;
            if (definition == null)
            {
                definition = NonCapturingLazyInitializer.EnsureInitialized(
                    ref ((CouchbaseLoggingDefinitions)logger.Definitions).LogUsingSchemaSelectionsWarning,
                    logger,
                    static logger => new EventDefinition(
                        logger.Options,
                        CouchbaseEventId.SchemasNotSupportedWarning,
                        LogLevel.Warning,
                        "CouchbaseEventId.SchemasNotSupportedWarning",
                        level => LoggerMessage.Define(
                            level,
                            CouchbaseEventId.SchemasNotSupportedWarning,
                            _resourceManager.GetString("LogUsingSchemaSelectionsWarning")!)));
            }

            return (EventDefinition)definition;
        }
    }
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
