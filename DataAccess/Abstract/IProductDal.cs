﻿using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository <Product>
    {

    }
}
