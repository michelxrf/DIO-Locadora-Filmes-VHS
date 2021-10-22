# Pseudo Banco de Dados para uma locadora VHS

Esse é um projeto de estudo desenvolvido durante o bootcamp da Take Blip na plataforma Digital Inovation One.

O objetivo era criar um cadastro CRUD baseado no código disponibilizado durante a aula pelo professor Eliézer Zarpelão.

Minha ideia foi criar um pseudo banco de dados para uma locadora de filmes em VHS dos anos 1990.

Escolhi dar *flavor* retro para programa por ele ter sido desenvolvido em para o console. Por isso é um sistema para uma locadora de VHS.

O código tem pleno funcionamento com capacidade para:
- manter registro dos filmes disponíveis;
- manter registro de clientes cadastrados;
- registrar qual cliente alugou qual filme quando;
- salva o banco de dados em .csv

## Principais desafios enfrentados
### Parse de Enum ao ler .csv

Alguns campos da classe filme são Enums. E eu estava salvando os dados do programa em arquivo csv.

Quando estava criando o método para ler os dados dos arquivos .csv tive problemas para pegar de volta os dados dos enums. Eu não sabia como pegar a string referente a um Enum salva no csv e colocá-la no objeto filme dentro do programa.

Procurei bastante na documentação e acabei por solucionar assim:

```c#
Enum.Parse<Genero>(campos[3])
```
