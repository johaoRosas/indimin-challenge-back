
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TaskMap{
    public TaskMap(EntityTypeBuilder<Task> entityBuilder){

     entityBuilder.HasKey(x => x.Id);
     entityBuilder.ToTable("task");

     entityBuilder.Property(x => x.Id).HasColumnName("id");
     entityBuilder.Property(x => x.CitizenId).HasColumnName("citizen_id");
     entityBuilder.Property(x => x.Description).HasColumnName("description");
     entityBuilder.Property(x => x.Day).HasColumnName("day");
     entityBuilder.Property(x => x.Month).HasColumnName("month");
     entityBuilder.Property(x => x.Year).HasColumnName("year");
     entityBuilder.Property(x => x.Status).HasColumnName("status");


    }
}