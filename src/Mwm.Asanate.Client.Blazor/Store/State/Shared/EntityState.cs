﻿using Mwm.Asanate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwm.Asanate.Client.Blazor.Store.State.Shared {
    public class EntityState<TEntity> where TEntity : INamedEntity {

        public bool IsLoading { get; }

        public string? CurrentErrorMessage { get; }

        public IEnumerable<TEntity>? Entities { get; }

        public TEntity? CurrentEntity { get; }

        public EntityState() : this(false, null, null, default) {
        }

        public EntityState(bool isLoading = false, string? currentErrorMessage = null, IEnumerable<TEntity>? entities = null, TEntity? currentEntity = default) {
            IsLoading = isLoading;
            CurrentErrorMessage = currentErrorMessage;
            Entities = entities;
            CurrentEntity = currentEntity;
        }

        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
    }

}
