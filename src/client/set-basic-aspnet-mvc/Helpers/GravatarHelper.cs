﻿using System.Security.Cryptography;
using System.Web.Mvc;

namespace set_basic_aspnet_mvc.Helpers
{
    public static class GravatarHelper
    {
        public static string Gravatar(this HtmlHelper helper, string email, int size)
        {
            const string result = "<img src=\"{0}\" alt=\"gravatar\" class=\"gravatar\" />";
            var url = GetGravatarURL(email, size);
            return string.Format(result, url);
        }

        public static string GetGravatarURL(string email, int size)
        {
            return string.Format("//gravatar.com/avatar/{0}?s={1}&r=PG", EncryptMD5(email), size);
        }

        static string EncryptMD5(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var valueArray = System.Text.Encoding.ASCII.GetBytes(value);
            valueArray = md5.ComputeHash(valueArray);
            var encrypted = string.Empty;
            for (var i = 0; i < valueArray.Length; i++)
            {
                encrypted += valueArray[i].ToString("x2").ToLower();
            }
            return encrypted;
        }
    }
}