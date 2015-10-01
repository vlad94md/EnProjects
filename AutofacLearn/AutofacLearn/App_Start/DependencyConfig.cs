using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using System.Reflection;
using Autofac.Builder;
using Services;
using DAL;

namespace WebUI.App_Start
{
    public static class DependencyConfig
    {
        private static IContainer Container { get; set; }
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //builder.RegisterType<BookRepository>().As<IRepository<Book>>();
            builder.RegisterType<BookService>().As<IBookService>();
            //builder.RegisterType<BookRepository>().As(IBookService>();

            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}