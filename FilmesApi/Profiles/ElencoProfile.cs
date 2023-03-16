using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class ElencoProfile : Profile
    {

        public ElencoProfile()
        {
            CreateMap<CreatElencoDto, Elenco>();
        }
    }
}
