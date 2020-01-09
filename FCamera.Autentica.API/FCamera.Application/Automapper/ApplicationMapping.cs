using AutoMapper;

namespace FCamera.Application.Automapper
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping()
        {
            //CreateMap<Pessoa, Models.PessoaModel>()
            //.ForPath(x => x.Id, w => w.MapFrom(s => s.Id))

            //// Endereco
            //.ForMember(x => x.Endereco, w => w.MapFrom(s => s.Endereco))

            ////.ForSourceMember(x => x.Id, w => w.DoNotValidate())
            //.ForSourceMember(x => x.Inserido, w => w.DoNotValidate())
            //.ForSourceMember(x => x.Removido, w => w.DoNotValidate())
            //.ForSourceMember(x => x.Ativo, w => w.DoNotValidate());
        }
    }
}
