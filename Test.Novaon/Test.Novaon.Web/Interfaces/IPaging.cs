namespace Test.Novaon.Web.Interfaces
{
    public interface IPaging
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        int Take { get; set; }
        int Skip { get; set; }
    }
}
