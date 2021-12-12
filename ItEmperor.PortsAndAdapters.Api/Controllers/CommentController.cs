using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItEmperor.PortsAndAdapters.DalLayer.Repository;
using ItEmperor.PortsAndAdapters.ReadModelAbstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ItEmperor.PortsAndAdapters.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentProvider _commentProvider;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CommentController(ICommentProvider commentProvider, 
            IRepository<Comment> commentRepository, 
            IDateTimeProvider dateTimeProvider)
        {
            _commentProvider = commentProvider ?? throw new ArgumentNullException(nameof(commentProvider));
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<CommentDto>> GetAll()
        {
            return await _commentProvider.GetCommentsAsync();
        }

        [Route("")]
        [HttpPost]
        public async Task Add([FromBody] NewCommentModel model)
        {
            var comment = new Comment(new CommentContent(model.Comment),
                new Author(model.AuthorName),
                _dateTimeProvider);

            await _commentRepository.AddAsync(comment);
        } 
    }
}