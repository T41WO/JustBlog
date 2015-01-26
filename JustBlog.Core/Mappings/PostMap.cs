using FluentNHibernate.Mapping;
using JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Mappings
{
    public class PostMap: ClassMap<Post>
    {
        public PostMap()
        {
            /*
             * If the table name is different 
             * then we should map 
             * the table with the class 
             * using the Table extension method
             */
            //Table("tbl_posts");

            Id(x => x.Id);


            /*
             * If the generated column name 
             * has to be different from the property 
             * name then we should pass the column name 
             * using the Column extension method
             */
            Map(x => x.Title)
                .Length(500)
                //.Column("post_title")
                .Not.Nullable();

            Map(x => x.ShortDescription)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Meta)
                .Length(1000)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(200)
                .Not.Nullable();

            Map(x => x.Published)
                .Not.Nullable();

            Map(x => x.PostedOn)
                .Not.Nullable();

            Map(x => x.Modified);

            //Used for Many-To-One relationships
            References(x => x.Category)
                .Column("Category")
                .Not.Nullable();

            //Used to Many-To-Many relationships
            HasManyToMany(x => x.Tags)
                .Table("PostTagMap");
        }
    }
}
