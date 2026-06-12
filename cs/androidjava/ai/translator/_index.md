---
title: Prekladatel prezentací s podporou AI
linktitle: Prekladatel poháněný AI
type: docs
weight: 20
url: /cs/androidjava/ai/translator/
keywords:
- AI překladatel prezentací
- AI překladatel snímků
- funkce poháněná AI
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
- Android
- Java
- Aspose.Slides
description: "Překládejte snímky PowerPointu pomocí AI s využitím Aspose.Slides pro Android v Javě. Lokalizujte PPT, PPTX a ODP při zachování rozložení – rychle a přátelské pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programové řízení prezentací PowerPoint. Kromě vytváření, úprav a konverze snímků nabízí funkce řízené AI – například API pro překlad prezentací pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími modely AI přes internet. Tato funkcionalita je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaiwebclient/) pro komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) pro připojení k API OpenAI nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaiwebclient/) pro použití jiného poskytovatele AI nebo jazykového modelu.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozložení a formátování snímků.

{{% alert color="primary" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```java
// Načtěte prezentaci k překladu.
Presentation presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta pomocí OpenAIWebClient, zadejte svůj model a API klíč.
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

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), přičemž automaticky spravuje její životní cyklus. Pokud však dáváte přednost spravovat [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sami – zejména pro nastavení nezbytných parametrů, jako je proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```java
// Předpokládejte, že máte předkonfigurovanou instanci HttpURLConnection (např. s vlastními časovými limity, nastavením proxy atd.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Klíčové výhody**

Aspose.Slides Presentation Translation API nabízí řešení poháněné AI pro doručování vícejazykových prezentací PowerPoint. Automatizací překladu při zachování rozložení a designu šetří čas a snižuje chyby ve srovnání s manuálními pracovními postupy. Ať už jste vývojář, učitel nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.