---
title: Gerador de Slides Multilíngue com IA
linktitle: Gerador com IA
type: docs
weight: 40
url: /pt/java/ai/generator/
keywords:
- apresentação multilíngue
- slide multilíngue
- gerador de apresentação com IA
- gerador de slide com IA
- recurso com IA
- agente de IA
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Gere slides multilíngues a partir de texto com Aspose.Slides para Java. Aplique seu modelo e exporte decks refinados para PowerPoint e OpenDocument. Saiba mais."
---
## **Introdução**

Aspose.Slides apresenta um novo recurso alimentado por IA, o Gerador de Apresentações, que permite aos desenvolvedores criar automaticamente apresentações PowerPoint bem estruturadas a partir de entradas de texto simples, como descrições de tópicos, resumos, citações ou marcadores.

Os usuários podem ajustar o nível de detalhe do conteúdo e, opcionalmente, aplicar um modelo de apresentação personalizado para definir o design visual.

Atualmente, o Gerador de Apresentações de IA estrutura o conteúdo usando blocos de texto, listas com marcadores e tabelas. A geração de imagens ainda não é suportada; no entanto, as imagens podem ser adicionadas facilmente posteriormente usando as ferramentas do Aspose.Slides ou manualmente.

A saída é uma apresentação PowerPoint completa que pode ser usada como está ou exportada para qualquer formato suportado pela API do Aspose.Slides. Embora o gerador produza resultados de alta qualidade, pode ser necessário um pós-edição leve para atender a requisitos específicos.

## **Como funciona**

Aspose.Slides não inclui modelos de IA incorporados; em vez disso, integra-se a serviços de IA externos pela internet. Essa integração é tratada pela classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidesaiagent/), que usa uma implementação da interface [IAIWebClient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iaiwebclient/) para se comunicar com o modelo de IA.

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/openaiwebclient/) incorporado, que se conecta à API da OpenAI, ou fornecer uma implementação personalizada de [IAIWebClient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iaiwebclient/) para trabalhar com outro provedor de IA ou modelo de linguagem. Aspose.Slides gerencia toda a comunicação com o serviço de IA e processa as respostas da IA para gerar slides. Observe que a API da OpenAI é um serviço pago, portanto, uma conta e uma chave de API são necessárias ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/openaiwebclient/) incorporado.

## **Vamos codificar**

### **Exemplo 1**

Este exemplo demonstra como gerar uma apresentação sobre o tópico Aspose.Slides usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/openaiwebclient/) incorporado.

```java
// Crie uma instância de OpenAIWebClient, a implementação incorporada do cliente web OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Crie uma instância de SlidesAIAgent, que fornece acesso a recursos com IA.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Defina a instrução para gerar a apresentação.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Genere uma apresentação com quantidade média de conteúdo com base na instrução.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Salve a apresentação gerada no disco local como um arquivo PowerPoint (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Exemplo 2**

O exemplo a seguir demonstra as sobrecargas do método [generatePresentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). Neste caso, uma instância de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gerenciada externamente e a `master presentation` do usuário são usadas.

Por padrão, o [OpenAIWebClient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/openaiwebclient/) incorporado cria e gerencia sua própria instância interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), controlando seu ciclo de vida automaticamente. No entanto, se você preferir gerenciar a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) manualmente — por exemplo, ao usar um [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ou [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) para melhorar o gerenciamento de recursos e desempenho — pode fornecer sua própria instância de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) ao construir o [OpenAIWebClient](https://reference.aspose.com/slides/pt/java/com.aspose.slides/openaiwebclient/).

```java
// Passe o HttpURLConnection ao construtor OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Crie uma instância de SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Defina a instrução para gerar a apresentação.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Carregue uma apresentação mestre do disco local para usar como modelo de design.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Genere uma apresentação detalhada usando a instrução e o modelo mestre.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Salve a apresentação gerada como PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Principais benefícios**

O novo Gerador de Apresentações de IA no Aspose.Slides oferece uma maneira rápida e flexível de produzir decks de slides estruturados a partir de prompts de texto simples. Com suporte a modelos personalizados e instâncias de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gerenciadas externamente, pode ser integrado perfeitamente em uma ampla variedade de aplicações.

Casos de uso típicos incluem a criação de apresentações de marketing, materiais educativos, relatórios para clientes e decks de slides internos. Embora a geração de imagens ainda não seja suportada, a ferramenta já oferece uma base sólida para automatizar a criação de apresentações, com aprimoramentos adicionais esperados no futuro.