---
title: Prekladatel prezentací s podporou AI
linktitle: Překladač s podporou AI
type: docs
weight: 20
url: /cs/php-java/ai/translator/
keywords:
- AI překladač prezentací
- AI překladač snímků
- Funkce poháněná AI
- vícejazyková prezentace
- vícejazykový snímek
- překlad prezentace
- překlad snímku
- Funkce řízené AI
- Schopnosti AI
- AI agent
- Webový klient
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Překládějte snímky PowerPoint pomocí AI s Aspose.Slides pro PHP. Lokalizujte PPT, PPTX a ODP při zachování rozvržení — rychlé a přívětivé pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné rozhraní API pro programové řízení prezentací PowerPoint. Kromě vytváření, úprav a převodu snímků nabízí funkce poháněné umělou inteligencí – například API pro překlad prezentací pro více jazykový obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné možnosti AI, ale integruje se s externími modely AI přes internet. Tato funkčnost je zpřístupněna prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesaiagent/), která umožňuje komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) pro připojení k API společnosti OpenAI.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="primary" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) s určeným OpenAI [model](https://platform.openai.com/docs/models).

```php
// Načíst prezentaci k překladu.
$presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta s OpenAIWebClient, specifikujte svůj model a API klíč.
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

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), přičemž automaticky spravuje její životní cyklus. Pokud však dáváte přednost spravovat [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sami – zejména pro nastavení nezbytných parametrů, jako je proxy, nebo pro použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) či jiného [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu prostředků a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/openaiwebclient/) poskytnout vlastní instanci `HttpURLConnection`.

```php
// Předpokládejte, že máte předkonfigurovanou instanci HttpURLConnection (např. s vlastními časovými limity, nastavením proxy atd.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Klíčové výhody**

API pro překlad prezentací Aspose.Slides nabízí řešení poháněné AI pro poskytování vícejazykových prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřuje váš dosah a zlepšuje komunikaci.