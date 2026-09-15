---
title: Překladač prezentací poháněný AI
linktitle: Překladač poháněný AI
type: docs
weight: 20
url: /cs/nodejs-java/ai/translator/
keywords:
- AI překladač prezentací
- AI překladač snímků
- Funkce poháněná AI
- vícejazyčná prezentace
- vícejazyčný snímek
- překlad prezentace
- překlad snímku
- Funkce řízené AI
- Schopnosti AI
- AI agent
- Webový klient
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Překládejte snímky PowerPointu pomocí AI s Aspose.Slides pro Node.js. Lokalizujte soubory PPT, PPTX a ODP při zachování rozložení—rychlé a přátelské pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné rozhraní API pro programové spravování prezentací PowerPoint. Kromě vytváření, úprav a převodu snímků nabízí funkce poháněné umělou inteligencí – například Presentation Translation API pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími modely AI přes internet. Tato funkčnost je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesaiagent/), která umožňuje komunikaci se službami AI.

Můžete použít vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) pro připojení k API služby OpenAI.

Aspose.Slides zajišťuje komunikaci, analyzuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="info" title="Note" %}}
Všimněte si, že API OpenAI je placená služba, takže při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) budete muset vytvořit účet a zadat svůj API klíč.
{{% /alert %}}

## **Příklad**

V tomto příkladu přeložíme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Načíst prezentaci k překladu.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Vytvořte AI klienta pomocí OpenAIWebClient, specifikujte svůj model a API klíč.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializujte SlidesAIAgent s AI klientem.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Přeložte prezentaci do japonštiny.
    aiAgent.translate(presentation, "japanese");

    // Uložte přeloženou prezentaci jako PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), přičemž automaticky spravuje její životní cyklus. Pokud však preferujete spravovat [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sami – zejména pro nastavení nezbytných parametrů, jako je proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvořte a předkonfigurujte instanci HttpURLConnection (např. s vlastními časovými limity, nastavením proxy atd.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Příklad Azure OpenAI**

Můžete nakonfigurovat překladač tak, aby používal vaše nasazení Azure OpenAI pomocí [OpenAICompatibleWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Tento úryvek ukazuje, jak přeložit prezentaci pomocí vašeho Azure OpenAI koncového bodu. Nahraďte hodnoty zástupných symbolů názvem nasazení, API klíčem a URL koncového bodu.

## **Klíčové výhody**

Aspose.Slides Presentation Translation API nabízí řešení poháněné AI pro poskytování vícejazyčných prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.