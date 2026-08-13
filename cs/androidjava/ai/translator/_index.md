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
description: "Překládejte PowerPoint snímky pomocí AI s využitím Aspose.Slides pro Android v Javě. Lokalizujte PPT, PPTX a ODP při zachování rozvržení—rychle a přátelsky pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné rozhraní API pro programové řízení PowerPoint prezentací. Kromě vytváření, úprav a konverze snímků nabízí funkce řízené umělou inteligencí – například API pro překlad prezentací, které podporuje vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími modely AI přes internet. Tato funkčnost je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaiwebclient/) k komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) k připojení k API OpenAI, nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaiwebclient/), abyste použili jiného poskytovatele AI nebo jazykový model.

Aspose.Slides zajišťuje komunikaci, analyzuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="info" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu přeložíme PowerPoint prezentaci do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) a zvoleného OpenAI [modelu](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

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

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) vytváří a spravuje svou vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), přičemž automaticky řídí její životní cyklus. Pokud však chcete [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) spravovat sami — zejména pro nastavení nezbytných parametrů jako proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon — můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Nakonfigurujte si instanci HttpURLConnection (např. s vlastními časovými limity, nastavením proxy atd.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Předajte spojení konstruktoru OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Klíčové výhody**

API pro překlad prezentací Aspose.Slides nabízí řešení založené na AI pro poskytování vícejazyčných PowerPoint prezentací. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum — rozšiřuje vaše dosah a zlepšuje komunikaci.