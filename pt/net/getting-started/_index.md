---
title: Introdução
type: docs
weight: 10
url: /pt/net/getting-started/
keywords:
- começar
- requisitos do sistema
- instalação
- primeira apresentação
- NuGet
- processamento de PPT
- processamento de PPTX
- processamento de ODP
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "O caminho de um novo projeto .NET até a primeira apresentação salva com Aspose.Slides: verifique os requisitos, instale o pacote, execute um programa inicial e continue com tarefas comuns."
---
## **Visão geral**

Siga as quatro etapas abaixo na ordem. Cada etapa indica o que fazer e vincula o artigo com os detalhes. Avaliação, licenciamento e suporte são abordados após as etapas.

## **Etapa 1: Verificar os Requisitos do Sistema**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) funciona em Windows, Linux e macOS. [Requisitos de Sistema](/slides/pt/net/system-requirements/) lista os sistemas operacionais e as versões .NET que cada pacote suporta, e as bibliotecas que o Linux necessita adicionalmente.

## **Etapa 2: Instalar o Pacote**

Aspose.Slides for .NET é distribuído via NuGet como dois pacotes que fornecem as mesmas classes. Adicione um deles ao seu projeto:

- No Windows: `dotnet add package Aspose.Slides.NET`
- No Linux e macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. No Linux, instale a biblioteca `fontconfig` primeiro.
- No Alpine Linux, e em sistemas Linux cuja glibc seja mais antiga que 2.23 (x64) ou 2.39 (ARM64): Aspose.Slides.NET, com a biblioteca `libgdiplus` instalada.

[Instalação](/slides/pt/net/installation/) fornece os comandos Linux, a configuração de inicialização extra que Aspose.Slides.NET precisa no Linux, e as etapas para o Visual Studio.

## **Etapa 3: Criar sua primeira apresentação**

O [início rápido na página inicial do Aspose.Slides for .NET](/slides/pt/net/#your-first-presentation) é um programa de console completo: ele adiciona uma caixa de texto a um slide e salva a apresentação como um arquivo PPTX. [Criar apresentações](/slides/pt/net/create-presentation/) explica as mesmas etapas com mais detalhes e mostra como abrir uma apresentação existente e salvá‑la em outro formato.

## **Etapa 4: Continuar com Tarefas Comuns**

- [Abrir uma apresentação](/slides/pt/net/open-presentation/)
- [Salvar uma apresentação](/slides/pt/net/save-presentation/)
- [Converter uma apresentação para PDF](/slides/pt/net/convert-powerpoint-to-pdf/)
- [Renderizar slides como imagens](/slides/pt/net/convert-slide/)
- [Editar texto da apresentação](/slides/pt/net/manage-text/)
- [Exemplos por elemento de slide](/slides/pt/net/examples/)

## **Avaliar e Licenciar**

Sem uma licença, Aspose.Slides funciona em modo de avaliação: ele adiciona uma marca d'água a cada slide que salva e trunca o texto lido das apresentações.

- [Avaliar Aspose.Slides](/slides/pt/net/evaluate-aspose-slides/) descreve as limitações da avaliação e como solicitar uma licença temporária.
- [Licenciamento](/slides/pt/net/licensing/) mostra como aplicar uma licença a partir de um arquivo, de um stream ou de um recurso incorporado.
- [Licenciamento por Medição](/slides/pt/net/metered-licensing/) cobre licenciamento que é cobrado por uso.
- [Formatos de arquivo suportados](/slides/pt/net/supported-file-formats/) lista os formatos que Aspose.Slides pode carregar e salvar.

## **Obter ajuda**

[Suporte ao produto](/slides/pt/net/product-support/) explica como fazer uma pergunta no [forum de suporte gratuito](https://forum.aspose.com/c/slides/11) e o que incluir ao relatar um problema.

## **Perguntas frequentes**

**Preciso ter o Microsoft PowerPoint instalado?**

Não. Aspose.Slides lê e grava arquivos de apresentação por conta própria e não usa o PowerPoint, portanto também funciona em servidores e no Linux.

**Qual pacote devo usar para uma aplicação .NET Framework?**

Aspose.Slides.NET. Ele inclui compilações para .NET Framework 4.6.2 e posteriores, .NET 6 e posteriores, e .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform requer .NET 6 ou posterior.