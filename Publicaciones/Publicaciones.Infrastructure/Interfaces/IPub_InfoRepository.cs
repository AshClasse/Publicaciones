﻿using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface IPub_InfoRepository : IBaseRepository<Pub_Info>
    {
        // Métodos exclusivos de la entidad
    }
}