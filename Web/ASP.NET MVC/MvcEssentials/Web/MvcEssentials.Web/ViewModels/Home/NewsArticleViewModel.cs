﻿namespace MvcEssentials.Web.ViewModels.Home
{
    using Infrastructure.Mapping;
    using MvcEssentials.Data.Models;

    public class NewsArticleViewModel : IMapFrom<NewsArticle>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}