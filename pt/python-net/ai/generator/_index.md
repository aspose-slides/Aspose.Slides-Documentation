---
title: Gerador de Slides Multilíngue com IA
linktitle: Gerador com IA
type: docs
weight: 40
url: /pt/python-net/ai/generator/
keywords:
- apresentação multilíngue
- slide multilíngue
- gerador de apresentações com IA
- gerador de slides com IA
- recurso alimentado por IA
- agente de IA
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Genere slides multilíngues a partir de texto com Aspose.Slides para Python. Aplique seu modelo e exporte decks polidos para PowerPoint e OpenDocument. Saiba mais."
---
## **Introdução**

O Aspose.Slides apresenta um novo recurso alimentado por IA, o Presentation Generator, que permite que os desenvolvedores criem automaticamente apresentações PowerPoint bem estruturadas a partir de entradas de texto simples, como descrições de tópicos, resumos, citações ou marcadores.

Os usuários podem ajustar o nível de detalhe do conteúdo e, opcionalmente, aplicar um modelo de apresentação personalizado para definir o design visual.

Atualmente, o AI Presentation Generator estrutura o conteúdo usando blocos de texto, listas com marcadores e tabelas. A geração de imagens ainda não é suportada; porém, as imagens podem ser adicionadas facilmente posteriormente usando as ferramentas do Aspose.Slides ou manualmente.

A saída é uma apresentação PowerPoint completa que pode ser usada como está ou exportada para qualquer formato suportado pela API do Aspose.Slides. Embora o gerador produza resultados de alta qualidade, pode ser necessário um pequeno pós‑edição para atender a requisitos específicos.

## **Como funciona**

O Aspose.Slides não inclui modelos de IA incorporados; ao invés disso, ele se integra a serviços de IA externos pela internet. Essa integração é gerenciada pela classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/slidesaiagent/), que utiliza uma implementação da classe [IAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/iaiwebclient/) para se comunicar com o modelo de IA.

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/openaiwebclient/) incorporado, que se conecta à API da OpenAI, ou fornecer uma implementação personalizada de [IAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/iaiwebclient/) para trabalhar com outro provedor de IA ou modelo de linguagem. O Aspose.Slides gerencia toda a comunicação com o serviço de IA e processa as respostas da IA para gerar slides. Observe que a API da OpenAI é um serviço pago, portanto, uma conta e uma chave de API são necessárias ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/openaiwebclient/).

## **Vamos codificar**

### **Exemplo 1**

Este exemplo demonstra como gerar uma apresentação sobre o tópico Aspose.Slides usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/openaiwebclient/) incorporado.

```py
# Crie uma instância de OpenAIWebClient, a implementação incorporada do cliente web da OpenAI.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Crie uma instância de SlidesAIAgent, que fornece acesso a recursos alimentados por IA.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Defina a instrução para gerar a apresentação.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Gere uma apresentação com quantidade média de conteúdo com base na instrução.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Salve a apresentação gerada no disco local como um arquivo PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Exemplo 2**

O exemplo a seguir demonstra as sobrecargas do método [generate_presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). Neste caso, a `master presentation` do usuário é usada.

```py
# Passe o HttpClient ao construtor do OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Crie uma instância de SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Defina a instrução para gerar a apresentação.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Carregue uma apresentação mestre do disco local para usar como modelo de design.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Gere uma apresentação detalhada usando a instrução e o modelo mestre.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Salve a apresentação gerada como PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Benefícios Principais**

O novo AI Presentation Generator no Aspose.Slides oferece uma maneira rápida e flexível de produzir decks de slides estruturados a partir de prompts de texto simples. Com suporte a modelos personalizados, pode ser integrado de forma transparente a uma ampla variedade de aplicativos.

Casos de uso típicos incluem a criação de apresentações de marketing, materiais educacionais, relatórios para clientes e decks de slides internos. Embora a geração de imagens ainda não seja suportada, a ferramenta já oferece uma base sólida para automatizar a criação de apresentações, com aprimoramentos adicionais esperados no futuro.