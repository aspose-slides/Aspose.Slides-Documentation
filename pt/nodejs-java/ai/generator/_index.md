---
title: Gerador Multilíngue de Slides com IA
linktitle: Gerador com IA
type: docs
weight: 40
url: /pt/nodejs-java/ai/generator/
keywords:
- apresentação multilíngue
- slide multilíngue
- gerador de apresentações com IA
- gerador de slides com IA
- recurso com IA
- agente de IA
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gere slides multilíngues a partir de texto com Aspose.Slides para Node.js. Aplique seu modelo e exporte decks refinados para PowerPoint e OpenDocument. Saiba mais."
---
## **Introdução**

Aspose.Slides apresenta um novo recurso com IA, o Gerador de Apresentações, que permite que os desenvolvedores criem automaticamente apresentações PowerPoint bem estruturadas a partir de entradas de texto simples, como descrições de tópicos, resumos, citações ou marcadores.

Os usuários podem ajustar o nível de detalhamento do conteúdo e, opcionalmente, aplicar um modelo de apresentação personalizado para definir o design visual.

Atualmente, o Gerador de Apresentações com IA estrutura o conteúdo usando blocos de texto, listas com marcadores e tabelas. A geração de imagens ainda não é suportada; no entanto, as imagens podem ser adicionadas facilmente posteriormente usando as ferramentas do Aspose.Slides ou manualmente.

A saída é uma apresentação PowerPoint completa que pode ser usada como está ou exportada para qualquer formato suportado pela API do Aspose.Slides. Embora o gerador produza resultados de alta qualidade, pode ser necessário um pequeno pós-edição para atender a requisitos específicos.

## **Como funciona**

Aspose.Slides não inclui modelos de IA incorporados; ao contrário, ele se integra a serviços de IA externos pela internet. Essa integração é tratada pela classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesaiagent/).

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/) incorporado, que se conecta à API da OpenAI. Aspose.Slides gerencia toda a comunicação com o serviço de IA e processa as respostas da IA para gerar slides. Observe que a API da OpenAI é um serviço pago, portanto, é necessário uma conta e uma chave de API ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/) incorporado.

## **Vamos codar**

### **Exemplo 1**

Este exemplo demonstra como gerar uma apresentação sobre o tema Aspose.Slides usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/) incorporado.

```js
// Crie uma instância de OpenAIWebClient, a implementação integrada do cliente web da OpenAI.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Crie uma instância de SlidesAIAgent, que fornece acesso a recursos com IA.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Defina a instrução para gerar a apresentação.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Gere uma apresentação com quantidade média de conteúdo com base na instrução.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Salve a apresentação gerada no disco local como um arquivo PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Exemplo 2**

O exemplo a seguir demonstra as sobrecargas do método [generatePresentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). Neste caso, uma instância de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gerenciada externamente e a `master presentation` do usuário são usadas.

Por padrão, o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/) incorporado cria e gerencia sua própria instância interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), controlando seu ciclo de vida automaticamente. No entanto, se preferir gerenciar a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) você mesmo - por exemplo, ao usar um [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) para melhorar o gerenciamento de recursos e o desempenho - pode fornecer sua própria instância de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ao construir o [OpenAIWebClient](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Passe o HttpURLConnection ao construtor do OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Crie uma instância de SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Defina a instrução para gerar a apresentação.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Carregue uma apresentação mestre do disco local para usar como modelo de design.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Genere uma apresentação detalhada usando a instrução e o modelo mestre.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Salve a apresentação gerada como PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Principais benefícios**

O novo Gerador de Apresentações com IA no Aspose.Slides oferece uma maneira rápida e flexível de produzir decks de slides estruturados a partir de instruções de texto simples. Com suporte a modelos personalizados e instâncias de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gerenciadas externamente, ele pode ser integrado perfeitamente a uma ampla variedade de aplicativos.

Os casos de uso típicos incluem a criação de apresentações de marketing, materiais educacionais, relatórios para clientes e decks de slides internos. Embora a geração de imagens ainda não seja suportada, a ferramenta já oferece uma base sólida para a automação da criação de apresentações, com aprimoramentos adicionais previstos para o futuro.