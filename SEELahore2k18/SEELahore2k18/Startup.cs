﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEELahore2k18.Startup))]
namespace SEELahore2k18
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
