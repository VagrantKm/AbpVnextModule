﻿using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Tudou.Abp.IdentityServer.Clients;

namespace Tudou.Abp.IdentityServer
{
    public class AllowedCorsOriginsCacheItemInvalidator : 
        ILocalEventHandler<EntityChangedEventData<Client>>,
        ILocalEventHandler<EntityChangedEventData<ClientCorsOrigin>>,
        ITransientDependency
    {
        protected IDistributedCache<AllowedCorsOriginsCacheItem> Cache { get; }

        public AllowedCorsOriginsCacheItemInvalidator(IDistributedCache<AllowedCorsOriginsCacheItem> cache)
        {
            Cache = cache;
        }
        
        public async Task HandleEventAsync(EntityChangedEventData<Client> eventData)
        {
            await Cache.RemoveAsync(AllowedCorsOriginsCacheItem.AllOrigins);
        }

        public async Task HandleEventAsync(EntityChangedEventData<ClientCorsOrigin> eventData)
        {
            await Cache.RemoveAsync(AllowedCorsOriginsCacheItem.AllOrigins);
        }
    }
}