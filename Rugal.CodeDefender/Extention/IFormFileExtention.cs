using Microsoft.AspNetCore.Http;
using Rugal.CodeDefender.Model;

namespace Rugal.CodeDefender.Extention
{
    public static class IFormFileExtention
    {
        public const string NotAllowMessage = "不允許的檔案類型";
        public static void Verify(this IFormFile File, params FileType[] Types)
        {
            if (!IsVerify(File, Types))
                throw new Exception(NotAllowMessage);
        }

        public static bool IsVerify(this IFormFile File, params FileType[] Types)
        {
            var Extension = Path.GetExtension(File.FileName);
            var LowerTypes = Types
                .Select(Item => Item.ToString().ToLower());

            var IsContains = LowerTypes.Contains(Extension.ToLower());
            return IsContains;
        }
    }
}
