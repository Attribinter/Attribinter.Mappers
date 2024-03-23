﻿namespace Attribinter.Mappers.AttribinterMappersServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using System;

using Xunit;

public sealed class AddAttribinterMappers
{
    private static IServiceCollection Target(IServiceCollection services) => AttribinterMappersServices.AddAttribinterMappers(services);

    private readonly IServiceProvider ServiceProvider;

    public AddAttribinterMappers()
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        ServiceProvider = host.Build().Services;
    }

    [Fact]
    public void NullServiceCollection_ArgumentNullException()
    {
        var exception = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void ValidServiceCollection_ReturnsSameServiceCollection()
    {
        var serviceCollection = Mock.Of<IServiceCollection>();

        var actual = Target(serviceCollection);

        Assert.Same(serviceCollection, actual);
    }

    [Fact]
    public void IArgumentRecorderFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IArgumentRecorderFactory>();

    [Fact]
    public void IMappedArgumentRecorderFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IMappedArgumentRecorderFactory>();

    [Fact]
    public void IBoolDelegateMappedArgumentRecorderFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IBoolDelegateMappedArgumentRecorderFactory>();

    [Fact]
    public void IVoidDelegateMappedArgumentRecorderFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IVoidDelegateMappedArgumentRecorderFactory>();

    [AssertionMethod]
    private void ServiceCanBeResolved<TService>() where TService : notnull
    {
        var service = ServiceProvider.GetRequiredService<TService>();

        Assert.NotNull(service);
    }
}
