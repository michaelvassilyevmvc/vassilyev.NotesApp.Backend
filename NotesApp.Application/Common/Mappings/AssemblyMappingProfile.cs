using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;

namespace NotesApp.Application.Common.Mappings
{
    public class AssemblyMappingProfile: Profile
    {
        // Передаем из конструктора сборку в метод ApplyMappingsFromAssembly
        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingsFromAssembly(assembly);

        // находим в сборке все методы которые относятся к IMapWith
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(type => type.GetInterfaces().Any(i =>
            {
                // возвращаем все типы данных где generic и generic IMapWith<>
                return i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>); 
            })).ToList();

            // Для каждого типа создаем метод с параметром текущим объектом
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}
