using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using PhotographyApi.Data;
using PhotographyApi.Data.Contracts;

namespace PhotographyApi
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer(bool useMock = false)
        {
            var container = new UnityContainer();
            container.RegisterType<IPhotographyUow, PhotoManagerUow>();
            container.RegisterType<IPhotographyContext, PhotographyContext>();
            return container;
        }
    }
}