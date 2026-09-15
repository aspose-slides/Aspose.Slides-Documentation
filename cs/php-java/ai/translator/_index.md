---
title: Překladač prezentací poháněný AI
linktitle: Překladač poháněný AI
type: docs
weight: 20
url: /cs/php-java/ai/translator/
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
- PHP
- Aspose.Slides
description: "Překládání snímků PowerPoint s AI pomocí Aspose.Slides pro PHP. Lokalizujte PPT, PPTX a ODP při zachování rozvržení – rychle a přátelsky pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programatickou správu prezentací PowerPoint. Kromě vytváření, úpravy a převodu snímků nabízí funkce založené na AI – například Presentation Translation API pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné AI schopnosti, ale integruje se s externími AI modely přes internet. Tato funkčnost je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesaiagent/), která umožňuje komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) pro připojení k API OpenAI.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="info" title="Note" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a při použití vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) zadat svůj API klíč.
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```php
// Načtěte prezentaci k překladu.
$presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta pomocí OpenAIWebClient a zadejte svůj model a API klíč.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializujte SlidesAIAgent s AI klientem.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Přeložte prezentaci do japonštiny.
    $aiAgent->translate($presentation, "japanese");

    // Uložte přeloženou prezentaci jako PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), přičemž automaticky řídí její životní cyklus. Pokud však chcete [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) spravovat sami – zejména pro nastavení nezbytných parametrů, jako je proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```php
// Vytvořte a předkonfigurujte vlastní instanci HttpURLConnection (vlastní časové limity, nastavení proxy atd.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Předejte připojení AI klientovi.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Příklad Azure OpenAI**

Můžete nakonfigurovat překladač tak, aby používal vaše nasazení Azure OpenAI pomocí [OpenAICompatibleWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Tento útržek kódu ukazuje, jak přeložit prezentaci pomocí vašeho Azure OpenAI koncového bodu. Nahraďte zástupné hodnoty názvem nasazení, API klíčem a URL koncového bodu.

## **Klíčové výhody**

API Aspose.Slides Presentation Translation poskytuje řešení poháněné AI pro tvorbu vícejazyčných prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby v porovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.