using System.ComponentModel;
using GestioneSagre.GenericServices.Converters;
using GestioneSagre.GenericServices.TypeConverters;
using Microsoft.Extensions.DependencyInjection;

namespace GestioneSagre.GenericServices.Extensions;

public static class GenericExtensions
{
    public static IServiceCollection AddPolicyCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy($"{policyName}", policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        return services;
    }

    //Implementazione estratta dal repository: https://github.com/marcominerva/DateTimeOnly/blob/master/DateTimeOnly.WebApi/Program.cs
    public static IMvcBuilder AddJsonDateTimeConfiguration(this IMvcBuilder builder)
    {
        builder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
            options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
        });

        return builder;
    }

    //Implementazione estratta dal repository: https://github.com/marcominerva/TinyHelpers/blob/master/src/TinyHelpers.AspNetCore/Extensions/ServiceCollectionExtensions.cs
    public static IServiceCollection AddDateOnlyTimeOnly(this IServiceCollection services)
    {
        TypeDescriptor.AddAttributes(typeof(DateOnly), new TypeConverterAttribute(typeof(DateOnlyTypeConverter)));
        TypeDescriptor.AddAttributes(typeof(TimeOnly), new TypeConverterAttribute(typeof(TimeOnlyTypeConverter)));

        return services;
    }

    //Implementazioni estratte dal repository: https://github.com/marcominerva/TinyHelpers/blob/master/src/TinyHelpers/Extensions/DateTimeExtensions.cs
    public static DateOnly ToDateOnly(this DateTime dateTime) => DateOnly.FromDateTime(dateTime);
    public static TimeOnly ToTimeOnly(this DateTime dateTime) => TimeOnly.FromDateTime(dateTime);
    public static TimeOnly ToTimeOnly(this TimeSpan timeSpan) => TimeOnly.FromTimeSpan(timeSpan);
}