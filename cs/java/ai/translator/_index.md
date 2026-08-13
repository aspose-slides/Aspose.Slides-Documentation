---
title: AI poháněný překladač prezentací
linktitle: AI poháněný překladač
type: docs
weight: 20
url: /cs/java/ai/translator/
keywords:
- AI překladač prezentací
- AI překladač snímků
- AI poháněná funkce
- vícejazyčná prezentace
- vícejazyčný snímek
- překlad prezentace
- překlad snímku
- AI řízené funkce
- AI schopnosti
- AI agent
- Webový klient
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Překládejte snímky PowerPoint pomocí AI s knihovnou Aspose.Slides pro Java. Lokalizujte PPT, PPTX a ODP při zachování rozložení - rychlé a přátelské pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programatické řízení PowerPoint prezentací. Kromě vytváření, úprav a konverze snímků nabízí funkce poháněné AI – například Presentation Translation API pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími AI modely přes internet. Tato funkcionalita je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) k připojení k API OpenAI nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro použití jiného poskytovatele AI nebo jazykového modelu.

Aspose.Slides zajišťuje komunikaci, zpracovává odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozložení a formátování snímků.

{{% alert color="info" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme PowerPoint prezentaci do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Načtěte prezentaci k překladu.
Presentation presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta s OpenAIWebClient a zadejte svůj model a API klíč.
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

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), přičemž automaticky řídí její životní cyklus. Pokud však dáváte přednost spravovat [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sami – například pro nastavení nezbytných parametrů jako je proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Nastavte instanci HttpURLConnection sami (vlastní časové limity, nastavení proxy atd.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Klíčové výhody**

Aspose.Slides Presentation Translation API nabízí řešení poháněné AI pro poskytování vícejazyčných PowerPoint prezentací. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.