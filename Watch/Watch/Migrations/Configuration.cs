namespace Watch.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Watch.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Watch.DAL.WatchShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Watch.DAL.WatchShopContext context)
        {

            var users = new List<User>
            {
                new User { TaiKhoan = "Admin",   MatKhau = "123456", HoTen = "Admin", DiaChi = "HaNoi", Quyen = 0 },
                new User { TaiKhoan = "Customer",   MatKhau = "123456", HoTen = "Customer", DiaChi = "HaNoi", Quyen =  1},

            };
            users.ForEach(s => context.Users.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category { TenDM = "Đồng Hồ Học Sinh"},
                new Category { TenDM = "Đồng Hồ Công Sở"},
                new Category { TenDM = "Đồng Hồ Thể Thao"},
                new Category { TenDM = "Đồng Hồ Thông Minh"},
                new Category { TenDM = "Đồng Hồ Cao Cấp"},

            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.ID, c));
            context.SaveChanges();
        }
    }
}
