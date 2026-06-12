---
title: AI-poháněný překladač prezentací
linktitle: AI-poháněný překladač
type: docs
weight: 20
url: /cs/python-net/ai/translator/
keywords:
- AI překladač prezentací
- AI překladač snímků
- AI-poháněná funkce
- vícejazyčná prezentace
- vícejazyčný snímek
- překlad prezentace
- překlad snímku
- funkce řízené AI
- schopnosti AI
- AI agent
- webový klient
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Překládejte snímky PowerPoint pomocí AI s Aspose.Slides pro Python. Lokalizujte PPT, PPTX a ODP při zachování rozvržení – rychlé a přátelské pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programové řízení prezentací PowerPoint. Kromě vytváření, úprav a konverze snímků nabízí funkce řízené AI – například [Presentation Translation API](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/) pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími AI modely přes internet. Tato funkčnost je zpřístupněna přes třídu [SlidesAIAgent](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/slidesaiagent/), která používá podtřídy [IAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/iaiwebclient/) pro komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/) k připojení k API OpenAI nebo si implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/iaiwebclient/) pro použití jiného poskytovatele AI či jazykového modelu.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="primary" %}}
Upozorňujeme, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/) s určeným OpenAI [model](https://platform.openai.com/docs/models).

```py
# Načtěte prezentaci k překladu.
with slides.Presentation("sample.pptx") as presentation:

    # Vytvořte AI klienta pomocí OpenAIWebClient, zadáním modelu a API klíče.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Inicializujte SlidesAIAgent s AI klientem.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Přeložte prezentaci do japonštiny.
        ai_agent.translate(presentation, "japanese")

        # Uložte přeloženou prezentaci jako PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **Klíčové výhody**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/) nabízí řešení řízené AI pro poskytování vícejazyčných prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a snižuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, učitel nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.