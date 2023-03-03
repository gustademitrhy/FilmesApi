using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class AtorProfile : Profile
{
	public AtorProfile()
	{
		CreateMap<CreateAtorDto, Ator>();
        CreateMap<UpdateAtorDto, Ator>();
		CreateMap<Ator, UpdateAtorDto>();
        CreateMap<Ator, ReadAtorDto>();
    }
}
