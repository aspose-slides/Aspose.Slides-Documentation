---
title: Tradutor de Apresentação com IA
linktitle: Tradutor com IA
type: docs
weight: 20
url: /pt/php-java/ai/translator/
keywords:
- tradutor de apresentação com IA
- tradutor de slide com IA
- recurso impulsionado por IA
- apresentação multilíngue
- slide multilíngue
- tradução de apresentação
- tradução de slide
- recursos orientados por IA
- capacidades de IA
- agente de IA
- cliente web
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Traduza slides do PowerPoint com IA usando Aspose.Slides para PHP. Localize PPT, PPTX e ODP preservando o layout—rápido e amigável ao desenvolvedor. Experimente."
---
## **Introdução**

Aspose.Slides é uma API poderosa para gerenciar programaticamente apresentações do PowerPoint. Além de criar, editar e converter slides, oferece recursos impulsionados por IA – como a API de Tradução de Apresentação para conteúdo de slides multilíngue.

## **Como funciona**

Aspose.Slides não inclui recursos de IA integrados, mas integra-se a modelos de IA externos via internet. Essa funcionalidade é exposta através da classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesaiagent/) para comunicar-se com serviços de IA.

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/) incorporado para conectar-se à API da OpenAI.

Aspose.Slides lida com a comunicação, analisa as respostas da IA e insere de forma inteligente o conteúdo traduzido, preservando o layout e a formatação originais dos slides.

{{% alert color="primary" %}}
Observe que a API da OpenAI é um serviço pago, portanto você precisará criar uma conta e fornecer sua chave de API ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exemplo**

Neste exemplo, traduzimos uma apresentação do PowerPoint para o japonês usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/) incorporado com um [modelo](https://platform.openai.com/docs/models) da OpenAI especificado.

```php
// Carregue uma apresentação para traduzir.
$presentation = new Presentation("sample.pptx");

// Crie um cliente de IA com OpenAIWebClient, especificando seu modelo e chave de API.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicialize SlidesAIAgent com o cliente de IA.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Traduza a apresentação para japonês.
    $aiAgent->translate($presentation, "japanese");

    // Salve a apresentação traduzida como PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Por padrão, o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/) incorporado cria e gerencia sua própria instância interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), controlando seu ciclo de vida automaticamente. No entanto, se preferir gerenciar a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) manualmente — principalmente para configurar definições essenciais como um proxy, ou para usar um [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou um [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para melhor gerenciamento de recursos e desempenho — você pode fornecer sua própria instância `HttpURLConnection` ao construir o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/).

```php
// Presuma que você tem uma instância HttpURLConnection pré-configurada (por exemplo, com tempos limite personalizados, configurações de proxy, etc.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Principais benefícios**

A API de Tradução de Apresentação do Aspose.Slides oferece uma solução impulsionada por IA para entregar apresentações do PowerPoint multilíngues. Ao automatizar a tradução preservando o layout e o design, economiza tempo e minimiza erros em comparação com fluxos de trabalho manuais. Seja você desenvolvedor, educador ou profissional de negócios, esta API permite criar apresentações envolventes e localizadas para públicos globais — ampliando seu alcance e melhorando a comunicação.