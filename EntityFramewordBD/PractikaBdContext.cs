using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkBD;

public partial class PractikaBdContext : DbContext
{
    public PractikaBdContext()
    {
    }

    public PractikaBdContext(DbContextOptions<PractikaBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Hero> Heroes { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<MatchPlayer> MatchPlayers { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__8037C7D6EAF99E5B");

            entity.Property(e => e.CountryId).HasColumnName("Country_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Country_Name");
        });

        modelBuilder.Entity<Hero>(entity =>
        {
            entity.HasKey(e => e.HeroId).HasName("PK__Heroes__34F648A460C5CBD2");

            entity.HasIndex(e => e.HeroName, "UQ__Heroes__B4AAD6ACDF1BB798").IsUnique();

            entity.Property(e => e.HeroId).HasColumnName("Hero_id");
            entity.Property(e => e.AttackType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Attack_type");
            entity.Property(e => e.HeroName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Hero_name");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("PK__Matches__5E5A240876CB58D3");

            entity.Property(e => e.MatchId)
                .HasDefaultValueSql("(newsequentialid())", "DF_Matches_Match_id")
                .HasColumnName("Match_id");
            entity.Property(e => e.MatchDate)
                .HasColumnType("datetime")
                .HasColumnName("Match_date");
            entity.Property(e => e.Winner)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MatchPlayer>(entity =>
        {
            entity.HasKey(e => new { e.MatchId, e.PlayerId });

            entity.Property(e => e.HeroId).HasColumnName("Hero_id");
            entity.Property(e => e.MatchId).HasColumnName("Match_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.Side)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Hero).WithMany()
                .HasForeignKey(d => d.HeroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MatchPlay__Hero___51300E55");

            entity.HasOne(d => d.Match).WithMany()
                .HasForeignKey(d => d.MatchId)
                .HasConstraintName("FK__MatchPlay__Match__4F47C5E3");

            entity.HasOne(d => d.Player).WithMany()
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MatchPlay__playe__503BEA1C");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__players__9F0F7DA1DE1B7556");

            entity.ToTable("players");

            entity.Property(e => e.PlayerId).HasColumnName("Player_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.DotaPlus).HasDefaultValue(false);
            entity.Property(e => e.Mmr).HasColumnName("MMR");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Player_name");

            entity.HasOne(d => d.Country).WithMany(p => p.Players)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__players__country__2A164134");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
