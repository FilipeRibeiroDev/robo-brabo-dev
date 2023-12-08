using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IEnderecoRepository
    {
        Task Add(List<Endereco> enderecos);
        Task AtualizarDados(Endereco endereco);
        Task<Endereco?> ObterCepParaTratamento(string roboo);
        Task<Endereco?> Get(int id);
        Task<List<Endereco>> List();
    }
}
