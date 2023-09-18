using Microsoft.AspNetCore.Http;
using Rugal.CodeDefender.Model;

namespace Rugal.CodeDefender.Extention
{
    public static class IFormFileExtention
    {
        public const string NotAllowMessage = "不允許的檔案類型";
        public static void VerifyImage(this IFormFile File)
        {
            var Types = new[] { FileType.Jpg, FileType.Jpeg, FileType.Png };
            if (!IsVerify(File, Types))
                throw new Exception(NotAllowMessage);
        }
        public static void VerifyPdf(this IFormFile File)
        {
            if (!IsVerify(File, FileType.Pdf))
                throw new Exception(NotAllowMessage);
        }
        public static void Verify(this IFormFile File, params FileType[] Types)
        {
            if (!IsVerify(File, Types))
                throw new Exception(NotAllowMessage);
        }

        public static bool IsVerify(this IFormFile File, params FileType[] Types)
        {
            if (File is null)
                return true;

            var Extension = Path.GetExtension(File.FileName).TrimStart('.');
            var LowerTypes = Types
                .Select(Item => Item.ToString().ToLower());

            var IsContains = LowerTypes.Contains(Extension.ToLower());
            return IsContains;
        }
    }
}
