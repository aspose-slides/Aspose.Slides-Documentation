---
title: AI-Poháněný překladač prezentací
linktitle: AI-Poháněný překladač
type: docs
weight: 20
url: /cs/java/ai/translator/
keywords:
- AI překladač prezentací
- AI překladač snímků
- AI-poháněná funkce
- vícejazyková prezentace
- vícejazykový snímek
- překlad prezentace
- překlad snímku
- AI-řízené funkce
- AI schopnosti
- AI agent
- Webový klient
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Překládejte snímky PowerPoint pomocí AI s Aspose.Slides pro Java. Lokalizujte PPT, PPTX a ODP při zachování rozvržení – rychle a přátelsky k vývojářům. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonná API pro programové řízení prezentací PowerPoint. Kromě vytváření, úprav a konverze snímků nabízí funkce řízené AI – například API pro překlad prezentací pro vícejazykový obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími modely AI přes internet. Tato funkcionalita je zpřístupněna pomocí třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) k připojení k API OpenAI nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro použití jiného poskytovatele AI nebo jazykového modelu.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="primary" %}}
Upozorňujeme, že API OpenAI je placená služba, takže budete muset vytvořit účet a poskytnout svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```java
// Načtěte prezentaci k překladu.
Presentation presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta pomocí OpenAIWebClient, specifikujte svůj model a API klíč.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializujte SlidesAIAgent s AI klientem.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Přeložte prezentaci do japonštiny.
    aiAgent.translate(presentation, "japanese");

    // Uložte přeloženou prezentaci jako PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) a automaticky se stará o její životní cyklus. Pokud však upřednostňujete spravovat [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sami – zejména pro nastavení nezbytných parametrů, jako je proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při tvorbě [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```java
// Předpokládejte, že máte předkonfigurovanou instanci HttpURLConnection (např. s vlastními časovými limity, nastavením proxy atd.).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Klíčové výhody**

API pro překlad prezentací Aspose.Slides nabízí řešení poháněné AI pro poskytování vícejazykových prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.