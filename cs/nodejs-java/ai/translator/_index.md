---
title: Překladač prezentací s AI
linktitle: Překladač s AI
type: docs
weight: 20
url: /cs/nodejs-java/ai/translator/
keywords:
- AI překladač prezentací
- AI překladač snímků
- funkce poháněná AI
- vícejazyčná prezentace
- vícejazyčný snímek
- překlad prezentace
- překlad snímku
- funkce řízené AI
- schopnosti AI
- AI agent
- Webový klient
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Překládejte snímky PowerPointu pomocí AI s Aspose.Slides pro Node.js. Lokalizujte PPT, PPTX a ODP při zachování rozvržení – rychlé a přátelské pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné rozhraní API pro programové řízení PowerPoint prezentací. Kromě vytváření, úpravy a konverze snímků nabízí funkce řízené umělou inteligencí – například API pro překlad prezentací pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné možnosti AI, ale integruje se s externími modely AI přes internet. Tato funkčnost je zpřístupněna pomocí třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesaiagent/), která umožňuje komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) pro připojení k API OpenAI.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="primary" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při použití vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme PowerPoint prezentaci do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```js
// Načíst prezentaci k překladu.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Vytvořit AI klienta s OpenAIWebClient, zadáním modelu a API klíče.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializovat SlidesAIAgent s AI klientem.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Přeložit prezentaci do japonštiny.
    aiAgent.translate(presentation, "japanese");

    // Uložit přeloženou prezentaci jako PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), automaticky se stará o její životní cyklus. Pokud však chcete [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) spravovat sami – například pro nastavení nezbytných parametrů jako proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```js
// Předpokládejte, že máte předkonfigurovanou instanci HttpURLConnection (např. s vlastními časovými limity, nastavením proxy atd.).
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Klíčové výhody**

API pro překlad prezentací Aspose.Slides nabízí řešení založené na AI pro doručování vícejazyčných PowerPoint prezentací. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními pracovními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.