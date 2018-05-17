using GenericLibsBase;

namespace Xunit.Extensions.AssertExtensions
{
    public static class SuccessOrErrorExtensions
    {
        internal static void ShouldBeValid(this ISuccessOrErrors status, bool isValid = true)
        {
            if (isValid)
                Xunit.Assert.True(status.IsValid, string.Join("\n", status.Errors));
            else
                Xunit.Assert.False(status.IsValid, "This should have returned some errors");
        }

        internal static void ShouldBeValid<T>(this ISuccessOrErrors<T> status, bool isValid = true)
        {
            ShouldBeValid(status as ISuccessOrErrors, isValid);
        }
    }

}