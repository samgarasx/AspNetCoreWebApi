using Newtonsoft.Json;

namespace AspNetCoreWebApi.Helpers
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonResponse<T>
    {
        [JsonProperty("ok")]
        public bool Ok { get; private set; }
        [JsonProperty("data")]
        public T Data { get; private set; }
        [JsonProperty("error")]
        public object Error { get; private set; }

        public static JsonResponse<T> Success(T data)
        {
            return new JsonResponse<T>
            {
                Ok = true,
                Data = data
            };
        }

        public static JsonResponse<T> Failure(object error)
        {
            return new JsonResponse<T>
            {
                Ok = false,
                Error = error
            };
        }

        public bool ShouldSerializeData()
        {
            return Ok;
        }

        public bool ShouldSerializeError()
        {
            return !Ok;
        }
    }
}
