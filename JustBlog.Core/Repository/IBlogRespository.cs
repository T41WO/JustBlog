using JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Repository
{
    public interface IBlogRespository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
    }
}
