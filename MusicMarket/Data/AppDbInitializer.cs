using Microsoft.AspNetCore.Identity;
using MusicMarket.Data;
using MusicMarket.Data.Static;
using MusicMarket.Models;
using System;

namespace MusicMarket.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                context.Database.EnsureCreated();
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Guitar"
                        },
                        new Category()
                        {
                            Name = "Pianos"
                        },
                        new Category()
                        {
                            Name = "Bowed Strings"
                        },
                        new Category()
                        {
                            Name = "Drums - Percussions"
                        },
                        new Category()
                        {
                            Name = "Amp - Effects"
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            CategoryId = 1,
                            Title = "Cort Guitar 1",
                            Price = 150,
                            ImageUrl = "https://images.unsplash.com/photo-1564186763535-ebb21ef5277f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                            Description = "The guitar is a fretted musical instrument that typically has six strings. " +
                            "It is usually held flat against the player's body and played by strumming or plucking the strings with the dominant hand," +
                            " while simultaneously pressing selected strings against frets with the fingers of the opposite hand. " +
                            "A plectrum or individual finger picks may also be used to strike the strings. ",
                            Stock = 5
                        }
                    });
                    context.SaveChanges();
                }
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<MusicMarketUser>>();
                string adminUserEmail = "b201210038@sakarya.edu.tr";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new MusicMarketUser()
                    {
                        UserName = "beyzaerkan",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "123456Be.");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new MusicMarketUser()
                    {
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "123456Be.");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }

    }
}