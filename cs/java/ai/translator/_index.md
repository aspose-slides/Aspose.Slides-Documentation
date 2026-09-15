---
title: Překladač prezentací poháněný AI
linktitle: Překladač poháněný AI
type: docs
weight: 20
url: /cs/java/ai/translator/
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
- Java
- Aspose.Slides
description: "Překládějte snímky PowerPointu pomocí AI s Aspose.Slides pro Javu. Lokalizujte PPT, PPTX a ODP při zachování rozvržení—rychlé a přátelské pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programové řízení prezentací PowerPoint. Kromě vytváření, úpravy a převodu snímků nabízí funkce založené na AI – například API pro překlad prezentací pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími modely AI přes internet. Tato funkčnost je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) pro připojení k API OpenAI nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro použití jiného poskytovatele AI nebo jazykového modelu.

Aspose.Slides zajišťuje komunikaci, analyzuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="info" title="Poznámka" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a poskytnout svůj API klíč při použití vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Načíst prezentaci k překladu.
Presentation presentation = new Presentation("sample.pptx");

// Vytvořit AI klienta s OpenAIWebClient, specifikovat váš model a API klíč.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializovat SlidesAIAgent s AI klientem.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Přeložit prezentaci do japonštiny.
    aiAgent.translate(presentation, "japanese");

    // Uložit přeloženou prezentaci jako PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) a automaticky řídí její životní cyklus. Pokud však dáváte přednost spravovat [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sami – zejména pro nastavení důležitých parametrů, jako je proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) poskytnout svou vlastní instanci `HttpURLConnection`.

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Nakonfigurujte instanci HttpURLConnection sami (vlastní časové limity, nastavení proxy atd.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Příklad Azure OpenAI**

Můžete nakonfigurovat překladač, aby používal vaše nasazení Azure OpenAI pomocí [OpenAICompatibleWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaicompatiblewebclient/).

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

Tento úryvek ukazuje překlad prezentace pomocí vašeho koncového bodu Azure OpenAI. Nahraďte hodnoty zástupných znaků názvem nasazení, API klíčem a URL koncového bodu.

## **Klíčové výhody**

API pro překlad prezentací Aspose.Slides nabízí řešení založené na AI pro vytváření vícejazyčných prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby oproti manuálním postupům. Ať už jste vývojář, vzdělavatel nebo obchodní profesionál, toto API vám umožňuje vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.