﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AtomLab.Domain;
using AtomLab.Domain.Infrastructure;
using YangKai.BlogEngine.ICommandServices;
using YangKai.BlogEngine.Modules.BoardModule.Objects;
using YangKai.BlogEngine.Modules.CommonModule.Objects;
using YangKai.BlogEngine.Modules.PostModule.Objects;
using YangKai.BlogEngine.Modules.PostModule.Services;

namespace YangKai.BlogEngine.CommandServices
{
    public class CommandService : ICommandService
    {
        private readonly IUnitOfWork _context;

        public CommandService(IUnitOfWork context)
        {
            _context = context;
        }

        public void RunCommand(IEvent e)
        {
            EventProcessor.ExecuteEvent(e);
            _context.Commit();
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            EventProcessor.CreateEntity(entity);
            _context.Commit();
        }

        public void UpdatePost(string postUrl, Post data, bool existThumbnail)
        {
            new PostService().Update(postUrl, data, existThumbnail);
            _context.Commit();
        }
    }
}
