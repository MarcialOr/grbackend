using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace grbackend.Models
{
    public partial class grdbContext : DbContext
    {
        public grdbContext()
        {
        }

        public grdbContext(DbContextOptions<grdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Chatdetalle> Chatdetalle { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Historicotrabajo> Historicotrabajo { get; set; }
        public virtual DbSet<Maestroranking> Maestroranking { get; set; }
        public virtual DbSet<Mensaje> Mensaje { get; set; }
        public virtual DbSet<Tecnico> Tecnico { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("User ID = postgres;Password=Marcial1995;Server=localhost;Port=5432;Database=grdb;Integrated Security=true; Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Categoriaid)
                    .HasColumnName("categoriaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("chat");

                entity.Property(e => e.Chatid)
                    .HasColumnName("chatid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Tecnicoid).HasColumnName("tecnicoid");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.Clienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteid");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Chat)
                    .HasForeignKey(d => d.Tecnicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnicoid");
            });

            modelBuilder.Entity<Chatdetalle>(entity =>
            {
                entity.ToTable("chatdetalle");

                entity.Property(e => e.Chatdetalleid)
                    .HasColumnName("chatdetalleid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Chatid).HasColumnName("chatid");

                entity.Property(e => e.Dueno)
                    .HasColumnName("dueno")
                    .HasColumnType("character varying");

                entity.Property(e => e.Mensaje)
                    .HasColumnName("mensaje")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Chatdetalle)
                    .HasForeignKey(d => d.Chatid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chatid");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Clienteid)
                    .HasColumnName("clienteid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasColumnType("character varying");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasColumnType("character varying");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("character varying");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("character varying");

                entity.Property(e => e.Rankingid).HasColumnName("rankingid");

                entity.Property(e => e.Sobremi)
                    .IsRequired()
                    .HasColumnName("sobremi")
                    .HasColumnType("character varying");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.Ranking)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.Rankingid)
                    .HasConstraintName("fk_rankingid");
            });

            modelBuilder.Entity<Historicotrabajo>(entity =>
            {
                entity.HasKey(e => e.Historicoid)
                    .HasName("historicotrabajo_pkey");

                entity.ToTable("historicotrabajo");

                entity.Property(e => e.Historicoid)
                    .HasColumnName("historicoid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("character varying");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("character varying");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("character varying");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Rankingid).HasColumnName("rankingid");

                entity.Property(e => e.Tecnicoid).HasColumnName("tecnicoid");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Historicotrabajo)
                    .HasForeignKey(d => d.Clienteid)
                    .HasConstraintName("fk_clienteid");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Historicotrabajo)
                    .HasForeignKey(d => d.Tecnicoid)
                    .HasConstraintName("fk_tecnicoid");
            });

            modelBuilder.Entity<Maestroranking>(entity =>
            {
                entity.HasKey(e => e.Rankingid)
                    .HasName("maestroranking_pkey");

                entity.ToTable("maestroranking");

                entity.Property(e => e.Rankingid)
                    .HasColumnName("rankingid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnName("comentario")
                    .HasColumnType("character varying");

                entity.Property(e => e.De).HasColumnName("de");

                entity.Property(e => e.Para).HasColumnName("para");

                entity.Property(e => e.Valoracion).HasColumnName("valoracion");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.ToTable("mensaje");

                entity.Property(e => e.Mensajeid)
                    .HasColumnName("mensajeid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Chatid).HasColumnName("chatid");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Mensaje1)
                    .HasColumnName("mensaje")
                    .HasColumnType("character varying");

                entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.ToTable("tecnico");

                entity.Property(e => e.Tecnicoid)
                    .HasColumnName("tecnicoid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasColumnType("character varying");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasColumnType("character varying");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("character varying");

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("fechaFinal")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("character varying");

                entity.Property(e => e.Presupuesto).HasColumnName("presupuesto");

                entity.Property(e => e.Rankingid).HasColumnName("rankingid");

                entity.Property(e => e.Rtn)
                    .HasColumnName("rtn")
                    .HasColumnType("character varying");

                entity.Property(e => e.Sobremi)
                    .HasColumnName("sobremi")
                    .HasColumnType("character varying");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Tecnico)
                    .HasForeignKey(d => d.Categoriaid)
                    .HasConstraintName("fk_categoriaid");

                entity.HasOne(d => d.Ranking)
                    .WithMany(p => p.Tecnico)
                    .HasForeignKey(d => d.Rankingid)
                    .HasConstraintName("fk_rankingid");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tecnico)
                    .HasForeignKey(d => d.Usuarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarioid");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Usuarioid)
                    .HasColumnName("usuarioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Suscripcion)
                    .IsRequired()
                    .HasColumnName("suscripcion")
                    .HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
