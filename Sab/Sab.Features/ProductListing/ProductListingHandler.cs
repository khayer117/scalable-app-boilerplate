﻿using Microsoft.Extensions.Logging;
using Sab.Infrastructure;
using Sab.ProductListing.Features.Processors;
using System.Threading.Tasks;


namespace Sab.ProductListing.Features.ProductListing
{
    public class ProductListingHandler : ICommandHandler<ProductListingCommand , NoCommandResult>
    {
        private ILogger<ProductListingHandler> _logger;
        private readonly IServiceExecutor _serviceExecutor;

        public ProductListingHandler(ILogger<ProductListingHandler> logger,
            IServiceExecutor serviceExecutor)
        {
            _logger = logger;
            _serviceExecutor = serviceExecutor;

        }
        public async Task<NoCommandResult> Handle(ProductListingCommand command)
        {
            this._logger.LogInformation($"Product listing Handler : {command.ProductCategory}");

            await _serviceExecutor.Execute<IProcessorA>(10);

            return await Task.FromResult(NoCommandResult.Instance);
        }
    }
}
