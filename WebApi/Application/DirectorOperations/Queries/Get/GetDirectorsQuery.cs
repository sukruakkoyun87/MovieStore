using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Queries.Get
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DirectorViewModel> Handle()
        {
            var directors=_context.Directors
            .Include(x=>x.Movies)
            .ToList().OrderBy(x => x.Id);
            List<DirectorViewModel> directorViewModels=_mapper.Map<List<DirectorViewModel>>(directors);
            return directorViewModels;
        }


    }
    public class DirectorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> Movies { get; set; }
    }
}