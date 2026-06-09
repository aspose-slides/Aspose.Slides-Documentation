---
title: Como Executar Tarefas em Segundo Plano no ASP.NET Core
type: docs
weight: 300
url: /pt/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- tarefa em segundo plano
- processamento em segundo plano
- serviço hospedado
- worker em segundo plano
- fila de trabalhos
- agendamento assíncrono de trabalhos
- processamento de arquivos no lado do servidor
- acompanhamento de progresso
- polling de status
- notificações SignalR
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- arquitetura escalável
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Execute tarefas em segundo plano no ASP.NET Core com serviços hospedados, filas de trabalhos e atualizações de status – processe e converta PPT, PPTX e ODP usando Aspose.Slides."
---
## **Introdução**

O processamento de arquivos (por exemplo, exportar uma apresentação para PDF) é uma tarefa típica do lado do servidor. Executá‑lo dentro do manipulador de requisição (enquanto o cliente aguarda) tem as seguintes desvantagens:

- *Interface pobre.* A página congela e o usuário precisa aguardar o resultado. Recarregar a página cancela a tarefa.
- *Tempo limite de operação.* Não podemos garantir que o processamento será concluído dentro de um período fixo, portanto o usuário provavelmente verá um "tempo limite de operação".
- *Baixa taxa de transferência e escalabilidade.* O ASP.NET Core foi projetado para processar muitas requisições de forma assíncrona. Tarefas intensivas em CPU e de longa duração bloqueiam threads e reduzem a taxa de transferência do servidor.
- *Baixa tolerância a falhas.* Se algo der errado durante uma tarefa de longa duração (por exemplo, um problema de conectividade), o processamento falha e deve ser reiniciado do início.

Uma [abordagem melhor](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) é agendar o trabalho assíncronamente, processá‑lo em segundo plano e retornar o resultado quando estiver pronto.

Neste modelo, o usuário pode ver o status atual (e pode sair ou recarregar a página), os recursos do servidor podem ser dimensionados eficientemente e ajustados de forma flexível, e uma política de repetição pode ser aplicada.

Uma solução típica de processamento em segundo plano inclui:

1. Uma API para agendar o trabalho.
2. Uma API para rastrear o status do trabalho.
3. Um worker em segundo plano para processar trabalhos agendados.
4. Uma API para armazenar e recuperar o resultado.

## **Exemplo de Tarefa em Segundo Plano**

Para demonstrar essa abordagem, considere o [exemplo de aplicativo web ASP.NET Core 3.1](./BackgroundJobDemo.zip). O app inclui uma página onde o usuário pode enviar uma apresentação e clicar em **Exportar para PDF**; a apresentação é então enviada e convertida para PDF por um worker em segundo plano.

## **Aplicativo Web**

O aplicativo web de exemplo (projeto *BackgroundJobDemo*) inclui:

- Página de upload de arquivos (Razor page "Upload").
- Página de progresso (Razor page "Progress" com algumas funções JavaScript que verificam e exibem o status).
- Controlador (`JobStatusController`) que fornece o status do processamento (`api/status/{jobId}`).
- Controlador (`JobResultController`) que retorna o arquivo PDF exportado (`api/result/{id}`).
- Worker em segundo plano baseado no serviço de hospedagem ASP.NET Core (veja a classe `WorkerService`).

Páginas Razor, controladores e o worker em segundo plano delegam o trabalho real por meio de interfaces definidas no projeto *BackgroundJobDemo.Common*. Implementações concretas de gerenciamento e processamento de trabalhos são fornecidas em projetos separados (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws*, etc.) e podem ser trocadas no método `Startup.ConfigureServices`.

Para fins de demonstração, a página "Upload" utiliza binding de modelo em buffer, mas para uploads de arquivos grandes, streaming sem buffer é [recomendado](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Para produção, considere os [aspectos de segurança](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations) relevantes. A página "Progress" consulta o status do trabalho agendado via JavaScript a cada dois segundos (esse intervalo é configurável). A consulta periódica é típica, mas para cenários mais avançados pode ser necessário notificações em tempo real via WebSockets (comunicações em tempo real estão fora do escopo deste artigo). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) é uma ferramenta simples mas poderosa para comunicações em tempo real.

Hospedar o worker em segundo plano no processo do servidor é conveniente para aplicações simples, mas tem [desvantagens](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Uma abordagem mais robusta e escalável é implantar o worker em um processo separado (veja, por exemplo, a aplicação console *BackgroundJobDemo.Worker*).

## **Implementação Básica**

O projeto *BackgroundJobDemo.Local* fornece uma implementação simples de gerenciamento de trabalhos usando um banco de dados SQLite (o caminho do banco de dados é configurado via `LocalConfig.DbFilePath`; veja `Startup.ConfigureServices`). Arquivos enviados e processados são armazenados no sistema de arquivos (o caminho da pasta de armazenamento é configurado via `LocalConfig.FileStorageFolderPath`; veja `Startup.ConfigureServices`). Para melhor tolerância a falhas e desempenho em aplicações reais, o agendamento de trabalhos deve ser implementado por meio de filas de mensagens (por exemplo, RabbitMQ, AWS SQS, Azure Storage Queue).

## **Implementação Distribuída Baseada na Amazon Web Services**

O projeto *BackgroundJobDemo.Aws* implementa o processamento de trabalhos na Amazon Web Services e demonstra uma arquitetura distribuída horizontalmente escalável. Ele inclui os seguintes componentes:

- Aplicativo web — interage com o usuário e agenda tarefas de exportação de PPTX para PDF, etc.
- Worker — processa exportações (in-process, out-of-process ou AWS Lambda).
- Fila de mensagens — armazena tarefas a serem processadas (Amazon SQS).
- Armazenamento de arquivos — armazena arquivos enviados e processados (Amazon S3).
- Armazenamento chave‑valor — rastreia o status de processamento das tarefas (Amazon DynamoDB).

Uma arquitetura distribuída típica depende de [filas de mensagens](https://aws.amazon.com/message-queue/): o aplicativo web coloca tarefas em segundo plano em uma fila; um worker em segundo plano recupera tarefas da fila e executa o trabalho necessário. Isso desacopla os componentes e torna o processamento assíncrono e confiável. A fila garante entrega e usa um *visibility timeout*: quando um worker pega uma mensagem, ela se torna invisível para outros workers; apenas o worker que está processando a remove ao concluir. Se o processamento não terminar dentro do *visibility timeout* (por exemplo, devido a uma falha ou problema de rede), a mensagem não processada torna‑se visível novamente.

Nossa implementação usa o [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), uma fila de mensagens totalmente gerenciada para microsserviços, sistemas distribuídos e aplicações serverless.

Filas de mensagens destinam‑se a mensagens leves (por exemplo, o limite de tamanho de mensagem do SQS é 256 KB), portanto uma mensagem deve conter apenas a descrição da tarefa. Dados pesados (como arquivos a serem processados) devem ser armazenados separadamente e referenciados na mensagem. O [Amazon S3](https://aws.amazon.com/s3/) é usado para armazenar arquivos enviados e processados.

Um armazenamento chave‑valor é necessário para persistir e recuperar resultados de trabalhos por ID. O exemplo usa o [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), um serviço de banco de dados NoSQL rápido e flexível.

Para executar o aplicativo de demonstração com a Amazon Web Services:

1. Na mesma região da AWS, crie e configure:
   1. uma fila SQS,
   1. um bucket S3,
   1. uma tabela DynamoDB.
2. Conecte o aplicativo web a esses serviços chamando *AddAws* em `Startup.ConfigureServices`, fornecendo a URL da fila SQS, o nome do bucket S3, o nome da tabela DynamoDB e a região da AWS.

## **Referências**

- [Melhores Práticas de Desempenho do ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Enviar arquivos no ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [ASP.NET em tempo real com SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Filas de Mensagens](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)