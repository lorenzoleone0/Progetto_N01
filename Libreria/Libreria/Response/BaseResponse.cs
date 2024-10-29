﻿using System.Text.Json.Serialization;

namespace Libreria.Response
{
    public class BaseResponse<T>
        {
            public bool Success { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public List<string>? Errors { get; set; } = null;
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public T? Result { get; set; } = default;


        }
    }

