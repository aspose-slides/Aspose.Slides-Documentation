---
title: Como Executar Exemplos
type: docs
weight: 130
url: /pt/net/how-to-run-examples/
keywords:
- exemplos
- requisitos de software
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Execute exemplos do Aspose.Slides for .NET rapidamente: clone o repositório, restaure os pacotes e, em seguida, compile e teste recursos para PPT, PPTX e ODP."
---
## **Requisitos de Software**
Antes de baixar e executar os exemplos, verifique e confirme que sua configuração atende a esses requisitos: 

- Visual Studio 2010 ou superior.
- NuGet Package Manager instalado no Visual Studio. Verifique se a versão mais recente da API do NuGet está instalada no Visual Studio. 

Para instruções sobre como instalar o gerenciador de pacotes NuGet, acesse esta página: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Acesse **Tools** > **Options** > **NuGet Package Manager**.

1. Expanda **NuGet Package Manager** (clicando duas vezes nele) e então selecione **Package Sources**. 

1. Verifique e confirme que o parâmetro nuget.org está selecionado. 

   O projeto de exemplo usa o recurso NuGet Automatic Package Restore, portanto você precisa de uma conexão ativa com a internet. 

   Se você não tiver uma conexão ativa com a internet na máquina onde pretende executar os exemplos, verifique a [Instalação](https://docs.aspose.com/slides/pt/net/installation/) e (manualmente) adicione uma referência a Aspose.Slides.dll no projeto de exemplo.
## **Baixar Aspose.Slides do GitHub**
Todos os exemplos do Aspose.Slides for .NET estão hospedados no [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Você pode clonar o repositório usando seu cliente GitHub favorito ou baixar o arquivo ZIP [aqui](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Se você baixar o arquivo ZIP, precisará extrair seu conteúdo para uma pasta em seu computador. 

Todos os exemplos estão armazenados na pasta **Examples**.

Existe um arquivo de solução Visual Studio C#. Os projetos foram criados no Visual Studio 2013, mas os arquivos de solução são compatíveis com Visual Studio 2010 SP1 e superiores.

2. Abra o arquivo de solução no Visual Studio e compile o projeto.

   Na primeira execução, as dependências são baixadas automaticamente via NuGet.

A pasta **Data** na raiz da pasta **Examples** contém arquivos de entrada usados nos exemplos C#. Você precisa baixar a pasta **Data** juntamente com o projeto de exemplos.

3. Abra o arquivo RunExamples.cs. Todos os exemplos são chamados a partir dele.

4. Descomente os exemplos que deseja executar dentro do projeto.

Sinta-se à vontade para nos contatar pelos nossos fóruns se tiver problemas ao configurar ou executar os exemplos.
## **Contribuir**
Você pode contribuir com o projeto adicionando ou aprimorando um exemplo. Todos os exemplos e projetos de demonstração no repositório são de código aberto, portanto você (e outras pessoas) podem usá‑los livremente em aplicações.

Para contribuir, você pode fazer fork do repositório, editar o código‑fonte e criar um pull request. Revisaremos as alterações. Se as considerarmos úteis, as adicionaremos ao repositório.