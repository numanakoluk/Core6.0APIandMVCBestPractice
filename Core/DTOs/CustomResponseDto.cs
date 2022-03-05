using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            //Error default already null but still writed
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode};
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            //Error default already null but still writed
            return new CustomResponseDto<T> { StatusCode = statusCode};
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            //Error default already null but still writed
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors=errors};
        }

        public static CustomResponseDto<T> Fail(int statusCode,string error)
        {
            //Error default already null but still writed
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors =  new List<string> { error } };
        }
    }
}
