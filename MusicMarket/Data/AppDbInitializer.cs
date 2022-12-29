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
                            Name = "Saz"
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
                            Price = 350,
                            ImageUrl = "https://images.unsplash.com/photo-1564186763535-ebb21ef5277f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                            Description = "The guitar is a fretted musical instrument that typically has six strings. " +
                            "It is usually held flat against the player's body and played by strumming or plucking the strings with the dominant hand," +
                            " while simultaneously pressing selected strings against frets with the fingers of the opposite hand. " +
                            "A plectrum or individual finger picks may also be used to strike the strings. ",
                            Stock = 5
                        },
                        new Product()
                        {
                            CategoryId = 2,
                            Title = "Pianos 1",
                            Price = 250,
                            ImageUrl = "https://images.unsplash.com/photo-1552422535-c45813c61732?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80",
                            Description = "The piano is a keyboard instrument that produces sound by striking strings with hammers, " +
                            "characterized by its large range and ability to play chords freely. It is a musical instrument that has broad appeal.",
                            Stock = 5
                        },
                        new Product()
                        {
                            CategoryId = 3,
                            Title = "Bowed Strings1",
                            Price = 350,
                            ImageUrl = "https://images.unsplash.com/photo-1603584915335-d612257071b0?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80",
                            Description = "Bowed string instruments are a subcategory of string instruments that are played by a bow rubbing the strings. " +
                            "The bow rubbing the string causes vibration which the instrument emits as sound.",
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
                string adminUserEmail1 = "b201210056@sakarya.edu.tr";

                var adminUser1 = await userManager.FindByEmailAsync(adminUserEmail1);
                if (adminUser1 == null)
                {
                    var newAdminUser = new MusicMarketUser()
                    {
                        UserName = "kemal",
                        Email = adminUserEmail1,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Kemal123.");
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
