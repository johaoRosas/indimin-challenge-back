
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CitizenMap{
    public CitizenMap(EntityTypeBuilder<Citizen> entityBuilder){

     entityBuilder.HasKey(x => x.Id);
     entityBuilder.ToTable("citizen");

     entityBuilder.Property(x => x.Id).HasColumnName("id");
     entityBuilder.Property(x => x.FirstName).HasColumnName("first_name");
     entityBuilder.Property(x => x.LastName).HasColumnName("last_name");
     entityBuilder.Property(x => x.Email).HasColumnName("email");
     entityBuilder.Property(x => x.Status).HasColumnName("status");


    }
}