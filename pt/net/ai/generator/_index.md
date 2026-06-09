---
title: Gerador de Slides Multilíngue com IA
linktitle: Gerador com IA
type: docs
weight: 40
url: /pt/net/ai/generator/
keywords:
- apresentação multilíngue
- slide multilíngue
- gerador de apresentação com IA
- gerador de slide com IA
- recurso impulsionado por IA
- agente de IA
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie slides multilíngues a partir de texto com Aspose.Slides para .NET. Aplique seu modelo e exporte decks refinados para PowerPoint e OpenDocument. Saiba mais."
---
## **Introdução**

Aspose.Slides apresenta um novo recurso impulsionado por IA, o Gerador de Apresentações, que permite aos desenvolvedores criar automaticamente apresentações PowerPoint bem estruturadas a partir de entradas de texto simples, como descrições de tópicos, resumos, citações ou marcadores.

Os usuários podem ajustar o nível de detalhe do conteúdo e, opcionalmente, aplicar um modelo de apresentação personalizado para definir o design visual.

Atualmente, o Gerador de Apresentações de IA estrutura o conteúdo usando blocos de texto, listas de marcadores e tabelas. A geração de imagens ainda não é suportada; no entanto, as imagens podem ser adicionadas facilmente depois usando as ferramentas do Aspose.Slides ou manualmente.

A saída é uma apresentação PowerPoint completa que pode ser usada como está ou exportada para qualquer formato suportado pela API do Aspose.Slides. Embora o gerador produza resultados de alta qualidade, pode ser necessária uma pequena pós‑edição para atender a requisitos específicos.

## **Como Funciona**

O Aspose.Slides não inclui modelos de IA incorporados; em vez disso, ele se integra a serviços de IA externos pela internet. Essa integração é gerenciada pela classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/slidesaiagent/), que usa uma implementação da interface [IAIWebClient](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/iaiwebclient/) para se comunicar com o modelo de IA.

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/openaiwebclient/), que se conecta à API da OpenAI, ou fornecer uma implementação personalizada de [IAIWebClient](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/iaiwebclient/) para trabalhar com outro provedor de IA ou modelo de linguagem. O Aspose.Slides gerencia toda a comunicação com o serviço de IA e processa as respostas da IA para gerar slides. Observe que a API da OpenAI é um serviço pago, portanto, uma conta e uma chave de API são necessárias ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/openaiwebclient/).

## **Vamos Codar**

### **Exemplo 1**

Este exemplo demonstra como gerar uma apresentação sobre o tema Aspose.Slides usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Crie uma instância de OpenAIWebClient, a implementação interna do cliente web OpenAI.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Crie uma instância de SlidesAIAgent, que fornece acesso a recursos impulsionados por IA.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Defina a instrução para gerar a apresentação.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Gere uma apresentação com uma quantidade média de conteúdo com base na instrução.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Salve a apresentação gerada no disco local como um arquivo PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Exemplo 2**

O exemplo a seguir demonstra as sobrecargas do método [GeneratePresentation](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/slidesaiagent/generatepresentation/). Neste caso, uma instância de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gerenciada externamente e a `master presentation` do usuário são utilizadas.

Por padrão, o [OpenAIWebClient](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/openaiwebclient/) cria e gerencia sua própria instância interna de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), lidando com seu ciclo de vida e descarte automaticamente. No entanto, se você preferir gerenciar o [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) você mesmo — por exemplo, ao usar um [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) para melhorar a gestão de recursos e desempenho — pode fornecer sua própria instância de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) ao construir o [OpenAIWebClient](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Crie uma instância de HttpClient gerenciada externamente.
using var httpClient = new HttpClient();

// Passe o HttpClient para o construtor OpenAIWebClient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Crie uma instância de SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Defina a instrução para gerar a apresentação.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Carregue uma apresentação mestre do disco local para usar como modelo de design.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Gere uma apresentação detalhada usando a instrução e o modelo mestre.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Salve a apresentação gerada como PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Vale notar que muitos clientes usam o Aspose.Slides em contextos síncronos. Para suportar isso, a classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/net/aspose.slides.ai/slidesaiagent/) oferece métodos síncronos e assíncronos, permitindo escolher a abordagem que melhor se adapta ao fluxo de trabalho da sua aplicação.

## **Principais Benefícios**

O novo Gerador de Apresentações de IA no Aspose.Slides oferece uma forma rápida e flexível de produzir decks de slides estruturados a partir de prompts de texto simples. Com suporte a modelos personalizados, instâncias de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gerenciadas externamente e fluxos de trabalho síncronos e assíncronos, pode ser integrado perfeitamente a uma ampla gama de aplicativos.

Os casos de uso típicos incluem a criação de apresentações de marketing, materiais educacionais, relatórios de clientes e decks de slides internos. Embora a geração de imagens ainda não seja suportada, a ferramenta já oferece uma base sólida para automatizar a criação de apresentações, com aprimoramentos adicionais esperados no futuro.