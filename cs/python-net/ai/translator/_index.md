---
title: Překladač prezentací řízený AI
linktitle: Překladač řízený AI
type: docs
weight: 20
url: /cs/python-net/ai/translator/
keywords:
- Překladač prezentací AI
- Překladač snímků AI
- Funkce řízená AI
- Vícejazyčná prezentace
- Vícejazyčný snímek
- Překlad prezentace
- Překlad snímku
- Funkce řízené AI
- Schopnosti AI
- AI agent
- Webový klient
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Překládejte snímky PowerPoint pomocí AI s Aspose.Slides pro Python. Lokalizujte PPT, PPTX a ODP při zachování rozvržení – rychle a přátelsky pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonná API pro programové řízení PowerPoint prezentací. Kromě vytváření, úpravy a převodu snímků nabízí funkce řízené umělou inteligencí – například [Presentation Translation API](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/) pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími modely AI přes internet. Tato funkčnost je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/slidesaiagent/), která používá podtřídy [IAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/iaiwebclient/) k komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/) k připojení k API OpenAI nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/iaiwebclient/) pro použití jiného poskytovatele AI nebo jazykového modelu.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="info" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při použití vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu přeložíme PowerPoint prezentaci do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/) se specifikovaným OpenAI [modelem](https://platform.openai.com/docs/models).

```py
import aspose.slides as slides

# Načíst prezentaci k překladu.
with slides.Presentation("sample.pptx") as presentation:

    # Vytvořte AI klienta s OpenAIWebClient, zadáním modelu a API klíče.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Inicializujte SlidesAIAgent s AI klientem.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Přeložte prezentaci do japonštiny.
        ai_agent.translate(presentation, "japanese")

        # Uložte přeloženou prezentaci jako PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Příklad Azure OpenAI**

Od verze **26.7.0** podporuje Aspose.Slides pro Python přes .NET poskytovatele kompatibilní s OpenAI, včetně Azure OpenAI. Můžete nakonfigurovat překladač tak, aby používal vaše interní nasazení Azure pomocí [OpenAICompatibleWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaicompatiblewebclient/).

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

Tento úryvek demonstruje překlad prezentace pomocí vašeho Azure OpenAI koncového bodu. Nahraďte hodnoty zástupných znaků názvem nasazení, API klíčem a URL koncového bodu.

## **Klíčové výhody**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/) nabízí řešení poháněné AI pro poskytování vícejazyčných PowerPoint prezentací. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby v porovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, tato API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.