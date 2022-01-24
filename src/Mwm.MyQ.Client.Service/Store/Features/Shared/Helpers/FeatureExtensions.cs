﻿using Fluxor;
using Mwm.MyQ.Client.Service.Models;
using Mwm.MyQ.Client.Service.Store.State.Shared;
using Mwm.MyQ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwm.MyQ.Client.Service.Store.Features.Shared.Helpers {
    public static class FeatureExtensions {

        public static TEntity FindById<TEntity>(this IState<EntityState<TEntity>> entitiesState, int id) where TEntity : INamedEntity {
            //return (entitiesState.Value.Entities != null) ? entitiesState.Value.FindById(id) : default;
            return (entitiesState.Value.Entities != null) ? entitiesState.Value.Entities.SingleOrDefault(e => e.Id == id) : default;
        }

        public static bool HasValue<TEntity>(this IState<EntityState<TEntity>> entitiesState, bool isNotEmpty = false) where TEntity : INamedEntity {

            return (isNotEmpty) ? entitiesState.Value.Entities != null && entitiesState.Value.Entities.Count() > 0 :
                                  entitiesState.Value.Entities != null;
        }

        public static bool IsLoading<TEntity>(this IState<EntityState<TEntity>> entitiesState) where TEntity : INamedEntity {
            return entitiesState.Value.IsLoading;
        }

        public static bool HasErrors<TEntity>(this IState<EntityState<TEntity>> entitiesState) where TEntity : INamedEntity {
            return entitiesState.Value.HasCurrentErrors;
        }

        public static bool HasValue<TModel, TEntity>(this IState<ModelState<TModel, TEntity>> modelsState, bool isNotEmpty = false)
            where TModel : EntityModel<TEntity>
            where TEntity : INamedEntity {
            return (isNotEmpty) ? modelsState.Value.Models != null && modelsState.Value.Models.Count() > 0 && !modelsState.IsLoading() :
                                  modelsState.Value.Models != null && !modelsState.IsLoading();
        }

        public static bool IsLoading<TModel, TEntity>(this IState<ModelState<TModel, TEntity>> modelsState)
            where TModel : EntityModel<TEntity>
            where TEntity : INamedEntity {
            return modelsState.Value.IsLoading;
        }

        public static bool HasErrors<TModel, TEntity>(this IState<ModelState<TModel, TEntity>> modelsState)
            where TModel : EntityModel<TEntity>
            where TEntity : INamedEntity {
            return modelsState.Value.HasCurrentErrors;
        }
    }
}
