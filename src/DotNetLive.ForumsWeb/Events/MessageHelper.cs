using Newtonsoft.Json;
using System.Text;

namespace DotNetLive.ForumsWeb.Events
{
    public static class MessageHelper
    {
        public static byte[] GetMessageBody(object eventData)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventData));
        }

        public static T GetMessage<T>(byte[] datas)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(datas));
        }
    }
}
