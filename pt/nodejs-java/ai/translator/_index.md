---
title: Tradutor de Apresentações com IA
linktitle: Tradutor com IA
type: docs
weight: 20
url: /pt/nodejs-java/ai/translator/
keywords:
- Tradutor de apresentação com IA
- Tradutor de slides com IA
- Recurso com IA
- Apresentação multilíngue
- Slide multilíngue
- Tradução de apresentação
- Tradução de slide
- Recursos impulsionados por IA
- Capacidades de IA
- Agente de IA
- Cliente web
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Traduza slides do PowerPoint com IA usando Aspose.Slides para Node.js. Localize PPT, PPTX e ODP preservando o layout—rápido e amigável ao desenvolvedor. Experimente."
---
## **Introdução**

Aspose.Slides é uma API poderosa para gerenciamento programático de apresentações PowerPoint. Além de criar, editar e converter slides, oferece recursos impulsionados por IA – como a Presentation Translation API para conteúdo de slides multilíngue.

## **Como Funciona**

Aspose.Slides não inclui capacidades de IA nativas, mas integra-se a modelos de IA externos pela internet. Essa funcionalidade é exposta através da classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesaiagent/) para comunicação com serviços de IA.

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/) embutido para conectar à API da OpenAI.

Aspose.Slides gerencia a comunicação, analisa as respostas da IA e insere de forma inteligente o conteúdo traduzido, preservando o layout e a formatação originais dos slides.

{{% alert color="info" title="Nota" %}}
Observe que a API da OpenAI é um serviço pago, portanto você precisará criar uma conta e fornecer sua chave de API ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exemplo**

Neste exemplo, traduzimos uma apresentação PowerPoint para japonês usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/) embutido com um [modelo](https://platform.openai.com/docs/models) da OpenAI especificado.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Carregue uma apresentação para traduzir.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Crie um cliente de IA com OpenAIWebClient, especificando seu modelo e chave de API.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicialize SlidesAIAgent com o cliente de IA.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Traduza a apresentação para japonês.
    aiAgent.translate(presentation, "japanese");

    // Salve a apresentação traduzida como PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Por padrão, o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/) cria e gerencia sua própria instância interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), cuidando do seu ciclo de vida automaticamente. No entanto, se preferir gerenciar o [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) manualmente – principalmente para configurar definições essenciais como um proxy, ou usar um [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou um [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para melhor gerenciamento de recursos e desempenho – você pode fornecer sua própria instância `HttpURLConnection` ao construir o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Crie e pré-configure uma instância HttpURLConnection (por exemplo, com tempos de espera personalizados, configurações de proxy, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Exemplo Azure OpenAI**

Você pode configurar o tradutor para usar sua implantação Azure OpenAI com o [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Este trecho demonstra a tradução de uma apresentação usando seu endpoint Azure OpenAI. Substitua os valores de espaço reservado pelo nome da sua implantação, chave de API e URL do endpoint.

## **Principais Benefícios**

A Presentation Translation API da Aspose.Slides oferece uma solução impulsionada por IA para entregar apresentações PowerPoint multilíngues. Ao automatizar a tradução mantendo o layout e o design, economiza tempo e minimiza erros em comparação com fluxos de trabalho manuais. Seja você desenvolvedor, educador ou profissional de negócios, esta API permite criar apresentações envolventes e localizadas para audiências globais – ampliando seu alcance e melhorando a comunicação.