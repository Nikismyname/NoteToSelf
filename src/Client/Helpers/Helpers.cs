using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NoteToSelf.Client.Helpers
{
    public static class Helpers
    {
        public static string PrintInfo(object obj, string name)
        {
            Type type = obj.GetType(); 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{type.Name}: {name}------------------------------------------------------------------>");
            Rec(type, sb, 0, obj);
            sb.AppendLine("-------------------------------------------------------------------------------<");
            return sb.ToString();
        }

        private static void Rec(Type type, StringBuilder sb, int indent, object obj)
        {
            FieldInfo[] publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            PropertyInfo[] publicProperties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            MethodInfo[] publicMehtods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (FieldInfo f in publicFields)
            {
                PrintField(f, sb, indent, obj);
            }

            foreach (PropertyInfo p in publicProperties)
            {
                PrintProperty(p, sb, indent, obj);
            }

            PrintMethodInfos(publicMehtods, sb, indent);
        }

        private static void PrintField(FieldInfo field, StringBuilder sb, int indent, object obj)
        {
            Type type = field.FieldType;

            sb.AppendLine($"{new string(' ', indent)} field name: {field.Name}, type: {field.FieldType.Name}, Value: {field.GetValue(obj)}");

            if (type.IsValueType == false)
            {
                Rec(type, sb, indent + 4, obj);
            }
        }

        private static void PrintProperty(PropertyInfo property, StringBuilder sb, int indent, object obj)
        {
            Type type = property.PropertyType;

            sb.AppendLine($"{new string(' ', indent)} Property Name: {property.Name}, type: {property.PropertyType.Name}, Value: {property.GetValue(obj)}");
            //sb.AppendLine($"{new string(' ', indent)} Property Name: {property.Name}, type: {property.PropertyType.Name}");

            if (type.IsValueType == false)
            {
                Rec(type, sb, indent + 4, obj);
            }
        }

        private static void PrintMethodInfos(MethodInfo[] methods, StringBuilder sb, int indent)
        {
            foreach (var method in methods)
            {
                Type returnType = method.ReturnType;
                ParameterInfo[] parameters = method.GetParameters();
                sb.AppendLine($"{new string(' ',indent)} {method.Name} returns: {returnType.Name} parameters: [{string.Join(", ", parameters.Select(x=>$"{x.ParameterType.Name}: {x.Name}"))}]");
            }
        }
    }
}
