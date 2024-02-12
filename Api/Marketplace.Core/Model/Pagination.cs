
namespace Marketplace.Core.Model
{
    public class Pagination
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public Pagination()
        {
            this.pageNumber = 1;
            this.pageSize = 10;
        }
        public Pagination(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            this.pageSize = pageSize >= 11 ? 10 : pageSize;

        }
    }
}
