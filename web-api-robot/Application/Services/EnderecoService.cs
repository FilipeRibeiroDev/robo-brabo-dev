using Application.Adapters;
using Domain.Entidades;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(List<EnderecoModel> enderecos)
        {
            var domains = EnderecoAdapter.Map(enderecos);
            await _repository.Add(domains);
        }

        public async Task AtualizarDados(EnderecoModel endereco)
        {
            var domain = await _repository.Get(endereco.Id);

            if(domain == null)
            {
                throw new Exception("Cep não localizado");
            }

            domain.Logradouro = endereco.Logradouro;
            domain.Bairro = endereco.Bairro;
            domain.UF = endereco.UF;
            domain.Status = Domain.Enums.EnumStatus.Finalizado;

            await _repository.AtualizarDados(domain);
        }

        public async Task<List<EnderecoModel>> List()
        {
            var enderecos = await _repository.List();
            return EnderecoAdapter.Map(enderecos);
        }

        public async Task<EnderecoModel> ObterCepParaTratamento(string roboo)
        {
            var domain = await _repository.ObterCepParaTratamento(roboo);

            if (domain == null) return default;

            domain.Status = Domain.Enums.EnumStatus.EmAndamento;
            domain.Robo = roboo;

            await _repository.AtualizarDados(domain);

            return EnderecoAdapter.Map(domain);
        }
    }
}
