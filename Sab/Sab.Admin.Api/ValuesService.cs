﻿using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Sab.Admin.Api
{
    public interface IValuesService
    {
        IEnumerable<string> FindAll();
        string Find(int id);
    }

    public class ValuesService : IValuesService
    {
        private readonly ILogger<ValuesService> _logger;

        public ValuesService(ILogger<ValuesService> logger)
        {
            this._logger = logger;
        }

        public IEnumerable<string> FindAll()
        {
            this._logger.LogDebug("{method} called", nameof(this.FindAll));

            return new[] { "value1", "value2" };
        }

        public string Find(int id)
        {
            this._logger.LogDebug("{method} called with {id}", nameof(this.Find), id);

            return $"value{id}";
        }
    }
}
