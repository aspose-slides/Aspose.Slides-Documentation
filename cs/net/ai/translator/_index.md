---
title: Prekladač prezentací poháněný AI
linktitle: Překladač poháněný AI
type: docs
weight: 20
url: /cs/net/ai/translator/
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
- .NET
- C#
- Aspose.Slides
description: "Překládejte snímky PowerPointu pomocí AI s využitím Aspose.Slides pro .NET. Lokalizujte PPT, PPTX a ODP při zachování rozvržení—rychlé a přátelské pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programatické řízení PowerPoint prezentací. Kromě vytváření, úprav a převodu snímků nabízí funkce řízené umělou inteligencí – například [Presentation Translation API](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/) pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími AI modely přes internet. Tato funkcionalita je vystavena prostřednictvím třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) k komunikaci s AI službami.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) pro připojení k API OpenAI, nebo si vytvořit vlastní implementaci [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) pro jiného poskytovatele AI či jazykový model.

Aspose.Slides zajišťuje komunikaci, parsuje AI odpovědi a inteligentně vkládá přeložený obsah při zachování původního rozložení a formátování snímků.

{{% alert color="primary" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu přeložíme PowerPoint prezentaci do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) a specifikovaného OpenAI [modelu](https://platform.openai.com/docs/models).

```csharp
// Načtěte prezentaci k překladu.
using var presentation = new Presentation("sample.pptx");
// Vytvořte AI klienta pomocí OpenAIWebClient a zadejte svůj model a API klíč.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);
// Inicializujte SlidesAIAgent s AI klientem.
var aiAgent = new SlidesAIAgent(aiWebClient);
// Přeložte prezentaci do japonštiny.
await aiAgent.TranslateAsync(presentation, "japanese");
// Uložte přeloženou prezentaci jako PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), přičemž automaticky řeší její životní cyklus a uvolňování. Pokud však chcete spravovat [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) sami – například při použití [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pro efektivnější správu zdrojů a výkon – můžete při konstrukci [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) předat vlastní instanci `HttpClient`.

```csharp
// Předpokládejte, že máte instanci IHttpClientFactory (např. injektovanou přes dependency injection).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides se běžně používá v synchronních prostředích. Pro podporu této situace nabízí třída [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent/) jak synchronní, tak asynchronní metody – takže si můžete vybrat přístup, který nejlépe vyhovuje pracovnímu toku vaší aplikace.

## **Klíčové výhody**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/) poskytuje řešení řízené AI pro doručování vícejazyčných PowerPoint prezentací. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřujete tak svůj dosah a zlepšujete komunikaci.