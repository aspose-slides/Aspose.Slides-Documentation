---
title: AI-poháněný překladač prezentací
linktitle: AI-poháněný překladač
type: docs
weight: 20
url: /cs/net/ai/translator/
keywords:
- AI překladač prezentací
- AI překladač snímků
- AI-poháněná funkce
- vícejazyčná prezentace
- vícejazyčný snímek
- překlad prezentace
- překlad snímku
- AI-poháněné funkce
- AI schopnosti
- AI agent
- webový klient
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Překládejte PowerPoint snímky pomocí AI s Aspose.Slides pro .NET. Lokalizujte PPT, PPTX a ODP při zachování rozvržení — rychle a přátelsky pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programové řízení prezentací PowerPoint. Kromě vytváření, úprav a převodu snímků nabízí funkce řízené AI - například [Presentation Translation API](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/) pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné funkce AI, ale integruje se s externími modely AI přes internet. Tato funkčnost je zpřístupněna pomocí třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) pro komunikaci se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) k připojení k API společnosti OpenAI nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) pro použití jiného poskytovatele AI nebo jazykového modelu.

Aspose.Slides zpracovává komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení snímků a formátování.

{{% alert color="info" %}}
Všimněte si, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu přeložíme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Načtěte prezentaci k překladu.
using var presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta s OpenAIWebClient, specifikujte svůj model a API klíč.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Inicializujte SlidesAIAgent s AI klientem.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Přeložte prezentaci do japonštiny.
await aiAgent.TranslateAsync(presentation, "japanese");

// Uložte přeloženou prezentaci jako PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), automaticky zvládá její životní cyklus a uvolňování. Pokud však preferujete spravovat [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) sami - například při použití [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pro lepší správu prostředků a výkon - můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) předat vlastní instance `HttpClient`.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Použijte HttpClient, který spravujete sami - například vytvořený pomocí IHttpClientFactory
// vložený pomocí dependency injection.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides se běžně používá v synchronních prostředích. Pro podporu toho nabízí třída [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent/) jak synchronní, tak asynchronní metody - což vám umožní vybrat přístup, který nejlépe vyhovuje workflow vaší aplikace.

## **Klíčové výhody**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/) nabízí řešení poháněné AI pro poskytování vícejazykových prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a minimalizuje chyby ve srovnání s manuálními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum - rozšiřuje váš dosah a zlepšuje komunikaci.