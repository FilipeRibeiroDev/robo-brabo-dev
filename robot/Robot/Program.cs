using Robot;
using Robot.Driver;


const string BASE_URL = "http://localhost:5000/Endereco/";

var request = new RequestProvider();
var buscar = new BuscarCepDriver();

while (true)
{   
    var endereco = await request.GetAsync<EnderecoModel>(BASE_URL + "ObterCepParaTratamento?robo=robot_dev_1");

    if (endereco != null && !string.IsNullOrEmpty(endereco.CEP))
    {
        Console.WriteLine($"Consultando CEP: {endereco.CEP} para tratamento");

        buscar.BuscarCep(endereco);

        Console.WriteLine($"Atualizando dados do CEP: {endereco.CEP} com o bairro {endereco.Bairro}");

        await request.PutAsync(BASE_URL + "AtualizarDados", endereco);
    }
    Thread.Sleep(TimeSpan.FromSeconds(1));
}

