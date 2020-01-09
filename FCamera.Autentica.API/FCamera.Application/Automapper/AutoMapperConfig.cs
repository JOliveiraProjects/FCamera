using AutoMapper;

namespace FCamera.Application.Automapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapping());
            });
        }
    }
}
