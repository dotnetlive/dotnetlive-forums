using AutoMapper;
using DotNetLive.Forums.Entities;
using DotNetLive.ForumsWeb.Models.TopicViewModels;

namespace DotNetLive.ForumsWeb.Models
{
    public class ModelsMaping : Profile
    {
        public ModelsMaping()
        {
            CreateMap<Topic, TopicViewModel>();
        }
    }
}
