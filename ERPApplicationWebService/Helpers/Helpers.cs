using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ERPApplicationWebService.Helpers
{
    public static class Helpers
    {

        public static byte[] ConvertImageFromBase64ToByteArray(string imageBase64)
        {
            if (!string.IsNullOrWhiteSpace(imageBase64))
            {
                var elements = imageBase64.Split(new String[] { ";base64," }, StringSplitOptions.None)[1].Trim();
                byte[] array = Convert.FromBase64String(elements);
                return array;
            }
            return null;
        }

        public static string ConvertImageFromByteArrayToBase64(byte[] array)
        {
            if (array != null)
            {
               return Convert.ToBase64String(array);
            }
            return null;
        }


    }
}