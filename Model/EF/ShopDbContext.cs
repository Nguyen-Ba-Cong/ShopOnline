namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("name=ShopDbContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ConTent> ConTents { get; set; }
        public virtual DbSet<ContentTag> ContentTags { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenyType> MenyTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<About>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<About>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<About>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength();

            modelBuilder.Entity<About>()
                .Property(e => e.MetaKeywords)
                .IsFixedLength();

            modelBuilder.Entity<About>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.SeoTitle)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaKeywords)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.MetaKeywords)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<ConTent>()
                .Property(e => e.Tags)
                .IsFixedLength();

            modelBuilder.Entity<ContentTag>()
                .Property(e => e.TagID)
                .IsFixedLength();

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Content)
                .IsFixedLength();

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Menu>()
                .Property(e => e.Text)
                .IsFixedLength();

            modelBuilder.Entity<Menu>()
                .Property(e => e.Link)
                .IsFixedLength();

            modelBuilder.Entity<Menu>()
                .Property(e => e.Target)
                .IsFixedLength();

            modelBuilder.Entity<MenyType>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipAddess)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength();

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength();

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaKeywords)
                .IsFixedLength();

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Slide>()
                .Property(e => e.Link)
                .IsFixedLength();

            modelBuilder.Entity<Slide>()
                .Property(e => e.Decription)
                .IsFixedLength();

            modelBuilder.Entity<Slide>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Slide>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength();

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.value)
                .IsFixedLength();

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Tag>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsFixedLength();

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);
        }
    }
}
