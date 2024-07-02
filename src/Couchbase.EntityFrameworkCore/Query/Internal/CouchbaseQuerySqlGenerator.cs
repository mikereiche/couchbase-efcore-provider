using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Couchbase.EntityFrameworkCore.Query.Internal;

public class CouchbaseQuerySqlGenerator : QuerySqlGenerator
{
    public CouchbaseQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }
    
    protected override void GenerateRootCommand(Expression queryExpression)
    {
        switch (queryExpression)
        {
            case SelectExpression selectExpression:
                GenerateTagsHeaderComment(selectExpression.Tags);

                if (selectExpression.IsNonComposedFromSql())
                {
                    GenerateFromSql((FromSqlExpression)selectExpression.Tables[0]);
                }
                else
                {
                    VisitSelect(selectExpression);
                }

                break;

            case UpdateExpression updateExpression:
                GenerateTagsHeaderComment(updateExpression.Tags);
                VisitUpdate(updateExpression);
                break;

            case DeleteExpression deleteExpression:
                GenerateTagsHeaderComment(deleteExpression.Tags);
                VisitDelete(deleteExpression);
                break;

            default:
                base.Visit(queryExpression);
                break;
        }
    }

    protected override Expression VisitTable(TableExpression tableExpression)
    {
        //TODO we need to correlate a specific bucket->scope-collection in place of a table
       /* Sql.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(tableExpression.Name, tableExpression.Schema))
            .Append(AliasSeparator)
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(tableExpression.Alias));*/
       
       Sql.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier("travel-sample", tableExpression.Schema))
           .Append(AliasSeparator)
           .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(tableExpression.Alias));

        return tableExpression;
    }

    protected override Expression VisitColumn(ColumnExpression columnExpression)
    {
        var helper = Dependencies.SqlGenerationHelper;
        Sql.Append(helper.DelimitIdentifier(columnExpression.TableAlias))
            .Append(".")
            .Append(helper.DelimitIdentifier(columnExpression.Name.ToLower()));//TODO ToLower is a hack this should be done during entity translation
        return columnExpression;
    }

    public override IRelationalCommand GetCommand(Expression queryExpression)
    {
        var command = base.GetCommand(queryExpression);
        return command;
    }

    protected override string GetOperator(SqlBinaryExpression binaryExpression)
    {
        ArgumentNullException.ThrowIfNull(binaryExpression);

        return binaryExpression.OperatorType == ExpressionType.Add
               && binaryExpression.Type == typeof(string)
            ? " || "
            : base.GetOperator(binaryExpression);
    }

    protected override void GenerateLimitOffset(SelectExpression selectExpression)
    {
        ArgumentNullException.ThrowIfNull(selectExpression);

        if (selectExpression.Limit != null
            || selectExpression.Offset != null)
        {
            Sql.AppendLine()
                .Append("LIMIT ");

            Visit(
                selectExpression.Limit
                ?? new SqlConstantExpression(Expression.Constant(-1), selectExpression.Offset!.TypeMapping));

            if (selectExpression.Offset != null)
            {
                Sql.Append(" OFFSET ");

                Visit(selectExpression.Offset);
            }
        }
    }

    protected override void GenerateSetOperationOperand(SetOperationBase setOperation, SelectExpression operand)
    {
        ArgumentNullException.ThrowIfNull(setOperation);
        ArgumentNullException.ThrowIfNull(operand);

        // Sqlite doesn't support parentheses around set operation operands
        Visit(operand);
    }

    private void GenerateFromSql(FromSqlExpression fromSqlExpression)
    {
        var sql = fromSqlExpression.Sql;
        string[]? substitutions;

        switch (fromSqlExpression.Arguments)
        {
            case ConstantExpression { Value: CompositeRelationalParameter compositeRelationalParameter }:
            {
                var subParameters = compositeRelationalParameter.RelationalParameters;
                substitutions = new string[subParameters.Count];
                for (var i = 0; i < subParameters.Count; i++)
                {
                    substitutions[i] = Dependencies.SqlGenerationHelper.GenerateParameterNamePlaceholder(subParameters[i].InvariantName);
                }

                Sql.AddParameter(compositeRelationalParameter);
                break;
            }

            case ConstantExpression { Value: object[] constantValues }:
            {
                substitutions = new string[constantValues.Length];
                for (var i = 0; i < constantValues.Length; i++)
                {
                    var value = constantValues[i];
                    if (value is RawRelationalParameter rawRelationalParameter)
                    {
                        substitutions[i] = Dependencies.SqlGenerationHelper.GenerateParameterNamePlaceholder(rawRelationalParameter.InvariantName);
                       Sql.AddParameter(rawRelationalParameter);
                    }
                    else if (value is SqlConstantExpression sqlConstantExpression)
                    {
                        substitutions[i] = sqlConstantExpression.TypeMapping!.GenerateSqlLiteral(sqlConstantExpression.Value);
                    }
                }

                break;
            }

            default:
                throw new ArgumentOutOfRangeException(
                    nameof(fromSqlExpression),
                    fromSqlExpression.Arguments,
                    RelationalStrings.InvalidFromSqlArguments(
                        fromSqlExpression.Arguments.GetType(),
                        fromSqlExpression.Arguments is ConstantExpression constantExpression
                            ? constantExpression.Value?.GetType()
                            : null));
        }

        // ReSharper disable once CoVariantArrayConversion
        // InvariantCulture not needed since substitutions are all strings
        sql = string.Format(sql, substitutions);

        Sql.AppendLines(sql);
    }
}