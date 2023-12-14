using System.ComponentModel.DataAnnotations;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
public class AtLeastOnePropertyAttribute : ValidationAttribute
{
    // Have to override IsValid
    public override bool IsValid(object value)
    {
        //چک کردن اینکه حداقل یکی از مقادیر پر شده باشد
        var typeInfo = value.GetType();

        var propertyInfo = typeInfo.GetProperties();

        foreach (var property in propertyInfo)
        {
            if (null != property.GetValue(value, null))
            {
                return true;
            }
        }

        return false;
    }
}