---
title: Tradutor de Apresentação com IA
linktitle: Tradutor com IA
type: docs
weight: 20
url: /pt/php-java/ai/translator/
keywords:
- Tradutor de apresentação com IA
- Tradutor de slides com IA
- Recurso impulsionado por IA
- apresentação multilíngue
- slide multilíngue
- tradução de apresentação
- tradução de slide
- Recursos guiados por IA
- Capacidades de IA
- Agente de IA
- Cliente web
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Traduza slides PowerPoint com IA usando Aspose.Slides para PHP. Localize PPT, PPTX e ODP preservando o layout—rápido e amigável para desenvolvedores. Experimente."
---
## **Introdução**

Aspose.Slides é uma API poderosa para gerenciar apresentações PowerPoint programaticamente. Além de criar, editar e converter slides, oferece recursos baseados em IA - como a API de Tradução de Apresentação para conteúdo de slides multilíngue.

## **Como funciona**

Aspose.Slides não inclui recursos de IA incorporados, mas integra-se a modelos de IA externos pela internet. Essa funcionalidade é exposta por meio da classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesaiagent/) para comunicar-se com serviços de IA.

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/) incorporado para se conectar à API da OpenAI.

Aspose.Slides gerencia a comunicação, analisa as respostas da IA e insere de forma inteligente o conteúdo traduzido, preservando o layout e a formatação originais dos slides.

{{% alert color="info" title="Nota" %}}
Observe que a API da OpenAI é um serviço pago, portanto você precisará criar uma conta e fornecer sua chave de API ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Exemplo**

Neste exemplo, traduzimos uma apresentação PowerPoint para japonês usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/) incorporado com um [modelo](https://platform.openai.com/docs/models) da OpenAI especificado.

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

Por padrão, o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/) incorporado cria e gerencia sua própria instância interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), controlando seu ciclo de vida automaticamente. Contudo, se preferir gerenciar a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) manualmente - principalmente para configurar definições essenciais como um proxy, ou para usar um [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou um [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para melhor gerenciamento de recursos e desempenho - você pode fornecer sua própria instância `HttpURLConnection` ao construir o [OpenAIWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaiwebclient/).

```php
// Crie e pré-configure sua própria instância HttpURLConnection (timeouts personalizados, configurações de proxy, etc.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Passe a conexão para o cliente de IA.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Exemplo Azure OpenAI**

Você pode configurar o tradutor para usar sua implantação Azure OpenAI com o [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pt/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Este trecho demonstra a tradução de uma apresentação usando seu endpoint Azure OpenAI. Substitua os valores do placeholder pelo nome da sua implantação, chave de API e URL do endpoint.

## **Principais benefícios**

A API de Tradução de Apresentação do Aspose.Slides oferece uma solução impulsionada por IA para entregar apresentações PowerPoint multilíngues. Ao automatizar a tradução e preservar o layout e o design, economiza tempo e minimiza erros em comparação com fluxos de trabalho manuais. Seja você desenvolvedor, educador ou profissional de negócios, esta API permite criar apresentações envolventes e localizadas para públicos globais - expandindo seu alcance e aprimorando a comunicação.