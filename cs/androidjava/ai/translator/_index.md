---
title: Překladač prezentací poháněný AI
linktitle: Překladač poháněný AI
type: docs
weight: 20
url: /cs/androidjava/ai/translator/
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
- webový klient
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Překládejte snímky PowerPoint pomocí AI s Aspose.Slides pro Android v Javě. Lokalizujte PPT, PPTX a ODP při zachování rozvržení — rychle a přátelsky k vývojářům. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programové řízení prezentací PowerPoint. Kromě vytváření, úpravy a konverze snímků nabízí funkce řízené AI – například Presentation Translation API pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné AI funkce, ale integruje se s externími AI modely přes internet. Tato funkcionalita je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaiwebclient/) pro komunikaci s AI službami.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) k připojení k API OpenAI nebo si vytvořit vlastní implementaci [IAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaiwebclient/) pro použití jiného poskytovatele AI či jazykového modelu.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="info" title="Poznámka" %}}

Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Příklad**

V tomto příkladu přeložíme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) s určeným modelem OpenAI [model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Načtěte prezentaci k překladu.
Presentation presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta pomocí OpenAIWebClient, s určením modelu a API klíče.
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

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) a automaticky řídí její životní cyklus. Pokud však chcete [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) spravovat sami – například pro nastavení proxy, použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) nebo jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší řízení zdrojů a výkon – můžete při konstrukci [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Nakonfigurujte instanci HttpURLConnection sami (např. s vlastními časovými limity, nastavením proxy atd.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Předejte připojení do konstruktoru OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Příklad Azure OpenAI**

Můžete nakonfigurovat překladač tak, aby používal vaše nasazení Azure OpenAI pomocí [OpenAICompatibleWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Tento úryvek ukazuje, jak přeložit prezentaci pomocí vašeho koncového bodu Azure OpenAI. Nahraďte zástupné hodnoty názvem nasazení, API klíčem a URL koncového bodu.

## **Klíčové výhody**

Aspose.Slides Presentation Translation API nabízí řešení poháněné AI pro doručování vícejazyčných prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.