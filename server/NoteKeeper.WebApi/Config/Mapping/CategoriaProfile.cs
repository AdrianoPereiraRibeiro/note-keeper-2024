﻿using AutoMapper;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.WebApi.Views;

namespace NoteKeeper.WebApi.Config.Mapping
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, ListarCategoriaViewModel>();
            CreateMap<Categoria, VisualizarCategoriaViewModel>();

            CreateMap<InserirCategoriaViewModel, Categoria>();
            CreateMap<EditarCategoriaViewModel, Categoria>();

            CreateMap<Nota, ListarNotaViewModel>();
        }
    }
}
