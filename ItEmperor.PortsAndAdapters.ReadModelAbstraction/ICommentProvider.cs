using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItEmperor.PortsAndAdapters.ReadModelAbstraction
{
    public interface ICommentProvider
    {
        public Task<ICollection<CommentDto>> GetCommentsAsync();
    }
}