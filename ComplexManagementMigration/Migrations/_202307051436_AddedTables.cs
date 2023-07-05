using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagementMigration.Migrations
{
    [Migration(02307051436)]
    public class _202307051436_AddedTables : Migration
    {
        public override void Up()
        {
            Create.Table("Complexes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("UnitCount").AsInt32().NotNullable();

            Create.Table("Blocks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("UnitCount").AsInt32().NotNullable()
                .WithColumn("ComplexId").AsInt32().NotNullable()
                     .ForeignKey("FK_Blocks_Complexes", "Complexes", "Id");

            Create.Table("Units")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("BlockId").AsInt32().NotNullable()
                    .ForeignKey("FK_Units_Blocks", "Blocks", "Id");
        }
        public override void Down()
        {
            Delete.Table("Units");

            Delete.Table("Blocks");

            Delete.Table("Complexes");
        }

    }
}
