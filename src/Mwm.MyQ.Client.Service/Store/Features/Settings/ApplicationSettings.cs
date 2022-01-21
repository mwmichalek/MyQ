﻿using Mwm.MyQ.Client.Service.Models;
using Mwm.MyQ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwm.MyQ.Client.Service.Store.Features.Settings;

public interface IApplicationSetting { }

public interface IPrimativeApplicationSetting : IApplicationSetting { }

public interface IObjectApplicationSetting : IApplicationSetting { }

public abstract class ObjectApplicationSetting<TClass> : IObjectApplicationSetting where TClass : class {

    public TClass PreviousValue { get; set; }

    public TClass CurrentValue { get; set; }

}

public abstract class PrimativeApplicationSetting<TPrimative> : IPrimativeApplicationSetting where TPrimative : struct {

    public TPrimative PreviousValue { get; set; }

    public TPrimative CurrentValue { get; set; }

}

public interface IModelFilter<TModel, TEntity> : IApplicationSetting where TModel : EntityModel<TEntity>
                                                                     where TEntity : INamedEntity {
    IEnumerable<TModel> Filter(IEnumerable<TModel> entities);

    bool IsApplied { get; }

    string Title { get; }
}



public interface IPrimativeModelFilter<TModel, TEntity, TPrimative> : IModelFilter<TModel, TEntity> where TModel : EntityModel<TEntity> 
                                                                                                    where TEntity : INamedEntity
                                                                                                    where TPrimative : struct {
    TPrimative FilterValue { get; set; }
}

public interface IObjectModelFilter<TModel, TEntity, TClass> : IModelFilter<TModel, TEntity> where TModel : EntityModel<TEntity>
                                                                                             where TEntity : INamedEntity
                                                                                             where TClass : class { 
    TClass FilterValue { get; set; }
}

public abstract class ModelFilter<TModel, TEntity> : IModelFilter<TModel, TEntity> where TModel : EntityModel<TEntity>
                                                                                   where TEntity : INamedEntity { 

    public abstract IEnumerable<TModel> Filter(IEnumerable<TModel> entities);

    public bool IsApplied { get; set; } = false;

    public virtual string Title => "Name == Something";

}


public abstract class PrimativeModelFilter<TModel, TEntity, TPrimative> : ModelFilter<TModel, TEntity>, 
                                                                          IPrimativeModelFilter<TModel, TEntity, TPrimative> where TModel : EntityModel<TEntity>
                                                                                                                             where TEntity : INamedEntity
                                                                                                                             where TPrimative : struct {
    public TPrimative FilterValue { get; set; }

}

public abstract class ObjectModelFilter<TModel, TEntity, TClass> : ModelFilter<TModel, TEntity>,
                                                                   IObjectModelFilter<TModel, TEntity, TClass> where TModel : EntityModel<TEntity>
                                                                                                               where TEntity : INamedEntity
                                                                                                               where TClass : class {
    public TClass FilterValue { get; set; }                                                                                
}

