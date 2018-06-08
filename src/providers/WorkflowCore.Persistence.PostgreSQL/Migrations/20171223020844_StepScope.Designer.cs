﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WorkflowCore.Models;
using WorkflowCore.Persistence.PostgreSQL;

namespace WorkflowCore.Persistence.PostgreSQL.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20171223020844_StepScope")]
    partial class StepScope
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedEvent", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventData");

                    b.Property<Guid>("EventId");

                    b.Property<string>("EventKey")
                        .HasMaxLength(200);

                    b.Property<string>("EventName")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EventTime");

                    b.Property<bool>("IsProcessed");

                    b.HasKey("PersistenceId");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.HasIndex("EventTime");

                    b.HasIndex("IsProcessed");

                    b.HasIndex("EventName", "EventKey");

                    b.ToTable("Event","wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionError", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ErrorTime");

                    b.Property<string>("ExecutionPointerId")
                        .HasMaxLength(100);

                    b.Property<string>("Message");

                    b.Property<string>("WorkflowId")
                        .HasMaxLength(100);

                    b.HasKey("PersistenceId");

                    b.ToTable("ExecutionError","wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Children");

                    b.Property<string>("ContextItem");

                    b.Property<DateTime?>("EndTime");

                    b.Property<string>("EventData");

                    b.Property<string>("EventKey")
                        .HasMaxLength(100);

                    b.Property<string>("EventName")
                        .HasMaxLength(100);

                    b.Property<bool>("EventPublished");

                    b.Property<string>("Id")
                        .HasMaxLength(50);

                    b.Property<string>("Outcome");

                    b.Property<string>("PersistenceData");

                    b.Property<string>("PredecessorId")
                        .HasMaxLength(100);

                    b.Property<int>("RetryCount");

                    b.Property<string>("Scope");

                    b.Property<DateTime?>("SleepUntil");

                    b.Property<DateTime?>("StartTime");

                    b.Property<int>("Status");

                    b.Property<int>("StepId");

                    b.Property<string>("StepName")
                        .HasMaxLength(100);

                    b.Property<long>("WorkflowId");

                    b.HasKey("PersistenceId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("ExecutionPointer","wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExtensionAttribute", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttributeKey")
                        .HasMaxLength(100);

                    b.Property<string>("AttributeValue");

                    b.Property<long>("ExecutionPointerId");

                    b.HasKey("PersistenceId");

                    b.HasIndex("ExecutionPointerId");

                    b.ToTable("ExtensionAttribute","wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedSubscription", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventKey")
                        .HasMaxLength(200);

                    b.Property<string>("EventName")
                        .HasMaxLength(200);

                    b.Property<int>("StepId");

                    b.Property<DateTime>("SubscribeAsOf");

                    b.Property<Guid>("SubscriptionId")
                        .HasMaxLength(200);

                    b.Property<string>("WorkflowId")
                        .HasMaxLength(200);

                    b.HasKey("PersistenceId");

                    b.HasIndex("EventKey");

                    b.HasIndex("EventName");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.ToTable("Subscription","wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedWorkflow", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CompleteTime");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Data");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<Guid>("InstanceId")
                        .HasMaxLength(200);

                    b.Property<long?>("NextExecution");

                    b.Property<string>("Reference")
                        .HasMaxLength(200);

                    b.Property<int>("Status");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowDefinitionId")
                        .HasMaxLength(200);

                    b.HasKey("PersistenceId");

                    b.HasIndex("InstanceId")
                        .IsUnique();

                    b.HasIndex("NextExecution");

                    b.ToTable("Workflow","wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", b =>
                {
                    b.HasOne("WorkflowCore.Persistence.EntityFramework.Models.PersistedWorkflow", "Workflow")
                        .WithMany("ExecutionPointers")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExtensionAttribute", b =>
                {
                    b.HasOne("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", "ExecutionPointer")
                        .WithMany("ExtensionAttributes")
                        .HasForeignKey("ExecutionPointerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
