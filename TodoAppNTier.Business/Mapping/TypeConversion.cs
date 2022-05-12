using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DTO.Interfaces;

namespace TodoAppNTier.Business.Mapping
{
    public static class TypeConversion
    {
        public static TResult Conversion<T,TResult>(T model) where TResult:class,new()
        {
            TResult result = new TResult();
            typeof(T).GetProperties().ToList().ForEach(x =>
            {
                PropertyInfo property = typeof(T).GetProperty(x.Name);
                property.SetValue(result,x.GetValue(model));
            });

            return result;
        }
    }
}
