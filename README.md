# DevFreela.Payments

Projeto desenvolvido durante o curso ***Formação ASP.NET Core*** do **LuisDev**.

O projeto foi desenvolvido como uma WebAPI em .NET 7, utilizando tecnologias como:

- 🛠️ Swagger
- 🛠️ Clean Architecture
- 🛠️ CQRS
- 🛠️ MediatR
- 🛠️ Mensageria com RabbitMQ

A API é uma versão simulada para um microserviço de gateway de pagamento que pode receber uma solicitação via um post HTTP ou mensagem com o RabbitMQ. O serviço somente retorna para a aplicação que solicita via post HTTP um status 204 NoContent, ou retorna o id do projeto pago via mensagem.

### 📀 Swagger

O Swagger é um framework composto por diversas ferramentas que, independente da linguagem, auxilia a descrição, consumo e visualização de serviços de uma API REST. Através dessa ferramenta é possível executar os métodos implementados nos controllers da API assim como obter uma documentação completa da API.

---
### 📀 Clean Architecture

***Clean Architecture*** é uma arquitetura de software com o objetivo de padronizar e organizar o código desenvolvido, favorecendo reusabilidade e separação de responsabilidades. Sendo bem utilizada com DDD, devido a ser centrada no domínio, onde o seu acoplamento direcionado preza que o núcleo não dependa de nada, aumenta a testabilidade.

--- 

### 📀 CQRS

**C**ommand **Q**uery **R**esponsibility **S**egregation, o **CQRS**, é um padrão de arquitetura que busca a separação da leitura e da escrita em dois modelos: query e command, respectivamente.

- **Query model**: responsável pela leitura dos dados do banco e pela atualização da interface gráfica.
- **Command model**: responsável pela escrita de dados no banco e pela validação dos dados.

---

### 📀 MediatR

O Mediator é um padrão de projeto Comportamental criado pelo GoF, que nos ajuda a garantir um baixo acoplamento entre os objetos de nossa aplicação. Ele permite que um objeto se comunique com outros sem saber suas estruturas. Em outras palavras podemos dizer que o Mediator Pattern gerencia as interações de diferentes objetos. Através de uma classe mediadora, centraliza todas as interações entre os objetos, visando diminuir o acoplamento e a dependência entre eles. Desta forma, neste padrão, os objetos não conversam diretamente entre eles, toda comunicação precisa passar pela classe mediadora.

---
### 📀 Mensageria com RabbitMQ

***Mensageria*** consiste na utilização de mensagens para estabelecer a comunicação síncrona ou assíncrona entre aplicações. Em mensageria, uma mensagem pode ser definida como uma estrutura de dados composta por meta-dados como host de origem/destino, fila de destino, etc, além de dados fornecidos pela aplicação, por exemplo os dados de um cliente a ser cadastrado.

***RabbitMQ*** é um servidor de mensageria de código aberto (open source) desenvolvido em Erlang, implementado para suportar mensagens em um protocolo denominado Advanced Message Queuing Protocol (AMQP). Ele possibilita lidar com o tráfego de mensagens de forma rápida e confiável, além de ser compatível com diversas linguagens de programação, possuir interface de administração nativa e ser multiplataforma.
