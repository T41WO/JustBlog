using JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Repository
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts(bool checkIsPublished = true);

        IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize);
        int TotalPostsForCategory(string categorySlug);
        Category Category(string categorySlug);

        IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize);
        int TotalPostsForTag(string tagSlug);
        Tag Tag(string tagSlug);

        IList<Post> PostsForSearch(string search, int pageNo, int pagesize);
        int TotalPostsForSearch(string search);

        Post Post(int year, int month, string titleSlug);
        IList<Category> Categories();
        IList<Tag> Tags();

        IList<Post> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending);

        int AddPost(Post post);

        Category Category(int p);

        Tag Tag(int p);

        void EditPost(Post post);

        void DeletePost(int id);

        int AddTag(Tag tag);

        void EditTag(Tag tag);

        void DeleteTag(int id);

        int AddCategory(Category category);

        void EditCategory(Category category);

        void DeleteCategory(int id);
    }
}
