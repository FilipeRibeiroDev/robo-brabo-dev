using Robot;
using Robot.Driver;


const string BASE_URL = "https://localhost:7054/Endereco/";

var request = new RequestProvider();
var buscar = new BuscarCepDriver();

while (true)
{
    var endereco = await request.GetAsync<EnderecoModel>(BASE_URL + "ObterCepParaTratamento?robo=robot_dev_1");

    if (endereco != null && !string.IsNullOrEmpty(endereco.CEP))
    {
        buscar.BuscarCep(endereco);

        await request.PutAsync(BASE_URL + "AtualizarDados", endereco);
    }
    Thread.Sleep(TimeSpan.FromSeconds(1));
}

