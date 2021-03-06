// <auto-generated />
using EFCore_sample.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore_sample.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20220203082950_insertAddressData")]
    partial class insertAddressData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore_sample.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressDetail = "AddressDetail_1",
                            EmployeeId = 1
                        },
                        new
                        {
                            Id = 2,
                            AddressDetail = "AddressDetail_2",
                            EmployeeId = 2
                        },
                        new
                        {
                            Id = 3,
                            AddressDetail = "AddressDetail_3",
                            EmployeeId = 3
                        });
                });

            modelBuilder.Entity("EFCore_sample.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "harish@mail.com",
                            EmployeeName = "Harish",
                            Salary = 70000f,
                            Skill = "Full Stack Developer"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Ram@mail.com",
                            EmployeeName = "Ram",
                            Salary = 80000f,
                            Skill = "Oracle developer"
                        },
                        new
                        {
                            Id = 3,
                            Email = "vicky@mail.com",
                            EmployeeName = "Vicky",
                            Salary = 90000f,
                            Skill = "Azure devops developer"
                        });
                });

            modelBuilder.Entity("EFCore_sample.Models.Address", b =>
                {
                    b.HasOne("EFCore_sample.Models.Employee", "Employee")
                        .WithMany("EmployeeAddress")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EFCore_sample.Models.Employee", b =>
                {
                    b.Navigation("EmployeeAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
