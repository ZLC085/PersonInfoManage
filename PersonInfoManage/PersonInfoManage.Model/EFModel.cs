namespace PersonInfoManage.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFModel : DbContext
    {
        public EFModel()
            : base("name=EFModel")
        {
        }

        public virtual DbSet<cost_detail> cost_detail { get; set; }
        public virtual DbSet<cost_main> cost_main { get; set; }
        public virtual DbSet<cost_plan> cost_plan { get; set; }
        public virtual DbSet<log_sys> log_sys { get; set; }
        public virtual DbSet<log_user> log_user { get; set; }
        public virtual DbSet<person_basic> person_basic { get; set; }
        public virtual DbSet<person_file> person_file { get; set; }
        public virtual DbSet<sys_dict> sys_dict { get; set; }
        public virtual DbSet<sys_g2m> sys_g2m { get; set; }
        public virtual DbSet<sys_group> sys_group { get; set; }
        public virtual DbSet<sys_menu> sys_menu { get; set; }
        public virtual DbSet<sys_u2g> sys_u2g { get; set; }
        public virtual DbSet<sys_user> sys_user { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<business> businesses { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }
        public virtual DbSet<View_CostMainDetail> View_CostMainDetail { get; set; }
        public virtual DbSet<view_sys_g2m> view_sys_g2m { get; set; }
        public virtual DbSet<view_sys_u2g> view_sys_u2g { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cost_main>()
                .HasMany(e => e.cost_detail)
                .WithRequired(e => e.cost_main)
                .HasForeignKey(e => e.cost_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person_basic>()
                .HasMany(e => e.businesses)
                .WithRequired(e => e.person_basic)
                .HasForeignKey(e => e.person_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<person_basic>()
                .HasMany(e => e.person_file)
                .WithRequired(e => e.person_basic)
                .HasForeignKey(e => e.person_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sys_group>()
                .HasMany(e => e.sys_g2m)
                .WithRequired(e => e.sys_group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sys_group>()
                .HasMany(e => e.sys_u2g)
                .WithRequired(e => e.sys_group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sys_menu>()
                .HasMany(e => e.sys_g2m)
                .WithRequired(e => e.sys_menu)
                .HasForeignKey(e => e.menu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sys_user>()
                .HasMany(e => e.log_user)
                .WithRequired(e => e.sys_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sys_user>()
                .HasMany(e => e.sys_u2g)
                .WithRequired(e => e.sys_user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
