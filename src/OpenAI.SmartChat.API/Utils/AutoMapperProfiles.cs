using AutoMapper;
using OpenAI.SmartChat.API.DTO;
using static OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel.ImageCreateResponse;

namespace OpenAI.SmartChat.API.Utils;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ImageDataResult, ImageResultDto>().ReverseMap();
    }
}