namespace Core.Model
{
    //Abstract yapma sebebim instance alınmasın newlenemesin.   
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
