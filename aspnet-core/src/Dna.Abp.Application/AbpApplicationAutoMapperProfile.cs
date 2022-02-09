﻿using AutoMapper;
using Dna.Abp.Authors;
using Dna.Abp.Books;

namespace Dna.Abp;

public class AbpApplicationAutoMapperProfile : Profile
{
    public AbpApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
    }
}
