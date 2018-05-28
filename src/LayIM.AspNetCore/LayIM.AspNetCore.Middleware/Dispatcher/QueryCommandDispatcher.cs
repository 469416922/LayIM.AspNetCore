﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace LayIM.AspNetCore.Middleware.Dispatcher
{
    public class QueryCommandDispatcher<TResult> : CommandDispatcher<TResult>
    {
        protected override string AllowMethod => HttpGet;

        private readonly Func<HttpContext, TResult> executeFunction;
        public QueryCommandDispatcher(Func<HttpContext, TResult> executeFunction)
        {
            this.executeFunction = executeFunction;
        }

        protected override Func<HttpContext, TResult> ExecuteFunction => executeFunction;
    }
}
