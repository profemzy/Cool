using AutoMapper;
using Cool.Models;
using Cool.Models.Dto;

namespace Cool
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => { config.CreateMap<BookDto, Book>().ReverseMap(); });

            return mappingConfig;
        }
    }
}
