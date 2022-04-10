﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeniorSolutionsWeb.Data;

#nullable disable

namespace SeniorSolutionsWeb.Migrations
{
    [DbContext(typeof(SeniorSolutionsWebContext))]
    [Migration("20220410141814_CommunityIssuesFinal")]
    partial class CommunityIssuesFinal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"), 1L, 1);

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateClubCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("ClubId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.ClubMeeting", b =>
                {
                    b.Property<int>("MeetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetId"), 1L, 1);

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int?>("EndTime")
                        .HasColumnType("int");

                    b.Property<string>("MeetingDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeetingPlace")
                        .HasColumnType("int");

                    b.Property<int?>("StartTime")
                        .HasColumnType("int");

                    b.HasKey("MeetId");

                    b.ToTable("ClubMeeting");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.ClubMembership", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"), 1L, 1);

                    b.Property<string>("ResidentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ClubId");

                    b.ToTable("ClubMembership");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.ClubRoles", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("RoleEval")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleRank")
                        .HasColumnType("int");

                    b.HasKey("RoleID");

                    b.ToTable("ClubRoles");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.CommunityIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DownVotes")
                        .HasColumnType("bigint");

                    b.Property<int?>("ResidentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UpVotes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ResidentId");

                    b.ToTable("CommunityIssue");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.CommunityIssueVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommunityIssueId")
                        .HasColumnType("int");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommunityIssueId");

                    b.HasIndex("ResidentId");

                    b.ToTable("CommunityIssueVote");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateAccountCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Locations", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Orientation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orientations");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.OrientationAttendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrientationId")
                        .HasColumnType("int");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrientationId");

                    b.HasIndex("ResidentId");

                    b.ToTable("OrientationAttendees");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Answer1Votes")
                        .HasColumnType("int");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Answer2Votes")
                        .HasColumnType("int");

                    b.Property<string>("Answer3")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Answer3Votes")
                        .HasColumnType("int");

                    b.Property<string>("Answer4")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Answer4Votes")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Poll");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.PollVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.Property<string>("VotedFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.HasIndex("ResidentId");

                    b.ToTable("PollVote");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateAccountCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidencyStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResidentLeaseNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Resident");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.ResidentPostResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommunityIssueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateResponse")
                        .HasColumnType("datetime2");

                    b.Property<int>("IssueID")
                        .HasColumnType("int");

                    b.Property<int>("ResidentID")
                        .HasColumnType("int");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vote")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommunityIssueId");

                    b.HasIndex("ResidentID");

                    b.ToTable("ResidentPostResponse");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.ServiceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeAssignedId")
                        .HasColumnType("int");

                    b.Property<int>("RequestorId")
                        .HasColumnType("int");

                    b.Property<string>("RequestorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceRequest");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.CommunityIssue", b =>
                {
                    b.HasOne("SeniorSolutionsWeb.Models.Resident", "Resident")
                        .WithMany("CommunityIssueList")
                        .HasForeignKey("ResidentId");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.CommunityIssueVote", b =>
                {
                    b.HasOne("SeniorSolutionsWeb.Models.CommunityIssue", "CommunityIssue")
                        .WithMany("CommunityIssueVotes")
                        .HasForeignKey("CommunityIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeniorSolutionsWeb.Models.Resident", "Resident")
                        .WithMany("CommunityIssueVotes")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommunityIssue");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.OrientationAttendee", b =>
                {
                    b.HasOne("SeniorSolutionsWeb.Models.Orientation", "Orientation")
                        .WithMany("Attendees")
                        .HasForeignKey("OrientationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeniorSolutionsWeb.Models.Resident", "Resident")
                        .WithMany()
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orientation");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.PollVote", b =>
                {
                    b.HasOne("SeniorSolutionsWeb.Models.Poll", "Poll")
                        .WithMany("Votes")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeniorSolutionsWeb.Models.Resident", "Resident")
                        .WithMany()
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.ResidentPostResponse", b =>
                {
                    b.HasOne("SeniorSolutionsWeb.Models.CommunityIssue", "CommunityIssue")
                        .WithMany("ResidentPostResponses")
                        .HasForeignKey("CommunityIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeniorSolutionsWeb.Models.Resident", "Resident")
                        .WithMany("ResidentPostResponses")
                        .HasForeignKey("ResidentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommunityIssue");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.CommunityIssue", b =>
                {
                    b.Navigation("CommunityIssueVotes");

                    b.Navigation("ResidentPostResponses");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Orientation", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Poll", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("SeniorSolutionsWeb.Models.Resident", b =>
                {
                    b.Navigation("CommunityIssueList");

                    b.Navigation("CommunityIssueVotes");

                    b.Navigation("ResidentPostResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
