namespace Esinav.DataAccess.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Esinav1.IDRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "Esinav1.IDUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Esinav1.IDRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Esinav1.IDUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Esinav1.IDUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Kullanici_Adi = c.String(maxLength: 100),
                        Kullanici_Soyadi = c.String(maxLength: 100),
                        Iban_No = c.String(maxLength: 30),
                        Adres = c.String(maxLength: 200),
                        Gender = c.Boolean(),
                        Kullanici_Tip_Id = c.Int(nullable: false),
                        Kayit_Zamani = c.DateTime(nullable: false),
                        Kayit_Ip = c.String(maxLength: 50),
                        Guncelleme_Zamani = c.DateTime(nullable: false),
                        Guncelleme_Ip = c.String(maxLength: 50),
                        Tc_No = c.String(),
                        Aktif = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Esinav1.IDUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Esinav1.IDUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Esinav1.IDUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Esinav1.IDUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Esinav1.Sehir",
                c => new
                    {
                        Sehir_Id = c.Int(nullable: false, identity: true),
                        Sehir_Adi = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Sehir_Id);
            
            CreateTable(
                "Esinav1.Ilce",
                c => new
                    {
                        Ilce_Id = c.Int(nullable: false, identity: true),
                        Sehir_Id = c.Int(nullable: false),
                        Ilce_Adi = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Ilce_Id)
                .ForeignKey("Esinav1.Sehir", t => t.Sehir_Id, cascadeDelete: true)
                .Index(t => t.Sehir_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Esinav1.Ilce", "Sehir_Id", "Esinav1.Sehir");
            DropForeignKey("Esinav1.IDUserRole", "UserId", "Esinav1.IDUser");
            DropForeignKey("Esinav1.IDUserLogin", "UserId", "Esinav1.IDUser");
            DropForeignKey("Esinav1.IDUserClaim", "UserId", "Esinav1.IDUser");
            DropForeignKey("Esinav1.IDUserRole", "RoleId", "Esinav1.IDRole");
            DropIndex("Esinav1.Ilce", new[] { "Sehir_Id" });
            DropIndex("Esinav1.IDUserLogin", new[] { "UserId" });
            DropIndex("Esinav1.IDUserClaim", new[] { "UserId" });
            DropIndex("Esinav1.IDUser", "UserNameIndex");
            DropIndex("Esinav1.IDUserRole", new[] { "RoleId" });
            DropIndex("Esinav1.IDUserRole", new[] { "UserId" });
            DropIndex("Esinav1.IDRole", "RoleNameIndex");
            DropTable("Esinav1.Ilce");
            DropTable("Esinav1.Sehir");
            DropTable("Esinav1.IDUserLogin");
            DropTable("Esinav1.IDUserClaim");
            DropTable("Esinav1.IDUser");
            DropTable("Esinav1.IDUserRole");
            DropTable("Esinav1.IDRole");
        }
    }
}
