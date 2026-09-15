---
title: Tradutor de Apresentação com IA
linktitle: Tradutor com IA
type: docs
weight: 20
url: /pt/python-net/ai/translator/
keywords:
- Tradutor de apresentação com IA
- Tradutor de slides com IA
- Recurso alimentado por IA
- Apresentação multilíngue
- Slide multilíngue
- Tradução de apresentação
- Tradução de slide
- Recursos impulsionados por IA
- Capacidades de IA
- Agente de IA
- Cliente Web
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Traduza slides PowerPoint com IA usando Aspose.Slides para Python. Localize PPT, PPTX e ODP preservando o layout—rápido e amigável ao desenvolvedor. Experimente."
---
## **Introdução**

Aspose.Slides é uma API poderosa para gerenciar programaticamente apresentações PowerPoint. Além de criar, editar e converter slides, oferece recursos impulsionados por IA – como a [Presentation Translation API](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/) para conteúdo de slides multilíngue.

## **Como funciona**

Aspose.Slides não inclui recursos de IA incorporados, mas integra-se a modelos de IA externos pela internet. Essa funcionalidade é exposta via a classe [SlidesAIAgent](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/slidesaiagent/) , que usa subclasses de [IAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/iaiwebclient/) para comunicar-se com serviços de IA.

Você pode usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/openaiwebclient/) incorporado para conectar-se à API da OpenAI ou implementar seu próprio [IAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/iaiwebclient/) para usar um fornecedor de IA ou modelo de linguagem diferente.

Aspose.Slides gerencia a comunicação, analisa as respostas da IA e insere de forma inteligente o conteúdo traduzido, preservando o layout e a formatação originais dos slides.

{{% alert color="info" %}}
Observe que a API da OpenAI é um serviço pago, portanto você precisará criar uma conta e fornecer sua chave de API ao usar o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Exemplo**

Neste exemplo, traduzimos uma apresentação PowerPoint para japonês usando o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/openaiwebclient/) incorporado com um [modelo](https://platform.openai.com/docs/models) da OpenAI especificado.

```py
import aspose.slides as slides

# Carregue uma apresentação para traduzir.
with slides.Presentation("sample.pptx") as presentation:

    # Crie um cliente de IA com OpenAIWebClient, especificando seu modelo e chave de API.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Inicialize SlidesAIAgent com o cliente de IA.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Traduza a apresentação para japonês.
        ai_agent.translate(presentation, "japanese")

        # Salve a apresentação traduzida como PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Exemplo Azure OpenAI**

Desde a versão **26.7.0**, Aspose.Slides para Python via .NET oferece suporte a provedores compatíveis com OpenAI, incluindo Azure OpenAI. Você pode configurar o tradutor para usar sua implantação interna do Azure com o [OpenAICompatibleWebClient](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Este trecho demonstra a tradução de uma apresentação usando seu endpoint Azure OpenAI. Substitua os valores de marcador de posição pelo nome da sua implantação, chave de API e URL do endpoint.

## **Principais Benefícios**

A [Presentation Translation API](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ai/) do Aspose.Slides oferece uma solução alimentada por IA para disponibilizar apresentações PowerPoint multilíngues. Ao automatizar a tradução preservando o layout e o design, economiza tempo e minimiza erros em comparação com fluxos de trabalho manuais. Seja você desenvolvedor, educador ou profissional de negócios, essa API permite criar apresentações envolventes e localizadas para públicos globais – ampliando seu alcance e melhorando a comunicação.