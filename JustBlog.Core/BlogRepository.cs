﻿using JustBlog.Core.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core
{
    public class BlogRepository: IBlogRespository
    {
        private readonly ISession _session;

        public BlogRepository(ISession session)
        {
            _session = session;
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _session.Query<Post>()
                                .Where(p => p.Published)
                                .OrderByDescending(p => p.PostedOn)
                                .Skip(pageNo * pageSize)
                                .Take(pageSize)
                                .Fetch(p => p.Category)
                                .ToList();

            var postIds = posts.Select(p=>p.Id).ToList();

            return _session.Query<Post>()
                    .Where(p => postIds.Contains(p.Id))
                    .OrderByDescending(p => p.PostedOn)
                    .FetchMany(p => p.Tags)
                    .ToList();
        }

        public int TotalPosts()
        {
            return _session.Query<Post>().Where(p => p.Published).Count();
        }
    }
}
